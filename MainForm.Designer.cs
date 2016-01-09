namespace DualBookScan
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.camera1FpsLabel = new System.Windows.Forms.Label();
            this.cbDevices1 = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.camera2FpsLabel = new System.Windows.Forms.Label();
            this.cbDevices2 = new System.Windows.Forms.ComboBox();
            this.videoSourcePlayer2 = new AForge.Controls.VideoSourcePlayer();
            this.cbResolutions1 = new System.Windows.Forms.ComboBox();
            this.cbResolutions2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ebFolder = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnScanBoth = new System.Windows.Forms.Button();
            this.btnScanRight = new System.Windows.Forms.Button();
            this.btnScanLeft = new System.Windows.Forms.Button();
            this.nudPage1 = new System.Windows.Forms.NumericUpDown();
            this.nudPage2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.cxPageReversed = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // camera1FpsLabel
            // 
            this.camera1FpsLabel.Location = new System.Drawing.Point(217, 56);
            this.camera1FpsLabel.Name = "camera1FpsLabel";
            this.camera1FpsLabel.Size = new System.Drawing.Size(89, 16);
            this.camera1FpsLabel.TabIndex = 4;
            this.camera1FpsLabel.Text = "label1";
            this.camera1FpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDevices1
            // 
            this.cbDevices1.FormattingEnabled = true;
            this.cbDevices1.Location = new System.Drawing.Point(11, 56);
            this.cbDevices1.Name = "cbDevices1";
            this.cbDevices1.Size = new System.Drawing.Size(200, 20);
            this.cbDevices1.TabIndex = 7;
            this.cbDevices1.SelectedIndexChanged += new System.EventHandler(this.cbDevices1_SelectedIndexChanged);
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer1.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(11, 108);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(500, 472);
            this.videoSourcePlayer1.TabIndex = 6;
            this.videoSourcePlayer1.VideoSource = null;
            this.videoSourcePlayer1.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer1_NewFrame);
            this.videoSourcePlayer1.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer1_Paint);
            this.videoSourcePlayer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseDown);
            this.videoSourcePlayer1.MouseLeave += new System.EventHandler(this.videoSourcePlayer1_MouseLeave);
            this.videoSourcePlayer1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseMove);
            this.videoSourcePlayer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer1_MouseUp);
            // 
            // camera2FpsLabel
            // 
            this.camera2FpsLabel.Location = new System.Drawing.Point(582, 57);
            this.camera2FpsLabel.Name = "camera2FpsLabel";
            this.camera2FpsLabel.Size = new System.Drawing.Size(89, 16);
            this.camera2FpsLabel.TabIndex = 10;
            this.camera2FpsLabel.Text = "label2";
            this.camera2FpsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDevices2
            // 
            this.cbDevices2.FormattingEnabled = true;
            this.cbDevices2.Location = new System.Drawing.Point(376, 56);
            this.cbDevices2.Name = "cbDevices2";
            this.cbDevices2.Size = new System.Drawing.Size(200, 20);
            this.cbDevices2.TabIndex = 9;
            this.cbDevices2.SelectedIndexChanged += new System.EventHandler(this.cbDevices2_SelectedIndexChanged);
            // 
            // videoSourcePlayer2
            // 
            this.videoSourcePlayer2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer2.ForeColor = System.Drawing.Color.White;
            this.videoSourcePlayer2.Location = new System.Drawing.Point(517, 108);
            this.videoSourcePlayer2.Name = "videoSourcePlayer2";
            this.videoSourcePlayer2.Size = new System.Drawing.Size(500, 472);
            this.videoSourcePlayer2.TabIndex = 8;
            this.videoSourcePlayer2.VideoSource = null;
            this.videoSourcePlayer2.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.videoSourcePlayer2_NewFrame);
            this.videoSourcePlayer2.Paint += new System.Windows.Forms.PaintEventHandler(this.videoSourcePlayer2_Paint);
            this.videoSourcePlayer2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer2_MouseDown);
            this.videoSourcePlayer2.MouseLeave += new System.EventHandler(this.videoSourcePlayer2_MouseLeave);
            this.videoSourcePlayer2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer2_MouseMove);
            this.videoSourcePlayer2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSourcePlayer2_MouseUp);
            // 
            // cbResolutions1
            // 
            this.cbResolutions1.FormattingEnabled = true;
            this.cbResolutions1.Location = new System.Drawing.Point(11, 82);
            this.cbResolutions1.Name = "cbResolutions1";
            this.cbResolutions1.Size = new System.Drawing.Size(200, 20);
            this.cbResolutions1.TabIndex = 11;
            this.cbResolutions1.SelectedIndexChanged += new System.EventHandler(this.cbResolutions1_SelectedIndexChanged);
            // 
            // cbResolutions2
            // 
            this.cbResolutions2.FormattingEnabled = true;
            this.cbResolutions2.Location = new System.Drawing.Point(376, 82);
            this.cbResolutions2.Name = "cbResolutions2";
            this.cbResolutions2.Size = new System.Drawing.Size(200, 20);
            this.cbResolutions2.TabIndex = 12;
            this.cbResolutions2.SelectedIndexChanged += new System.EventHandler(this.cbResolutions2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "Output Folder :";
            // 
            // ebFolder
            // 
            this.ebFolder.Location = new System.Drawing.Point(710, 22);
            this.ebFolder.Name = "ebFolder";
            this.ebFolder.Size = new System.Drawing.Size(242, 21);
            this.ebFolder.TabIndex = 14;
            this.ebFolder.Text = "C:\\TEMP";
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(958, 21);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(37, 23);
            this.btnFolder.TabIndex = 15;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // btnScanBoth
            // 
            this.btnScanBoth.Location = new System.Drawing.Point(376, 12);
            this.btnScanBoth.Name = "btnScanBoth";
            this.btnScanBoth.Size = new System.Drawing.Size(109, 38);
            this.btnScanBoth.TabIndex = 16;
            this.btnScanBoth.Text = "Scan Both";
            this.btnScanBoth.UseVisualStyleBackColor = true;
            this.btnScanBoth.Click += new System.EventHandler(this.btnScanBoth_Click);
            // 
            // btnScanRight
            // 
            this.btnScanRight.Location = new System.Drawing.Point(491, 12);
            this.btnScanRight.Name = "btnScanRight";
            this.btnScanRight.Size = new System.Drawing.Size(109, 38);
            this.btnScanRight.TabIndex = 17;
            this.btnScanRight.Text = "Scan Right";
            this.btnScanRight.UseVisualStyleBackColor = true;
            this.btnScanRight.Click += new System.EventHandler(this.btnScanRight_Click);
            // 
            // btnScanLeft
            // 
            this.btnScanLeft.Location = new System.Drawing.Point(261, 12);
            this.btnScanLeft.Name = "btnScanLeft";
            this.btnScanLeft.Size = new System.Drawing.Size(109, 38);
            this.btnScanLeft.TabIndex = 18;
            this.btnScanLeft.Text = "Scan Left";
            this.btnScanLeft.UseVisualStyleBackColor = true;
            this.btnScanLeft.Click += new System.EventHandler(this.btnScanLeft_Click);
            // 
            // nudPage1
            // 
            this.nudPage1.Location = new System.Drawing.Point(261, 81);
            this.nudPage1.Name = "nudPage1";
            this.nudPage1.Size = new System.Drawing.Size(60, 21);
            this.nudPage1.TabIndex = 19;
            this.nudPage1.ValueChanged += new System.EventHandler(this.nudPage1_ValueChanged);
            // 
            // nudPage2
            // 
            this.nudPage2.Location = new System.Drawing.Point(626, 81);
            this.nudPage2.Name = "nudPage2";
            this.nudPage2.Size = new System.Drawing.Size(60, 21);
            this.nudPage2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Page:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(582, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Page:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(136, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(119, 38);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "Cameras Off";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(11, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 38);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Cameras On";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cxPageReversed
            // 
            this.cxPageReversed.AutoSize = true;
            this.cxPageReversed.Location = new System.Drawing.Point(728, 84);
            this.cxPageReversed.Name = "cxPageReversed";
            this.cxPageReversed.Size = new System.Drawing.Size(106, 16);
            this.cxPageReversed.TabIndex = 25;
            this.cxPageReversed.Text = "PageReversed";
            this.cxPageReversed.UseVisualStyleBackColor = true;
            this.cxPageReversed.CheckedChanged += new System.EventHandler(this.cxPageReversed_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1029, 591);
            this.Controls.Add(this.cxPageReversed);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudPage2);
            this.Controls.Add(this.nudPage1);
            this.Controls.Add(this.btnScanLeft);
            this.Controls.Add(this.btnScanRight);
            this.Controls.Add(this.btnScanBoth);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.ebFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbResolutions2);
            this.Controls.Add(this.cbResolutions1);
            this.Controls.Add(this.camera2FpsLabel);
            this.Controls.Add(this.cbDevices2);
            this.Controls.Add(this.videoSourcePlayer2);
            this.Controls.Add(this.camera1FpsLabel);
            this.Controls.Add(this.cbDevices1);
            this.Controls.Add(this.videoSourcePlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Dual Book Scan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudPage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPage2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer2;
        private System.Windows.Forms.ComboBox cbDevices2;
        private System.Windows.Forms.Label camera2FpsLabel;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.ComboBox cbDevices1;
        private System.Windows.Forms.Label camera1FpsLabel;
        private System.Windows.Forms.ComboBox cbResolutions1;
        private System.Windows.Forms.ComboBox cbResolutions2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ebFolder;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.Button btnScanBoth;
        private System.Windows.Forms.Button btnScanRight;
        private System.Windows.Forms.Button btnScanLeft;
        private System.Windows.Forms.NumericUpDown nudPage1;
        private System.Windows.Forms.NumericUpDown nudPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cxPageReversed;
    }
}

