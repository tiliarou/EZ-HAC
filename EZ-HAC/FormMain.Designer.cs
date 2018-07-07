namespace EZ_HAC
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.HactoolVersion = new System.Windows.Forms.Label();
            this.HacTab = new System.Windows.Forms.TabControl();
            this.XciExtractionTab = new System.Windows.Forms.TabPage();
            this.XciOutputLabel = new System.Windows.Forms.Label();
            this.XciOutputBrowse = new System.Windows.Forms.Button();
            this.XciOutputPath = new System.Windows.Forms.TextBox();
            this.XciExtract = new System.Windows.Forms.Button();
            this.XciBrowse = new System.Windows.Forms.Button();
            this.XciFileLabel = new System.Windows.Forms.Label();
            this.XciPath = new System.Windows.Forms.TextBox();
            this.NcaExtractionTab = new System.Windows.Forms.TabPage();
            this.NcaTitleKey = new System.Windows.Forms.TextBox();
            this.NcaTitleKeyLabel = new System.Windows.Forms.Label();
            this.NcaOutputLabel = new System.Windows.Forms.Label();
            this.NcaOutputBrowse = new System.Windows.Forms.Button();
            this.NcaOutputPath = new System.Windows.Forms.TextBox();
            this.NcaBrowse = new System.Windows.Forms.Button();
            this.NcaFileLabel = new System.Windows.Forms.Label();
            this.NcaPath = new System.Windows.Forms.TextBox();
            this.NcaEmulatorExtract = new System.Windows.Forms.CheckBox();
            this.NcaExtract = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.HacTab.SuspendLayout();
            this.XciExtractionTab.SuspendLayout();
            this.NcaExtractionTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(12, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(136, 37);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "EZ-HAC";
            // 
            // HactoolVersion
            // 
            this.HactoolVersion.AutoSize = true;
            this.HactoolVersion.Location = new System.Drawing.Point(154, 27);
            this.HactoolVersion.Name = "HactoolVersion";
            this.HactoolVersion.Size = new System.Drawing.Size(83, 13);
            this.HactoolVersion.TabIndex = 3;
            this.HactoolVersion.Text = "hactool Version:";
            // 
            // HacTab
            // 
            this.HacTab.Controls.Add(this.XciExtractionTab);
            this.HacTab.Controls.Add(this.NcaExtractionTab);
            this.HacTab.Location = new System.Drawing.Point(12, 49);
            this.HacTab.Name = "HacTab";
            this.HacTab.SelectedIndex = 0;
            this.HacTab.Size = new System.Drawing.Size(351, 390);
            this.HacTab.TabIndex = 5;
            // 
            // XciExtractionTab
            // 
            this.XciExtractionTab.Controls.Add(this.XciOutputLabel);
            this.XciExtractionTab.Controls.Add(this.XciOutputBrowse);
            this.XciExtractionTab.Controls.Add(this.XciOutputPath);
            this.XciExtractionTab.Controls.Add(this.XciExtract);
            this.XciExtractionTab.Controls.Add(this.XciBrowse);
            this.XciExtractionTab.Controls.Add(this.XciFileLabel);
            this.XciExtractionTab.Controls.Add(this.XciPath);
            this.XciExtractionTab.Location = new System.Drawing.Point(4, 22);
            this.XciExtractionTab.Name = "XciExtractionTab";
            this.XciExtractionTab.Padding = new System.Windows.Forms.Padding(3);
            this.XciExtractionTab.Size = new System.Drawing.Size(343, 364);
            this.XciExtractionTab.TabIndex = 0;
            this.XciExtractionTab.Text = "Extract XCI";
            this.XciExtractionTab.UseVisualStyleBackColor = true;
            this.XciExtractionTab.Enter += new System.EventHandler(this.XciExtractionTab_Enter);
            // 
            // XciOutputLabel
            // 
            this.XciOutputLabel.AutoSize = true;
            this.XciOutputLabel.Location = new System.Drawing.Point(6, 35);
            this.XciOutputLabel.Name = "XciOutputLabel";
            this.XciOutputLabel.Size = new System.Drawing.Size(67, 13);
            this.XciOutputLabel.TabIndex = 6;
            this.XciOutputLabel.Text = "Output Path:";
            // 
            // XciOutputBrowse
            // 
            this.XciOutputBrowse.Location = new System.Drawing.Point(266, 32);
            this.XciOutputBrowse.Name = "XciOutputBrowse";
            this.XciOutputBrowse.Size = new System.Drawing.Size(71, 20);
            this.XciOutputBrowse.TabIndex = 5;
            this.XciOutputBrowse.Text = "Browse";
            this.XciOutputBrowse.UseVisualStyleBackColor = true;
            this.XciOutputBrowse.Click += new System.EventHandler(this.XciOutputBrowse_Click);
            // 
            // XciOutputPath
            // 
            this.XciOutputPath.Location = new System.Drawing.Point(79, 32);
            this.XciOutputPath.Name = "XciOutputPath";
            this.XciOutputPath.Size = new System.Drawing.Size(181, 20);
            this.XciOutputPath.TabIndex = 4;
            this.XciOutputPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.XciOutputPath_DragDrop);
            this.XciOutputPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.XciOutputPath_DragEnter);
            // 
            // XciExtract
            // 
            this.XciExtract.Location = new System.Drawing.Point(3, 323);
            this.XciExtract.Name = "XciExtract";
            this.XciExtract.Size = new System.Drawing.Size(337, 35);
            this.XciExtract.TabIndex = 3;
            this.XciExtract.Text = "Extract";
            this.XciExtract.UseVisualStyleBackColor = true;
            this.XciExtract.Click += new System.EventHandler(this.XciExtract_Click);
            // 
            // XciBrowse
            // 
            this.XciBrowse.Location = new System.Drawing.Point(266, 6);
            this.XciBrowse.Name = "XciBrowse";
            this.XciBrowse.Size = new System.Drawing.Size(71, 20);
            this.XciBrowse.TabIndex = 2;
            this.XciBrowse.Text = "Browse";
            this.XciBrowse.UseVisualStyleBackColor = true;
            this.XciBrowse.Click += new System.EventHandler(this.XciBrowse_Click);
            // 
            // XciFileLabel
            // 
            this.XciFileLabel.AutoSize = true;
            this.XciFileLabel.Location = new System.Drawing.Point(6, 8);
            this.XciFileLabel.Name = "XciFileLabel";
            this.XciFileLabel.Size = new System.Drawing.Size(46, 13);
            this.XciFileLabel.TabIndex = 1;
            this.XciFileLabel.Text = "XCI File:";
            // 
            // XciPath
            // 
            this.XciPath.Location = new System.Drawing.Point(58, 6);
            this.XciPath.Name = "XciPath";
            this.XciPath.Size = new System.Drawing.Size(202, 20);
            this.XciPath.TabIndex = 0;
            this.XciPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.XciPath_DragDrop);
            this.XciPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.XciPath_DragEnter);
            // 
            // NcaExtractionTab
            // 
            this.NcaExtractionTab.Controls.Add(this.NcaTitleKey);
            this.NcaExtractionTab.Controls.Add(this.NcaTitleKeyLabel);
            this.NcaExtractionTab.Controls.Add(this.NcaOutputLabel);
            this.NcaExtractionTab.Controls.Add(this.NcaOutputBrowse);
            this.NcaExtractionTab.Controls.Add(this.NcaOutputPath);
            this.NcaExtractionTab.Controls.Add(this.NcaBrowse);
            this.NcaExtractionTab.Controls.Add(this.NcaFileLabel);
            this.NcaExtractionTab.Controls.Add(this.NcaPath);
            this.NcaExtractionTab.Controls.Add(this.NcaEmulatorExtract);
            this.NcaExtractionTab.Controls.Add(this.NcaExtract);
            this.NcaExtractionTab.Location = new System.Drawing.Point(4, 22);
            this.NcaExtractionTab.Name = "NcaExtractionTab";
            this.NcaExtractionTab.Padding = new System.Windows.Forms.Padding(3);
            this.NcaExtractionTab.Size = new System.Drawing.Size(343, 364);
            this.NcaExtractionTab.TabIndex = 1;
            this.NcaExtractionTab.Text = "Extract NCA";
            this.NcaExtractionTab.UseVisualStyleBackColor = true;
            this.NcaExtractionTab.Enter += new System.EventHandler(this.NcaExtractionTab_Enter);
            // 
            // NcaTitleKey
            // 
            this.NcaTitleKey.Location = new System.Drawing.Point(111, 58);
            this.NcaTitleKey.Name = "NcaTitleKey";
            this.NcaTitleKey.Size = new System.Drawing.Size(226, 20);
            this.NcaTitleKey.TabIndex = 14;
            // 
            // NcaTitleKeyLabel
            // 
            this.NcaTitleKeyLabel.AutoSize = true;
            this.NcaTitleKeyLabel.Location = new System.Drawing.Point(6, 61);
            this.NcaTitleKeyLabel.Name = "NcaTitleKeyLabel";
            this.NcaTitleKeyLabel.Size = new System.Drawing.Size(99, 13);
            this.NcaTitleKeyLabel.TabIndex = 13;
            this.NcaTitleKeyLabel.Text = "Title Key (Optional):";
            // 
            // NcaOutputLabel
            // 
            this.NcaOutputLabel.AutoSize = true;
            this.NcaOutputLabel.Location = new System.Drawing.Point(6, 35);
            this.NcaOutputLabel.Name = "NcaOutputLabel";
            this.NcaOutputLabel.Size = new System.Drawing.Size(67, 13);
            this.NcaOutputLabel.TabIndex = 12;
            this.NcaOutputLabel.Text = "Output Path:";
            // 
            // NcaOutputBrowse
            // 
            this.NcaOutputBrowse.Location = new System.Drawing.Point(266, 32);
            this.NcaOutputBrowse.Name = "NcaOutputBrowse";
            this.NcaOutputBrowse.Size = new System.Drawing.Size(71, 20);
            this.NcaOutputBrowse.TabIndex = 11;
            this.NcaOutputBrowse.Text = "Browse";
            this.NcaOutputBrowse.UseVisualStyleBackColor = true;
            this.NcaOutputBrowse.Click += new System.EventHandler(this.NcaOutputBrowse_Click);
            // 
            // NcaOutputPath
            // 
            this.NcaOutputPath.Location = new System.Drawing.Point(79, 32);
            this.NcaOutputPath.Name = "NcaOutputPath";
            this.NcaOutputPath.Size = new System.Drawing.Size(181, 20);
            this.NcaOutputPath.TabIndex = 10;
            this.NcaOutputPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.NcaOutputPath_DragDrop);
            this.NcaOutputPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.NcaOutputPath_DragEnter);
            // 
            // NcaBrowse
            // 
            this.NcaBrowse.Location = new System.Drawing.Point(266, 6);
            this.NcaBrowse.Name = "NcaBrowse";
            this.NcaBrowse.Size = new System.Drawing.Size(71, 20);
            this.NcaBrowse.TabIndex = 9;
            this.NcaBrowse.Text = "Browse";
            this.NcaBrowse.UseVisualStyleBackColor = true;
            this.NcaBrowse.Click += new System.EventHandler(this.NcaBrowse_Click);
            // 
            // NcaFileLabel
            // 
            this.NcaFileLabel.AutoSize = true;
            this.NcaFileLabel.Location = new System.Drawing.Point(6, 8);
            this.NcaFileLabel.Name = "NcaFileLabel";
            this.NcaFileLabel.Size = new System.Drawing.Size(51, 13);
            this.NcaFileLabel.TabIndex = 8;
            this.NcaFileLabel.Text = "NCA File:";
            // 
            // NcaPath
            // 
            this.NcaPath.Location = new System.Drawing.Point(63, 6);
            this.NcaPath.Name = "NcaPath";
            this.NcaPath.Size = new System.Drawing.Size(197, 20);
            this.NcaPath.TabIndex = 7;
            this.NcaPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.NcaPath_DragDrop);
            this.NcaPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.NcaPath_DragEnter);
            // 
            // NcaEmulatorExtract
            // 
            this.NcaEmulatorExtract.AutoSize = true;
            this.NcaEmulatorExtract.Location = new System.Drawing.Point(6, 300);
            this.NcaEmulatorExtract.Name = "NcaEmulatorExtract";
            this.NcaEmulatorExtract.Size = new System.Drawing.Size(118, 17);
            this.NcaEmulatorExtract.TabIndex = 5;
            this.NcaEmulatorExtract.Text = "Extract for Emulator";
            this.NcaEmulatorExtract.UseVisualStyleBackColor = true;
            // 
            // NcaExtract
            // 
            this.NcaExtract.Location = new System.Drawing.Point(3, 323);
            this.NcaExtract.Name = "NcaExtract";
            this.NcaExtract.Size = new System.Drawing.Size(337, 35);
            this.NcaExtract.TabIndex = 4;
            this.NcaExtract.Text = "Extract";
            this.NcaExtract.UseVisualStyleBackColor = true;
            this.NcaExtract.Click += new System.EventHandler(this.NcaExtract_Click);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(9, 443);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(66, 13);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Description: ";
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(288, 13);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(75, 23);
            this.SettingsButton.TabIndex = 8;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 463);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.HacTab);
            this.Controls.Add(this.HactoolVersion);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "EZ-HAC - Another hactool GUI!";
            this.HacTab.ResumeLayout(false);
            this.XciExtractionTab.ResumeLayout(false);
            this.XciExtractionTab.PerformLayout();
            this.NcaExtractionTab.ResumeLayout(false);
            this.NcaExtractionTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label HactoolVersion;
        private System.Windows.Forms.TabControl HacTab;
        private System.Windows.Forms.TabPage XciExtractionTab;
        private System.Windows.Forms.TabPage NcaExtractionTab;
        private System.Windows.Forms.Label XciFileLabel;
        private System.Windows.Forms.TextBox XciPath;
        private System.Windows.Forms.Button XciBrowse;
        private System.Windows.Forms.Button XciExtract;
        private System.Windows.Forms.Label XciOutputLabel;
        private System.Windows.Forms.Button XciOutputBrowse;
        private System.Windows.Forms.TextBox XciOutputPath;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.CheckBox NcaEmulatorExtract;
        private System.Windows.Forms.Button NcaExtract;
        private System.Windows.Forms.Label NcaOutputLabel;
        private System.Windows.Forms.Button NcaOutputBrowse;
        private System.Windows.Forms.TextBox NcaOutputPath;
        private System.Windows.Forms.Button NcaBrowse;
        private System.Windows.Forms.Label NcaFileLabel;
        private System.Windows.Forms.TextBox NcaPath;
        private System.Windows.Forms.TextBox NcaTitleKey;
        private System.Windows.Forms.Label NcaTitleKeyLabel;
        private System.Windows.Forms.Button SettingsButton;
    }
}

