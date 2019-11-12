using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;

namespace Barcode
{
    public class Code39Control : Control
    {
        private ContextMenuStrip _ContextMenuStrip = new ContextMenuStrip();
        private int _WideNarrowRatio = 2;
        private Dictionary<string, byte[]> chars = new Dictionary<string, byte[]>();

        public int WideNarrowRatio
        {
            get { return _WideNarrowRatio; }
            set { _WideNarrowRatio = value; }
        }
        public Code39Control()
        {
            _ContextMenuStrip.Items.Add("Export");
            _ContextMenuStrip.Items.Add("Print");
            this.ContextMenuStrip = _ContextMenuStrip;
            _ContextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(_ContextMenuStrip_ItemClicked);
            this.BackColor = Color.White;
            this.TextChanged += new EventHandler(Code39Control_TextChanged);
            chars.Add("1", new byte[] { 1, 0, 0, 1, 0, 0, 0, 0, 1 });
            chars.Add("2", new byte[] { 0, 0, 1, 1, 0, 0, 0, 0, 1 });
            chars.Add("3", new byte[] { 1, 0, 1, 1, 0, 0, 0, 0, 0 });
            chars.Add("4", new byte[] { 0, 0, 0, 1, 1, 0, 0, 0, 1 });
            chars.Add("5", new byte[] { 1, 0, 0, 1, 1, 0, 0, 0, 0 });
            chars.Add("6", new byte[] { 0, 0, 1, 1, 1, 0, 0, 0, 0 });
            chars.Add("7", new byte[] { 0, 0, 0, 1, 0, 0, 1, 0, 1 });
            chars.Add("8", new byte[] { 1, 0, 0, 1, 0, 0, 1, 0, 0 });
            chars.Add("9", new byte[] { 0, 0, 1, 1, 0, 0, 1, 0, 0 });
            chars.Add("0", new byte[] { 0, 0, 0, 1, 1, 0, 1, 0, 0 });
            chars.Add("A", new byte[] { 1, 0, 0, 0, 0, 1, 0, 0, 1 });
            chars.Add("B", new byte[] { 0, 0, 1, 0, 0, 1, 0, 0, 1 });
            chars.Add("C", new byte[] { 1, 0, 1, 0, 0, 1, 0, 0, 0 });
            chars.Add("D", new byte[] { 0, 0, 0, 0, 1, 1, 0, 0, 1 });
            chars.Add("E", new byte[] { 1, 0, 0, 0, 1, 1, 0, 0, 0 });
            chars.Add("F", new byte[] { 0, 0, 1, 0, 1, 1, 0, 0, 0 });
            chars.Add("G", new byte[] { 0, 0, 0, 0, 0, 1, 1, 0, 1 });
            chars.Add("H", new byte[] { 1, 0, 0, 0, 0, 1, 1, 0, 0 });
            chars.Add("I", new byte[] { 0, 0, 1, 0, 0, 1, 1, 0, 0 });
            chars.Add("J", new byte[] { 0, 0, 0, 0, 1, 1, 1, 0, 0 });
            chars.Add("K", new byte[] { 1, 0, 0, 0, 0, 0, 0, 1, 1 });
            chars.Add("L", new byte[] { 0, 0, 1, 0, 0, 0, 0, 1, 1 });
            chars.Add("M", new byte[] { 1, 0, 1, 0, 0, 0, 0, 1, 0 });
            chars.Add("N", new byte[] { 0, 0, 0, 0, 1, 0, 0, 1, 1 });
            chars.Add("O", new byte[] { 1, 0, 0, 0, 1, 0, 0, 1, 0 });
            chars.Add("P", new byte[] { 0, 0, 1, 0, 1, 0, 0, 1, 0 });
            chars.Add("Q", new byte[] { 0, 0, 0, 0, 0, 0, 1, 1, 1 });
            chars.Add("R", new byte[] { 1, 0, 0, 0, 0, 0, 1, 1, 0 });
            chars.Add("S", new byte[] { 0, 0, 1, 0, 0, 0, 1, 1, 0 });
            chars.Add("T", new byte[] { 0, 0, 0, 0, 1, 0, 1, 1, 0 });
            chars.Add("U", new byte[] { 1, 1, 0, 0, 0, 0, 0, 0, 1 });
            chars.Add("V", new byte[] { 0, 1, 1, 0, 0, 0, 0, 0, 1 });
            chars.Add("W", new byte[] { 1, 1, 1, 0, 0, 0, 0, 0, 0 });
            chars.Add("X", new byte[] { 0, 1, 0, 0, 1, 0, 0, 0, 1 });
            chars.Add("Y", new byte[] { 1, 1, 0, 0, 1, 0, 0, 0, 0 });
            chars.Add("Z", new byte[] { 0, 1, 1, 0, 1, 0, 0, 0, 0 });
            chars.Add("-", new byte[] { 0, 1, 0, 0, 0, 0, 1, 0, 1 });
            chars.Add(".", new byte[] { 1, 1, 0, 0, 0, 0, 1, 0, 0 });
            chars.Add(" ", new byte[] { 0, 1, 1, 0, 0, 0, 1, 0, 0 });
            chars.Add("*", new byte[] { 0, 1, 0, 0, 1, 0, 1, 0, 0 });
            chars.Add("$", new byte[] { 0, 1, 0, 1, 0, 1, 0, 0, 0 });
            chars.Add("/", new byte[] { 0, 1, 0, 1, 0, 0, 0, 1, 0 });
            chars.Add("+", new byte[] { 0, 1, 0, 0, 0, 1, 0, 1, 0 });
            chars.Add("%", new byte[] { 0, 0, 0, 1, 0, 1, 0, 1, 0 });

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            try
            {
                DrawBarcode(e.Graphics);
            }
            catch (Exception)
            {
                e.Graphics.DrawString("COULD NOT DRAW BARCODE", new Font("Times New Roman", 12), Brushes.Red, 0, 0);
            }
        }
        private void DrawBarcode(Graphics insGraphics)
        {
            string text = this.Text.ToUpper();
            if (!text.StartsWith("*"))
            {
                text = "*" + text;
            }
            if (!text.EndsWith("*"))
            {
                text = text + "*";
            }
            insGraphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            int narrowCount = 0;
            int wideCount = 0;
            int blankCount = 0;
            for (int i = 0; i < text.Length; i++)
            {
                byte[] insByteArray = chars[text.Substring(i, 1)];
                foreach (byte insByte in insByteArray)
                {
                    if (insByte == 1)
                    {
                        wideCount++;
                    }
                    else
                    {
                        narrowCount++;
                    }
                }
                if (i + 1 != text.Length)
                {
                    blankCount++;
                }
            }
            decimal widthPerUnit = Math.Round(Convert.ToDecimal(this.Width) / Convert.ToDecimal(((wideCount * _WideNarrowRatio) + blankCount + narrowCount)), 2);
            decimal currentLeft = 0;
            for (int i = 0; i < text.Length; i++)
            {
                byte[] insByteArray = chars[text.Substring(i, 1)];
                int index = 0;
                foreach (byte insByte in insByteArray)
                {
                    if (index % 2 == 0)
                    {
                        insGraphics.FillRectangle(new SolidBrush(this.ForeColor), (float)currentLeft, 0, (float)(insByte == 1 ? widthPerUnit * _WideNarrowRatio : widthPerUnit), this.Height);

                    }
                    currentLeft += (insByte == 1 ? widthPerUnit * _WideNarrowRatio : widthPerUnit);

                    index++;
                }
                currentLeft += widthPerUnit;
            }
        }

        void Code39Control_TextChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }
        void _ContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Print")
            {
                PrintDocument p = new PrintDocument();
                p.PrintPage += new PrintPageEventHandler(p_PrintPage);
                p.Print();
            }
            else if (e.ClickedItem.Text == "Export")
            {
                _ContextMenuStrip.Close();
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.ShowDialog();
                if (sfd.FileName != "")
                {
                    Bitmap b = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(b, new Rectangle(0, 0, this.Width, this.Height));
                    Image i =  (Image)b;
                    i.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }
        }
        void p_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(b, new Rectangle(0, 0, this.Width, this.Height));
            Image i = (Image)b;
            e.Graphics.DrawImage(i, new Point(10, 10));

        }
    }
}
