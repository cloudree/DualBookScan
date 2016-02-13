using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;

using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace DualBookScan
{
    public partial class frmBatch : Form
    {
        public frmBatch()
        {
            InitializeComponent();
        }

        private void RefreshFileList()
        {
            lbFiles.Items.Clear();
            if (ebSrcFolder.Text == "")
                return;

            // https://support.microsoft.com/ko-kr/kb/303974
            try
            {
                foreach (string f in Directory.GetFiles(ebSrcFolder.Text))
                {
                    lbFiles.Items.Add(f);
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
        
        private void Convert(ref Bitmap bmp)
        {
            BrightnessCorrection bc = chkBrightAuto.Checked ? new BrightnessCorrection() : new BrightnessCorrection((int)nudBright.Value);
            ContrastCorrection cc = chkContrastAuto.Checked ? new ContrastCorrection() : new ContrastCorrection((int)nudContrast.Value);

            bc.ApplyInPlace(bmp);
            cc.ApplyInPlace(bmp);

            if (chkGray.Checked)
            {
                try
                {
                    bmp = Grayscale.CommonAlgorithms.BT709.Apply(bmp);
                }
                catch
                {
                    // no handler
                }
            }
        }

        private void ConvertJPG()
        {
            int selCount = lbFiles.SelectedIndices.Count;
            if (selCount <= 0)
                return;
            int last = lbFiles.SelectedIndices[selCount - 1];

            progressBar.Value = 0;
            progressBar.Maximum = lbFiles.SelectedIndices.Count;

            foreach (int idx in lbFiles.SelectedIndices)
            {
                String srcName = lbFiles.Items[idx].ToString();

                int pos = srcName.LastIndexOf('.');
                String destName = srcName.Substring(0, pos) + ".jpg";

                pos = destName.LastIndexOf('\\');
                destName = ebDestFolder.Text + destName.Substring(pos, destName.Length - pos);

                if( srcName.CompareTo(destName) == 0 )
                {
                    MessageBox.Show("Same Filename & Folder, Plz change dest Folder!");
                    return;
                }
                Bitmap bmp = new Bitmap(srcName);
                Convert(ref bmp);
                bmp.Save(destName);
                bmp.Dispose();

                progressBar.Value++;
            }

            progressBar.Value = progressBar.Maximum;

            MessageBox.Show("Convert Completed");
        }

        private void CollectPDF()
        {
            dlgSaveFile.InitialDirectory = ebSrcFolder.Text;
            dlgSaveFile.Filter = "PDF Files (*.pdf)|*.pdf";
            dlgSaveFile.DefaultExt = ".pdf";
            if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                return;

            String destName = dlgSaveFile.FileName;

            int selCount = lbFiles.SelectedIndices.Count;
            if (selCount <= 0)
                return;
            int last = lbFiles.SelectedIndices[selCount - 1];

            PdfDocument pdfDoc = new PdfDocument();
            pdfDoc.Info.Title = "";

            progressBar.Value = 0;
            progressBar.Maximum = lbFiles.SelectedIndices.Count;

            foreach (int idx in lbFiles.SelectedIndices)
            {
                PdfPage pdfPage = pdfDoc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(pdfPage);

                String srcName = lbFiles.Items[idx].ToString();
                XImage ximg = XImage.FromFile(srcName);

                gfx.DrawImage(ximg, 0, 0, pdfPage.Width, pdfPage.Height);

                progressBar.Value++;
            }

            progressBar.Value = progressBar.Maximum;

            pdfDoc.Save(destName);

            MessageBox.Show("PDF Completed");
        }

        private void RefreshPreview()
        {
            int selCount = lbFiles.SelectedIndices.Count;
            if (selCount <= 0)
                return;
            int last = lbFiles.SelectedIndices[selCount - 1];
            String srcName = lbFiles.Items[last].ToString();

            try
            {
                Bitmap bmp = new Bitmap(srcName);
                Convert(ref bmp);
                pbPreview.Image = bmp;
            }
            catch
            {
                // no handler
            }
        }

        private void ebFolder_TextChanged(object sender, EventArgs e)
        {
        }
        
        private void ebSrcFolder_TextChanged(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void btnSrcFolder_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = ebSrcFolder.Text;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ebSrcFolder.Text = dlgFolderBrowser.SelectedPath;
            }
        }

        private void btnDestFolder_Click(object sender, EventArgs e)
        {
            dlgFolderBrowser.SelectedPath = ebDestFolder.Text;
            if (dlgFolderBrowser.ShowDialog() == DialogResult.OK)
            {
                ebDestFolder.Text = dlgFolderBrowser.SelectedPath;
            }
        }

        private void btnFolderRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void lbFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        // ======== filter controls ===========================================
        private void chkGray_CheckedChanged(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        private void chkBrightAuto_CheckedChanged(object sender, EventArgs e)
        {
            nudBright.Enabled = !chkBrightAuto.Checked;
        }

        private void nudBright_ValueChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                RefreshPreview();
            }
        }

        private void chkContrastAuto_CheckedChanged(object sender, EventArgs e)
        {
            nudContrast.Enabled = !chkContrastAuto.Checked;
        }

        private void nudContrast_ValueChanged(object sender, EventArgs e)
        {
            if (chkAuto.Checked)
            {
                RefreshPreview();
            }
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = !chkAuto.Checked;
            if (chkAuto.Checked)
            {
                RefreshPreview();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            RefreshPreview();
        }

        // ======== batch controls ===========================================
        private void btnConvertJPG_Click(object sender, EventArgs e)
        {
            ConvertJPG();
        }

        private void btnCollectPDF_Click(object sender, EventArgs e)
        {
            CollectPDF();
        }
    }
}
