using System.Collections.Generic;
using System.Windows.Forms;

namespace ShipperClient
{
    public partial class HRD : Form
    {
        public HRD()
        {
            InitializeComponent();
        }

        internal void AddButtons(List<Button> buttons)
        {
            int y = 50;

            foreach (Button b in buttons)
            {
                b.Size = new System.Drawing.Size(230, 50);
                b.BackColor = System.Drawing.Color.LightGray;
                b.Location = new System.Drawing.Point(90, y);
                y += 50;
                this.Controls.Add(b);
            }
        }
    }
}
