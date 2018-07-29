using System;
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

            SetTextBoxesDragDrop();
        }

        private void UpdateDescription(string Text)
        {
            DescriptionLabel.Text = $"Description: {Text}";
        }

        private void SetAllPagesStatus(bool Status)
        {
            foreach (TabPage Page in HacTab.TabPages) Page.Enabled = Status;
        }

        private void SetTextBoxesDragDrop()
        {
            XciPath.AllowDrop         = true;
            XciOutputPath.AllowDrop   = true;
            NcaPath.AllowDrop         = true;
            NcaOutputPath.AllowDrop   = true;
            RomFsPath.AllowDrop       = true;
            RomFsOutputPath.AllowDrop = true;
        }

        private void ActionCompleted()
        {
            MessageBox.Show("Action completed!", "Done.", MessageBoxButtons.OK);
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

        private void RomFsExtractionTab_Enter(object sender, EventArgs e)
        {
            UpdateDescription("Extract all RomFS contents.");
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

            Hactool.RunCommand($"-k keys.dat -t xci \"{XciPath.Text}\" --outdir=\"{XciOutputPath.Text}\"");

            SetAllPagesStatus(true);

            ActionCompleted();
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
                    Hactool.RunCommand($"-k keys.dat --titlekey={NcaTitleKey.Text} \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}\" --romfs=\"{NcaOutputPath.Text}/main.romfs\"");
                }
                else
                {
                    Hactool.RunCommand($"-k keys.dat \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}\" --romfs=\"{NcaOutputPath.Text}/main.romfs\"");
                }
            }
            else
            {
                if (NcaTitleKey.Text != string.Empty)
                {
                    Hactool.RunCommand($"-k keys.dat --titlekey={NcaTitleKey.Text} \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}/exefs\" --romfsdir=\"{NcaOutputPath.Text}/romfs\"");
                }
                else
                {
                    Hactool.RunCommand($"-k keys.dat \"{NcaPath.Text}\" --section0dir=\"{NcaOutputPath.Text}/exefs\" --romfsdir=\"{NcaOutputPath.Text}/romfs\"");
                }
            }

            SetAllPagesStatus(true);

            ActionCompleted();
        }

        private void RomFsExtract_Click(object sender, EventArgs e)
        {
            if (RomFsPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid RomFS path!", "Error.", MessageBoxButtons.OK);
                return;
            }
            else if (RomFsOutputPath.Text == string.Empty)
            {
                MessageBox.Show("Invalid RomFS output path!", "Error.", MessageBoxButtons.OK);
                return;
            }

            SetAllPagesStatus(false);

            Hactool.RunCommand($"-t romfs \"{RomFsPath.Text}\" --romfsdir=\"{RomFsOutputPath.Text}\"");

            SetAllPagesStatus(true);

            ActionCompleted();
        }

        private void XciBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog XciDialog = new OpenFileDialog()
            {
                Title            = "Browse for XCI file",
                Filter           = "XCI File (*.xci)|*.xci",
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
                Filter           = "NCA File (*.nca)|*.nca",
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

        private void RomFsBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog RomFsDialog = new OpenFileDialog()
            {
                Title            = "Browse for RomFS file",
                Filter           = "RomFS Files (*.romfs, *.istorage)|*.romfs;*.istorage",
                FilterIndex      = 1,
                RestoreDirectory = true
            };

            if (RomFsDialog.ShowDialog() == DialogResult.OK)
            {
                RomFsPath.Text = RomFsDialog.FileName;
            }
        }

        private void RomFsOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog RomFsOutputDialog = new FolderBrowserDialog()
            {
                Description  = "Browse for RomFS output folder",
                SelectedPath = Application.StartupPath
            };

            if (RomFsOutputDialog.ShowDialog() == DialogResult.OK)
            {
                RomFsOutputPath.Text = RomFsOutputDialog.SelectedPath;
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

        private void RomFsPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void RomFsPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames = (string[])e.Data.GetData(DataFormats.FileDrop);
                RomFsPath.Lines    = FileNames;
            }
        }

        private void RomFsOutputPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void RomFsOutputPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileNames    = (string[])e.Data.GetData(DataFormats.FileDrop);
                RomFsOutputPath.Lines = FileNames;
            }
        }
    }
}
