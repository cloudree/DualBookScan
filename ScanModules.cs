//
// DualBookScan : Scanning Module
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
        // ======== Scanning ==================================================
        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ebFolder.Text = dlgFolderBrowser.SelectedPath;
            }
        }

        private void btnScanLeft_Click(object sender, EventArgs e)
        {
            Scan1();
            nudPage1.Value++;
            nudPage1.Refresh();
        }

        private void btnScanRight_Click(object sender, EventArgs e)
        {
            Scan2();
            nudPage1.Value++;
            nudPage1.Refresh();
        }

        private void btnScanBoth_Click(object sender, EventArgs e)
        {
            Scan1();
            Scan2();
            nudPage1.Value += 2;
            nudPage1.Refresh();
        }

        private void nudPage1_ValueChanged(object sender, EventArgs e)
        {
            if (cxPageReversed.Checked)
                nudPage2.Value = nudPage1.Value + 1;
            else
                nudPage2.Value = nudPage1.Value - 1;
            nudPage2.Refresh();
        }

        private void cxPageReversed_CheckedChanged(object sender, EventArgs e)
        {
            nudPage1.Value = cxPageReversed.Checked ? 0 : 1;
            nudPage1.Refresh();
        }

        private Rectangle RectResize(Rectangle rt, float ratio)
        {
            int x = (int)(rt.Location.X / ratio);
            int y = (int)(rt.Location.Y / ratio);
            int w = (int)(rt.Size.Width / ratio);
            int h = (int)(rt.Size.Height / ratio);
            return new Rectangle(x, y, w, h);
        }

        private Bitmap CropImage(Bitmap source, Rectangle rt)
        {
            Bitmap bmp = new Bitmap(rt.Size.Width, rt.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, 0, 0, rt, GraphicsUnit.Pixel);
            return bmp;
        }

        private void Scan1()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String fileName;
                fileName = String.Format("{0}\\{1,6:000000}.png", ebFolder.Text, nudPage1.Value);

                Rectangle rt = RectResize(rect[0], ratios[0]);
                
                Bitmap bmp = videoSourcePlayer1.GetCurrentVideoFrame();
                Bitmap sub = CropImage(bmp, rt);
                sub.Save(fileName, ImageFormat.Png);
                sub.Dispose();
                bmp.Dispose();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Scan2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                String fileName;
                fileName = String.Format("{0}\\{1,6:000000}.png", ebFolder.Text, nudPage2.Value);

                Rectangle rt = RectResize(rect[1], ratios[1]);

                Bitmap bmp = videoSourcePlayer2.GetCurrentVideoFrame();
                Bitmap sub = CropImage(bmp, rt);
                sub.Save(fileName, ImageFormat.Png);
                sub.Dispose();
                bmp.Dispose();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
