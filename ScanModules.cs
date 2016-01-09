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

        private void Scan(int idx)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String fileName;
                fileName = String.Format("{0}\\{1,6:000000}.png", ebFolder.Text, nudPages[idx].Value);

                Rectangle rt = RectResize(rect[idx], ratios[idx]);
                
                Bitmap bmp = videoPlayers[idx].GetCurrentVideoFrame();
                Bitmap sub = CropImage(bmp, rt);
                sub.Save(fileName, ImageFormat.Png);
                sub.Dispose();
                bmp.Dispose();
            }
            catch
            {
                MessageBox.Show((idx == 0) ? "Left Save Error" : "Right Save Error");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
