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
        
        private void cbDevicesSelectedIndexChanged(int idx)
        {
            if (videoDevices.Count != 0)
            {
                VideoCaptureDevice videoDevice = new VideoCaptureDevice(videoDevices[cbDevices[idx].SelectedIndex].MonikerString);

                cbResolutions[idx].Items.Clear();
                videoCaps[idx] = videoDevice.VideoCapabilities;

                foreach (VideoCapabilities capabilty in videoCaps[idx])
                {
                    cbResolutions[idx].Items.Add(string.Format("{0} x {1}", capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }
                if (videoCaps[idx].Length == 0)
                {
                    cbResolutions[idx].Items.Add("Not supported");
                }
                cbResolutions[idx].SelectedIndex = cbResolutions[idx].Items.Count - 1;
            }
        }

        private void CameraStart(int idx)
        {
            if (cbDevices[idx].Enabled == true)
            {
                VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[cbDevices[idx].SelectedIndex].MonikerString);
                videoSource.VideoResolution = videoCaps[idx][cbResolutions[idx].SelectedIndex];
                videoPlayers[idx].VideoSource = videoSource;
                videoPlayers[idx].Start();
            }
        }

        private void CameraStop(int idx)
        {
            videoPlayers[idx].SignalToStop();
            videoPlayers[idx].WaitForStop();
        }

        private void StartCameras()
        {
            CameraStart(0);
            System.Threading.Thread.Sleep(100);
            CameraStart(1);

            stopWatch = null;
            timer.Start();

            viewerResize(0, this.Size);
            viewerResize(1, this.Size);
        }

        private void StopCameras()
        {
            timer.Stop();
            CameraStop(0);
            CameraStop(1);
        }
    }
}
