using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboBoxImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbImages.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbImages.DrawMode = DrawMode.OwnerDrawFixed;
            cmbImages.Items.AddRange(
                Enumerable.Repeat<string>("", listImages.Images.Count).ToArray());
        }

        private void cmbImages_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index >= 0)
            {
                if (e.Index < listImages.Images.Count)
                {
                    Image img = new Bitmap(listImages.Images[e.Index], new Size(32, 32));
                    e.Graphics.DrawImage(img, new PointF(e.Bounds.Left, e.Bounds.Top));
                }
                e.Graphics.DrawString(string.Format("Minion {0}", e.Index + 1)
                    , e.Font, new SolidBrush(e.ForeColor)
                    , e.Bounds.Left + 32, e.Bounds.Top);
            }
        }

        private void cmbImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex >= 0)
                picImage.Image = listImages.Images[combo.SelectedIndex];
            else
                picImage.Image = null;
        }
    }
}
