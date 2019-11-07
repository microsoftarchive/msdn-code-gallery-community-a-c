using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageToIcon
{
    public partial class ImageToIcon : Form
    {
        Stream myStream;
        public ImageToIcon()
        {
            InitializeComponent();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {

            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = ofdPicture.OpenFile()) != null)
                {
                    Image image = Image.FromFile(ofdPicture.FileName);
                    Image newImage = image.GetThumbnailImage(32, 32, null, new IntPtr());
                    txtImagePath.Text = ofdPicture.FileName;
                    pbImage.Image = newImage;
                }
            }
        }

        private void btnSaveAsIcon_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                String fileName = sfdPicture.FileName;
                Stream IconStream = System.IO.File.OpenWrite(fileName);

                Bitmap bitmap = new Bitmap(pbImage.Image);
                bitmap.SetResolution(72, 72);
                Icon icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
                this.Icon = icon;
                icon.Save(IconStream);
            }
        }
    }
}
