// Two Cameras Test sample application
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © AForge.NET, 2006-2011
// contacts@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using AForge.Video;
using AForge.Video.DirectShow;

namespace DualBookScan
{
    public partial class frmMain : Form
    {
        // list of video devices
        private FilterInfoCollection videoDevices;
        private VideoCapabilities[][] videoCaps = new VideoCapabilities[2][];
        private List<AForge.Controls.VideoSourcePlayer> videoPlayers = new List<AForge.Controls.VideoSourcePlayer>();
        private List<NumericUpDown> nudPages = new List<NumericUpDown>();
        private List<ComboBox> cbDevices = new List<ComboBox>();
        private List<ComboBox> cbResolutions = new List<ComboBox>();

        // stop watch for measuring fps
        private Stopwatch stopWatch = null;

        // ======== Common ====================================================
        private int MIN(int a, int b)
        {
            return (a < b) ? a : b;
        }

        private float MIN(float a, float b)
        {
            return (a < b) ? a : b;
        }

        private void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = a;
        }

        // ======== Main Form =================================================
        public frmMain( )
        {
            InitializeComponent( );

            ControlsEnable(true);
            camera1FpsLabel.Text = string.Empty;
            camera2FpsLabel.Text = string.Empty;
            nudPage1.Value = 1;
            nudPage2.Value = 2;
            viewerRectInit();

            // show device list
            //try
            {
                // enumerate video devices
                videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );

                if ( videoDevices.Count == 0 )
                {
                    throw new Exception( );
                }

                for ( int i = 1, n = videoDevices.Count; i <= n; i++ )
                {
                    string cameraName = i + " : " + videoDevices[i - 1].Name;

                    cbDevices[0].Items.Add( cameraName );
                    cbDevices[1].Items.Add( cameraName );
                }

                // check cameras count
                if ( videoDevices.Count == 1 )
                {
                    cbDevices[1].Items.Clear( );

                    cbDevices[1].Items.Add( "Only one camera found" );
                    cbDevices[1].SelectedIndex = 0;
                    cbDevices[1].Enabled = false;
                }
                else
                {
                    cbDevices[1].SelectedIndex = 1;
                }
                cbDevices[0].SelectedIndex = 0;
            }
            /*
            catch
            {
                btnStart.Enabled = false;

                cbDevices1.Items.Add( "No cameras found" );
                cbDevices2.Items.Add( "No cameras found" );

                cbDevices1.SelectedIndex = 0;
                cbDevices2.SelectedIndex = 0;

                cbDevices1.Enabled = false;
                cbDevices2.Enabled = false;
            }
            */
        }

        private new void SuspendLayout()
        {
            videoPlayers.Add(videoSourcePlayer1);
            videoPlayers.Add(videoSourcePlayer2);
            nudPages.Add(nudPage1);
            nudPages.Add(nudPage2);
            cbDevices.Add(cbDevices1);
            cbDevices.Add(cbDevices2);
            cbResolutions.Add(cbResolutions1);
            cbResolutions.Add(cbResolutions2);
        }

        private void ControlsEnable(bool enable)
        {
            btnStart.Enabled = enable;
            btnStop.Enabled = !enable;

            cbDevices1.Enabled = enable;
            cbResolutions1.Enabled = enable;
            cbDevices2.Enabled = enable;
            cbResolutions2.Enabled = enable;

            btnScanLeft.Enabled = !enable;
            btnScanBoth.Enabled = !enable;
            btnScanRight.Enabled = !enable;

            cxPageReversed.Enabled = enable;
        }

        // UI actions
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCameras( );
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartCameras();
            ControlsEnable(false);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCameras();
            ControlsEnable(true);
            camera1FpsLabel.Text = string.Empty;
            camera2FpsLabel.Text = string.Empty;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            viewerResize(0, this.Size);
            viewerResize(1, this.Size);
        }

        private void cbResolutions1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewerResize(0, this.Size);
        }

        private void cbResolutions2_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewerResize(1, this.Size);
        }
        
        private void cbDevices1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDevicesSelectedIndexChanged(0);
        }

        private void cbDevices2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDevicesSelectedIndexChanged(1);
        }

        // rotate for pages
        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            viewerNewFrame(0, ref image);
        }

        private void videoSourcePlayer2_NewFrame(object sender, ref Bitmap image)
        {
            viewerNewFrame(1, ref image);
        }
        
        private void videoSourcePlayer1_MouseDown(object sender, MouseEventArgs e)
        {
            viewerRectBegin(0, e.Location);
            this.Refresh();
        }

        private void videoSourcePlayer1_MouseMove(object sender, MouseEventArgs e)
        {
            viewerRectMove(0, e.Location);
            this.Refresh();
        }

        private void videoSourcePlayer1_MouseUp(object sender, MouseEventArgs e)
        {
            viewerRectEnd(0);
            this.Refresh();
        }

        private void videoSourcePlayer1_MouseLeave(object sender, EventArgs e)
        {
            viewerRectEnd(0);
            this.Refresh();
        }
        
        private void videoSourcePlayer1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            viewerRectDraw(0, grp);
        }

        private void videoSourcePlayer2_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            viewerRectDraw(1, grp);
        }

        private void videoSourcePlayer2_MouseDown(object sender, MouseEventArgs e)
        {
            viewerRectBegin(1, e.Location);
            this.Refresh();
        }

        private void videoSourcePlayer2_MouseMove(object sender, MouseEventArgs e)
        {
            viewerRectMove(1, e.Location);
            this.Refresh();
        }

        private void videoSourcePlayer2_MouseUp(object sender, MouseEventArgs e)
        {
            viewerRectEnd(1);
            this.Refresh();
        }

        private void videoSourcePlayer2_MouseLeave(object sender, EventArgs e)
        {
            viewerRectEnd(1);
            this.Refresh();
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ebFolder.Text = dlgFolderBrowser.SelectedPath;
            }
        }

        private void btnScanLeft_Click(object sender, EventArgs e)
        {
            Scan(0);
            NextPage();
        }

        private void btnScanRight_Click(object sender, EventArgs e)
        {
            Scan(1);
            NextPage();
        }

        private void btnScanBoth_Click(object sender, EventArgs e)
        {
            Scan(0);
            Scan(1);
            NextPage(2);
        }

        private void nudPage1_ValueChanged(object sender, EventArgs e)
        {
            nudPage2.Value = nudPage1.Value + ((cxPageReversed.Checked) ? -1 : 1);
            nudPage2.Refresh();
        }

        private void cxPageReversed_CheckedChanged(object sender, EventArgs e)
        {
            nudPage1.Value = cxPageReversed.Checked ? 2 : 1;
            nudPage1.Refresh();
        }

        private void NextPage(int pages = 1)
        {
            nudPage1.Value += pages;
            nudPage1.Refresh();
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            frmBatch wnd = new frmBatch();
            wnd.ebFolder.Text = ebFolder.Text;
            wnd.Show();
        }
    }
}
