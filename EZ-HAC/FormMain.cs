using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EZ_HAC
{
    public partial class FormMain : Form
    {
        Process Hactool;

        public FormMain()
        {
            HacChecks.RunChecks();

            InitializeComponent();

#if !DEBUG
            BuildLabel.Text = "Release build";
#else
            BuildLabel.Text = "Debug build";
#endif

            HactoolVersion.Text += " " + HacChecks.HacVersionId;

            Hactool = new Process();

            Hactool.StartInfo.FileName = "hactool.exe";

            Hactool.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        }

        private void UpdateDescription(string Text)
        {
            DescriptionLabel.Text = "Description: " + Text;
        }

        private void XciExtractionTab_Enter(object sender, EventArgs e)
        {
            UpdateDescription("Extract all XCI contents.");
        }

        private void NcaExtractionTab_Enter(object sender, EventArgs e)
        {
            UpdateDescription("Extract all NCA contents.");
        }

        private void NcaExtract_Click(object sender, EventArgs e)
        {
            if (NcaPath.Text == "")
            {
                MessageBox.Show("Invalid NCA path!", "Warning!", MessageBoxButtons.OK);
                return;
            }

            if (NcaOutputPath.Text == "")
            {
                MessageBox.Show("Invalid NCA output path!", "Warning!", MessageBoxButtons.OK);
                return;
            }

            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = false;

            HacProgress.Maximum = 100;
            HacProgress.Step    = 50;

            if (NcaEmulatorExtract.Checked)
            {
                if (NcaTitleKey.Text != "")
                {
                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat --titlekey=" + NcaTitleKey.Text + " \"" + NcaPath.Text + "\" --section0dir=\"" + NcaOutputPath.Text + "\"";
                    Hactool.Start();
                    Hactool.WaitForExit();

                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat --titlekey=" + NcaTitleKey.Text + " \"" + NcaPath.Text + "\" --romfs=\"" + NcaOutputPath.Text + "/main.romfs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();
                }
                else
                {
                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat \"" + NcaPath.Text + "\" --section0dir=\"" + NcaOutputPath.Text + "\"";
                    Hactool.Start();
                    Hactool.WaitForExit();

                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat \"" + NcaPath.Text + "\" --romfs=\"" + NcaOutputPath.Text + "/main.romfs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();
                }
            }
            else
            {
                if (NcaTitleKey.Text != "")
                {
                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat --titlekey=" + NcaTitleKey.Text + " \"" + NcaPath.Text + "\" --section0dir=\"" + NcaOutputPath.Text + "/exefs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();

                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat --titlekey=" + NcaTitleKey.Text + " \"" + NcaPath.Text + "\" --romfsdir=\"" + NcaOutputPath.Text + "/romfs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();
                }
                else
                {
                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat \"" + NcaPath.Text + "\" --section0dir=\"" + NcaOutputPath.Text + "/exefs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();

                    HacProgress.PerformStep();

                    Hactool.StartInfo.Arguments = "-k keys.dat \"" + NcaPath.Text + "\" --romfsdir=\"" + NcaOutputPath.Text + "/romfs\"";
                    Hactool.Start();
                    Hactool.WaitForExit();
                }
            }

            HacProgress.Value = 0;

            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = true;

            MessageBox.Show("Done extracting NCA contents!", "Done!", MessageBoxButtons.OK);
        }

        private void NcaBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog NcaDialog = new OpenFileDialog();

            NcaDialog.Title            = "Browse for NCA file";
            NcaDialog.Filter           = "NCA file (*.nca)|*.nca";
            NcaDialog.FilterIndex      = 1;
            NcaDialog.RestoreDirectory = true;

            if (NcaDialog.ShowDialog() == DialogResult.OK)
            {
                NcaPath.Text = NcaDialog.FileName;
            }
        }

        private void NcaOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog NcaOutputDialog = new FolderBrowserDialog();

            NcaOutputDialog.Description  = "Browse for NCA output folder";
            NcaOutputDialog.SelectedPath = Application.StartupPath;

            if (NcaOutputDialog.ShowDialog() == DialogResult.OK)
            {
                NcaOutputPath.Text = NcaOutputDialog.SelectedPath;
            }
        }

        private void XciBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog XciDialog = new OpenFileDialog();

            XciDialog.Title            = "Browse for XCI file";
            XciDialog.Filter           = "XCI file (*.xci)|*.xci";
            XciDialog.FilterIndex      = 1;
            XciDialog.RestoreDirectory = true;

            if (XciDialog.ShowDialog() == DialogResult.OK)
            {
                XciPath.Text = XciDialog.FileName;
            }
        }

        private void XciOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog XciOutputDialog = new FolderBrowserDialog();

            XciOutputDialog.Description  = "Browse for NCA output folder";
            XciOutputDialog.SelectedPath = Application.StartupPath;

            if (XciOutputDialog.ShowDialog() == DialogResult.OK)
            {
                XciOutputPath.Text = XciOutputDialog.SelectedPath;
            }
        }

        private void XciExtract_Click(object sender, EventArgs e)
        {
            if (XciPath.Text == "")
            {
                MessageBox.Show("Invalid XCI path!", "Error!", MessageBoxButtons.OK);
                return;
            }

            if (XciOutputPath.Text == "")
            {
                MessageBox.Show("Invalid XCI output path!", "Error!", MessageBoxButtons.OK);
                return;
            }

            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = false;

            HacProgress.Maximum = 100;
            HacProgress.Step    = 100;

            HacProgress.PerformStep();

            Hactool.StartInfo.Arguments = "-k keys.dat -t xci \"" + XciPath.Text + "\" --outdir=\"" + XciOutputPath.Text + "\"";
            Hactool.Start();
            Hactool.WaitForExit();

            HacProgress.Value = 0;

            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = true;

            MessageBox.Show("Done extracting XCI contents!", "Done!", MessageBoxButtons.OK);
        }
    }
}
