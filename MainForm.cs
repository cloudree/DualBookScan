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
        private VideoCapabilities[] videoCapabilities1;
        private VideoCapabilities[] videoCapabilities2;

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
            nudPage2.Value = 0;     // right page is first page
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

                    cbDevices1.Items.Add( cameraName );
                    cbDevices2.Items.Add( cameraName );
                }

                // check cameras count
                if ( videoDevices.Count == 1 )
                {
                    cbDevices2.Items.Clear( );

                    cbDevices2.Items.Add( "Only one camera found" );
                    cbDevices2.SelectedIndex = 0;
                    cbDevices2.Enabled = false;
                }
                else
                {
                    cbDevices2.SelectedIndex = 1;
                }
                cbDevices1.SelectedIndex = 0;
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

        private void ControlsEnable( bool enable )
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

        private void frmMain_Resize(object sender, EventArgs e)
        {
            ResizeViewer();
        }

        private void cbResolutions1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeViewer();
        }

        private void cbResolutions2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResizeViewer();
        }

        private void ResizeViewer()
        {
            if (videoCapabilities1 != null)
            {
                ResizePlayer1(this.Size);
            }

            if (videoCapabilities2 != null)
            {
                ResizePlayer2(this.Size);
            }
        }
    }
}
