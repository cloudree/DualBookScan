//
// DualBookScan : Viewer Module
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
    public partial class frmMain
    {
        // ======== Viewer ====================================================
        private bool[] isMouseDowned = new bool[2];
        private Rectangle[] rect = new Rectangle[2];
        private float[] ratios = new float[2];

        // viewer resizing
        private void viewerResize(int idx, Size sz)
        {
            int center = sz.Width / 2;
            int margin = 5;

            if (videoCaps[idx] != null)
            {
                VideoCapabilities cap = videoCaps[idx][cbResolutions[idx].SelectedIndex];
                videoPlayers[idx].Size = CalcHalfSize(sz, cap.FrameSize, videoPlayers[idx].Location.Y, margin, ref ratios[idx]);
                if (idx == 0)
                    videoPlayers[idx].Location = new Point(center - margin - videoPlayers[idx].Size.Width, videoPlayers[0].Location.Y);
                else
                    videoPlayers[idx].Location = new Point(center + margin, videoPlayers[idx].Location.Y);
            }
        }

        private Size CalcHalfSize(Size sz1, Size sz2, int top, int margin, ref float ratio)
        {
            // area size
            int wm = sz1.Width / 2 - margin * 2;
            int hm = sz1.Height - margin * 2 - top - 50;

            // get small constraint                                 // rotate
            float wr = MIN(wm, sz2.Width) / (float)sz2.Height;      // Width;
            float hr = MIN(hm, sz2.Height) / (float)sz2.Width;      // Height;
            ratio = MIN(wr, hr);

            return new Size((int)(sz2.Height * ratio), (int)(sz2.Width * ratio));
        }

        private void viewerNewFrame(int idx, ref Bitmap image)
        {
            switch (idx)
            {
                case 0:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 1:
                    image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    break;
            }
        }

        // selection rect
        private void viewerRectInit()
        {
            for (int i = 0; i < 2; i++)
            {
                rect[i] = new Rectangle(100, 100, 300, 400);
                isMouseDowned[i] = false;
            }
        }

        private void viewerRectDraw(int idx, Graphics grp)
        {
            Pen pen = Pens.Black;
            int x = rect[idx].Location.X;
            int y = rect[idx].Location.Y;
            int w = rect[idx].Size.Width;
            int h = rect[idx].Size.Height;

            if (w < 0)
            {
                x += w;
                w = -w;
            }
            if (h < 0)
            {
                y += h;
                h = -h;
            }
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            rect[idx].Location = new Point(x, y);
            rect[idx].Size = new Size(w, h);

            grp.DrawRectangle(pen, rect[idx]);
        }

        private void viewerRectBegin(int idx, Point pt)
        {
            isMouseDowned[idx] = true;
            rect[idx].Location = pt;
        }

        private void viewerRectMove(int idx, Point pt)
        {
            if (isMouseDowned[idx])
            {
                rect[idx].Size = new Size(pt.X - rect[idx].Location.X, pt.Y - rect[idx].Location.Y);
            }
        }

        private void viewerRectEnd(int idx)
        {
            isMouseDowned[idx] = false;
        }
        
        // On times tick - collect statistics
        private int getFrameCount(int idx)
        {
            IVideoSource videoSource = videoPlayers[idx].VideoSource;
            return (videoSource != null) ? videoSource.FramesReceived : 0;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (stopWatch == null)
            {
                stopWatch = new Stopwatch();
                stopWatch.Start();
            }
            else
            {
                stopWatch.Stop();

                float fps1 = 1000.0f * getFrameCount(0) / stopWatch.ElapsedMilliseconds;
                float fps2 = 1000.0f * getFrameCount(1) / stopWatch.ElapsedMilliseconds;

                camera1FpsLabel.Text = fps1.ToString("F2") + " fps";
                camera2FpsLabel.Text = fps2.ToString("F2") + " fps";

                stopWatch.Reset();
                stopWatch.Start();
            }
        }
    }
}
