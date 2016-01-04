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

        // viewe resizing
        private void ResizePlayer1(Size sz)
        {
            int center = sz.Width / 2;
            int margin = 5;

            VideoCapabilities cap = videoCapabilities1[cbResolutions1.SelectedIndex];
            videoSourcePlayer1.Size = CalcHalfSize(sz, cap.FrameSize, videoSourcePlayer1.Location.Y, margin, ref ratios[0]);
            videoSourcePlayer1.Location = new Point(center - margin - videoSourcePlayer1.Size.Width, videoSourcePlayer1.Location.Y);
        }

        private void ResizePlayer2(Size sz)
        {
            int center = sz.Width / 2;
            int margin = 5;

            VideoCapabilities cap = videoCapabilities2[cbResolutions2.SelectedIndex];
            videoSourcePlayer2.Size = CalcHalfSize(sz, cap.FrameSize, videoSourcePlayer2.Location.Y, margin, ref ratios[1]);
            videoSourcePlayer2.Location = new Point(center + margin, videoSourcePlayer2.Location.Y);
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

        private void videoSourcePlayer1_Paint(object sender, PaintEventArgs e)
        {
            Graphics grp = e.Graphics;
            viewerRectDraw(0, grp);
        }

        // left scan area
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

        // right scan area
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
    }
}
