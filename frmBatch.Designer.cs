namespace DualBookScan
{
    partial class frmBatch
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
            this.ebFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFolder = new System.Windows.Forms.Button();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btnConvertJPG = new System.Windows.Forms.Button();
            this.btnCollectPDF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudBright = new System.Windows.Forms.NumericUpDown();
            this.nudContrast = new System.Windows.Forms.NumericUpDown();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.chkBrightAuto = new System.Windows.Forms.CheckBox();
            this.chkContrastAuto = new System.Windows.Forms.CheckBox();
            this.btnFolderRefresh = new System.Windows.Forms.Button();
            this.chkGray = new System.Windows.Forms.CheckBox();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.nudBright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // ebFolder
            // 
            this.ebFolder.Location = new System.Drawing.Point(66, 12);
            this.ebFolder.Name = "ebFolder";
            this.ebFolder.ReadOnly = true;
            this.ebFolder.Size = new System.Drawing.Size(213, 21);
            this.ebFolder.TabIndex = 0;
            this.ebFolder.Text = "C:\\Temp";
            this.ebFolder.TextChanged += new System.EventHandler(this.ebFolder_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder :";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(285, 12);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(32, 21);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.ItemHeight = 12;
            this.lbFiles.Location = new System.Drawing.Point(15, 39);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFiles.Size = new System.Drawing.Size(332, 520);
            this.lbFiles.TabIndex = 3;
            this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_SelectedIndexChanged);
            // 
            // btnConvertJPG
            // 
            this.btnConvertJPG.Location = new System.Drawing.Point(476, 114);
            this.btnConvertJPG.Name = "btnConvertJPG";
            this.btnConvertJPG.Size = new System.Drawing.Size(129, 30);
            this.btnConvertJPG.TabIndex = 4;
            this.btnConvertJPG.Text = "Convert to .JPG";
            this.btnConvertJPG.UseVisualStyleBackColor = true;
            this.btnConvertJPG.Click += new System.EventHandler(this.btnConvertJPG_Click);
            // 
            // btnCollectPDF
            // 
            this.btnCollectPDF.Location = new System.Drawing.Point(353, 529);
            this.btnCollectPDF.Name = "btnCollectPDF";
            this.btnCollectPDF.Size = new System.Drawing.Size(252, 30);
            this.btnCollectPDF.TabIndex = 6;
            this.btnCollectPDF.Text = "Collect to .PDF ...";
            this.btnCollectPDF.UseVisualStyleBackColor = true;
            this.btnCollectPDF.Click += new System.EventHandler(this.btnCollectPDF_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Brightness";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Contrast";
            // 
            // nudBright
            // 
            this.nudBright.Enabled = false;
            this.nudBright.Location = new System.Drawing.Point(476, 60);
            this.nudBright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBright.Name = "nudBright";
            this.nudBright.Size = new System.Drawing.Size(50, 21);
            this.nudBright.TabIndex = 11;
            this.nudBright.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudBright.ValueChanged += new System.EventHandler(this.nudBright_ValueChanged);
            // 
            // nudContrast
            // 
            this.nudContrast.Enabled = false;
            this.nudContrast.Location = new System.Drawing.Point(476, 87);
            this.nudContrast.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudContrast.Name = "nudContrast";
            this.nudContrast.Size = new System.Drawing.Size(50, 21);
            this.nudContrast.TabIndex = 12;
            this.nudContrast.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nudContrast.ValueChanged += new System.EventHandler(this.nudContrast_ValueChanged);
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(353, 187);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(252, 324);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPreview.TabIndex = 18;
            this.pbPreview.TabStop = false;
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(353, 165);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(199, 16);
            this.chkAuto.TabIndex = 19;
            this.chkAuto.Text = "Apply Automatically to Preview";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(556, 162);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(49, 21);
            this.btnApply.TabIndex = 20;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // chkBrightAuto
            // 
            this.chkBrightAuto.AutoSize = true;
            this.chkBrightAuto.Checked = true;
            this.chkBrightAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBrightAuto.Location = new System.Drawing.Point(422, 63);
            this.chkBrightAuto.Name = "chkBrightAuto";
            this.chkBrightAuto.Size = new System.Drawing.Size(48, 16);
            this.chkBrightAuto.TabIndex = 21;
            this.chkBrightAuto.Text = "auto";
            this.chkBrightAuto.UseVisualStyleBackColor = true;
            this.chkBrightAuto.CheckedChanged += new System.EventHandler(this.chkBrightAuto_CheckedChanged);
            // 
            // chkContrastAuto
            // 
            this.chkContrastAuto.AutoSize = true;
            this.chkContrastAuto.Checked = true;
            this.chkContrastAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContrastAuto.Location = new System.Drawing.Point(422, 88);
            this.chkContrastAuto.Name = "chkContrastAuto";
            this.chkContrastAuto.Size = new System.Drawing.Size(48, 16);
            this.chkContrastAuto.TabIndex = 22;
            this.chkContrastAuto.Text = "auto";
            this.chkContrastAuto.UseVisualStyleBackColor = true;
            this.chkContrastAuto.CheckedChanged += new System.EventHandler(this.chkContrastAuto_CheckedChanged);
            // 
            // btnFolderRefresh
            // 
            this.btnFolderRefresh.Location = new System.Drawing.Point(323, 12);
            this.btnFolderRefresh.Name = "btnFolderRefresh";
            this.btnFolderRefresh.Size = new System.Drawing.Size(22, 21);
            this.btnFolderRefresh.TabIndex = 23;
            this.btnFolderRefresh.Text = "!";
            this.btnFolderRefresh.UseVisualStyleBackColor = true;
            this.btnFolderRefresh.Click += new System.EventHandler(this.btnFolderRefresh_Click);
            // 
            // chkGray
            // 
            this.chkGray.AutoSize = true;
            this.chkGray.Checked = true;
            this.chkGray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGray.Location = new System.Drawing.Point(353, 36);
            this.chkGray.Name = "chkGray";
            this.chkGray.Size = new System.Drawing.Size(82, 16);
            this.chkGray.TabIndex = 24;
            this.chkGray.Text = "Grayscale";
            this.chkGray.UseVisualStyleBackColor = true;
            this.chkGray.CheckedChanged += new System.EventHandler(this.chkGray_CheckedChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 565);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(590, 20);
            this.progressBar.TabIndex = 25;
            // 
            // frmBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 594);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.chkGray);
            this.Controls.Add(this.btnFolderRefresh);
            this.Controls.Add(this.chkContrastAuto);
            this.Controls.Add(this.chkBrightAuto);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.pbPreview);
            this.Controls.Add(this.nudContrast);
            this.Controls.Add(this.nudBright);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCollectPDF);
            this.Controls.Add(this.btnConvertJPG);
            this.Controls.Add(this.lbFiles);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ebFolder);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBatch";
            this.Text = "Batch Conversions";
            ((System.ComponentModel.ISupportInitialize)(this.nudBright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btnConvertJPG;
        private System.Windows.Forms.Button btnCollectPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudBright;
        private System.Windows.Forms.NumericUpDown nudContrast;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox chkBrightAuto;
        private System.Windows.Forms.CheckBox chkContrastAuto;
        private System.Windows.Forms.Button btnFolderRefresh;
        private System.Windows.Forms.CheckBox chkGray;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.TextBox ebFolder;
    }
}