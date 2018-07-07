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
        HacRunner Hactool;

        public FormMain()
        {
            HacHelper.RunChecks();

            InitializeComponent();

            Hactool = new HacRunner();

            HactoolVersion.Text += " " + HacHelper.HacVersionString;

            SetExtractionTextBoxesDragDrop();
        }

        private void UpdateDescription(string Text)
        {
            DescriptionLabel.Text = $"Description: {Text}";
        }

        private void SetAllPagesStatus(bool Status)
        {
            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = Status;
        }

        private void SetExtractionTextBoxesDragDrop()
        {
            XciPath.AllowDrop       = true;
            XciOutputPath.AllowDrop = true;
            NcaPath.AllowDrop       = true;
            NcaOutputPath.AllowDrop = true;
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming soon...", "Notice.", MessageBoxButtons.OK);
        }

        private void XciExtractionTab_Enter(object sender, EventArgs e)
        {
            UpdateDescription("Extract all XCI contents.");
        }

        private void NcaExtractionTab_Enter(object sender, EventArgs e)
        {
            UpdateDescription("Extract all NCA contents.");
        }

        private void XciExtract_Click(object sender, EventArgs e)
        {
            if (XciPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid XCI path!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (XciOutputPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid XCI output path!", "Error.", MessageBoxButtons.OK);
                return;
            }

            SetAllPagesStatus(false);

            Hactool.RunHactoolCommand($"-k keys.dat -t xci \"{XciPath.Text}\" --outdir=\"{XciOutputPath.Text}\"");

            SetAllPagesStatus(true);

            MessageBox.Show("Done extracting XCI contents!", "Done.", MessageBoxButtons.OK);
        }

        private void NcaExtract_Click(object sender, EventArgs e)
        {
            if (NcaPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid NCA path!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (NcaOutputPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid NCA output path!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (NcaTitleKey.Text != string.Empty)
            {
                if (NcaTitleKey.Text.Length > 32 || NcaTitleKey.Text.Length < 32)
                {
                    MessageBox.Show("Invalid title key!", "Error.", MessageBoxButtons.OK);
                    return;
                }
            }

            SetAllPagesStatus(false);

            if (NcaEmulatorExtract.Checked)
            {
                if (NcaTitleKey.Text != string.Empty)
                {
                    Hactool.RunHactoolCommand($"-k keys.dat --titlekey={NcaTitleKey.Text} \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}\" --romfs=\"{NcaOutputPath.Text}/main.romfs\"");
                }
                else
                {
                    Hactool.RunHactoolCommand($"-k keys.dat \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}\" --romfs=\"{NcaOutputPath.Text}/main.romfs\"");
                }
            }
            else
            {
                if (NcaTitleKey.Text != string.Empty)
                {
                    Hactool.RunHactoolCommand($"-k keys.dat --titlekey={NcaTitleKey.Text} \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}/exefs\" --romfsdir=\"{NcaOutputPath.Text}/romfs\"");
                }
                else
                {
                    Hactool.RunHactoolCommand($"-k keys.dat \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}/exefs\" --romfsdir=\"{NcaOutputPath.Text}/romfs\"");
                }
            }

            SetAllPagesStatus(true);

            MessageBox.Show("Done extracting NCA contents!", "Done.", MessageBoxButtons.OK);
        }

        private void XciBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog XciDialog = new OpenFileDialog()
            {
                Title            = "Browse for XCI file",
                Filter           = "XCI file (*.xci)|*.xci",
                FilterIndex      = 1,
                RestoreDirectory = true
            };

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

        private void NcaBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog NcaDialog = new OpenFileDialog()
            {
                Title            = "Browse for NCA file",
                Filter           = "NCA file (*.nca)|*.nca",
                FilterIndex      = 1,
                RestoreDirectory = true
            };

            if (NcaDialog.ShowDialog() == DialogResult.OK)
            {
                NcaPath.Text = NcaDialog.FileName;
            }
        }

        private void NcaOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog NcaOutputDialog = new FolderBrowserDialog()
            {
                Description  = "Browse for NCA output folder",
                SelectedPath = Application.StartupPath
            };

            if (NcaOutputDialog.ShowDialog() == DialogResult.OK)
            {
                NcaOutputPath.Text = NcaOutputDialog.SelectedPath;
            }
        }

        private void NcaPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void NcaPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                NcaPath.Lines      = FileNames;
            }
        }

        private void NcaOutputPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void NcaOutputPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames  = (string[])e.Data.GetData(DataFormats.FileDrop);
                NcaOutputPath.Lines = FileNames;
            }
        }

        private void XciPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void XciPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                XciPath.Lines      = FileNames;
            }
        }

        private void XciOutputPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void XciOutputPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames  = (string[])e.Data.GetData(DataFormats.FileDrop);
                XciOutputPath.Lines = FileNames;
            }
        }
    }
}
