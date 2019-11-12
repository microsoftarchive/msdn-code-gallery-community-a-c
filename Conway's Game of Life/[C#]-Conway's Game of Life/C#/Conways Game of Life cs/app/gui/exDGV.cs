using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conways_Game_of_Life_cs
{
    /// <summary>
    /// Extended DataGridView 
    /// DoubleBuffered. Restricts user selection of cells to facilitate seamless highlighting line drawing.
    /// </summary>
    /// <remarks></remarks>
    public class exDGV : DataGridView
    {

        int WM_LBUTTONDOWN = 0x201;
        int WM_LBUTTONDBLCLK = 0x203;

        int WM_KEYDOWN = 0x100;
        public exDGV()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnRowPrePaint(System.Windows.Forms.DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewPaintParts paintParts = (int)e.PaintParts - DataGridViewPaintParts.Focus;
            e.PaintParts = paintParts;
            base.OnRowPrePaint(e);
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_KEYDOWN || m.Msg == WM_LBUTTONDOWN)
            {
                return;
            }
            base.WndProc(ref m);
        }

    }
}
