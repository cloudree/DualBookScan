//
// DualBookScan : Camera Module
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
        // ======== Camera Controls ===========================================

        // UI controls
        private void cbDevices1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                VideoCaptureDevice videoDevice = new VideoCaptureDevice(videoDevices[cbDevices1.SelectedIndex].MonikerString);

                cbResolutions1.Items.Clear();
                videoCapabilities1 = videoDevice.VideoCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities1)
                {
                    cbResolutions1.Items.Add(string.Format("{0} x {1}", capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }
                if (videoCapabilities1.Length == 0)
                {
                    cbResolutions1.Items.Add("Not supported");
                }
                cbResolutions1.SelectedIndex = cbResolutions1.Items.Count - 1;
            }
        }

        private void cbDevices2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                VideoCaptureDevice videoDevice = new VideoCaptureDevice(videoDevices[cbDevices2.SelectedIndex].MonikerString);

                cbResolutions2.Items.Clear();
                videoCapabilities2 = videoDevice.VideoCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities2)
                {
                    cbResolutions2.Items.Add(string.Format("{0} x {1}", capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }
                if (videoCapabilities2.Length == 0)
                {
                    cbResolutions2.Items.Add("Not supported");
                }
                cbResolutions2.SelectedIndex = cbResolutions2.Items.Count - 1;
            }
        }

        private void StartCameras()
        {
            // create first video source
            VideoCaptureDevice videoSource1 = new VideoCaptureDevice(videoDevices[cbDevices1.SelectedIndex].MonikerString);
            videoSource1.VideoResolution = videoCapabilities1[cbResolutions1.SelectedIndex];
            videoSourcePlayer1.VideoSource = videoSource1;
            videoSourcePlayer1.Start();

            // create second video source
            if (cbDevices2.Enabled == true)
            {
                System.Threading.Thread.Sleep(1000);

                VideoCaptureDevice videoSource2 = new VideoCaptureDevice(videoDevices[cbDevices2.SelectedIndex].MonikerString);
                videoSource2.VideoResolution = videoCapabilities2[cbResolutions2.SelectedIndex];
                videoSourcePlayer2.VideoSource = videoSource2;
                videoSourcePlayer2.Start();
            }

            // reset stop watch
            stopWatch = null;
            // start timer
            timer.Start();

            ResizeViewer();
        }

        private void StopCameras()
        {
            timer.Stop();

            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer2.SignalToStop();

            videoSourcePlayer1.WaitForStop();
            videoSourcePlayer2.WaitForStop();
        }

        // On times tick - collect statistics
        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource1 = videoSourcePlayer1.VideoSource;
            IVideoSource videoSource2 = videoSourcePlayer2.VideoSource;

            int framesReceived1 = 0;
            int framesReceived2 = 0;

            // get number of frames for the last second
            if (videoSource1 != null)
            {
                framesReceived1 = videoSource1.FramesReceived;
            }

            if (videoSource2 != null)
            {
                framesReceived2 = videoSource2.FramesReceived;
            }

            if (stopWatch == null)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
            else
            {
                stopWatch.Stop();

                float fps1 = 1000.0f * framesReceived1 / stopWatch.ElapsedMilliseconds;
                float fps2 = 1000.0f * framesReceived2 / stopWatch.ElapsedMilliseconds;

                camera1FpsLabel.Text = fps1.ToString("F2") + " fps";
                camera2FpsLabel.Text = fps2.ToString("F2") + " fps";

                stopWatch.Reset();
                stopWatch.Start();
            }
        }

        // rotate for pages
        private void videoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
        }

        private void videoSourcePlayer2_NewFrame(object sender, ref Bitmap image)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipXY);
        }
    }
}
