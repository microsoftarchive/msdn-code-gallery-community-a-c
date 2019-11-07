using System;
using System.Drawing;
using System.Windows.Forms;

namespace StatisticsLibrary
{
    public class XYScatter
    {
        private double xInter, yInter, xSlope, ySlope;
        private int iWidth, iHeight, oWidth, oHeight;
        private int ax0, ay0, ax1, ay1;
        private int[] gpx;
        private int[,] gpy;
        private Setup su;

        public struct Setup
        {
            public bool majorAxisGridLines, minorAxisGridLines;
            public bool plot, verticleYAxisTitle;
            public double[] x;
            public double[,] y;
            public int dotSize;
            public string title, xAxisTitle, yAxisTitle;
            public Panel panel;
            public Pen aPen, tPen;
            public Pen[] gpPens;
            public SolidBrush tBrush;
            public SolidBrush[] gpBrushes;

            public Setup(
                bool plot,
                double[] x,
                double[,] y,
                string title,
                string xAxisTitle,
                string yAxisTitle,
                Panel panel)
            {
                this.plot = plot;
                this.x = x;
                this.y = y;
                this.dotSize = 2;
                this.title = title;
                this.xAxisTitle = xAxisTitle;
                this.yAxisTitle = yAxisTitle;
                this.panel = panel;
                majorAxisGridLines = minorAxisGridLines = verticleYAxisTitle = true;
                aPen = tPen = new Pen(Color.Black);
                tBrush = new SolidBrush(Color.Black);

                int length = y.GetLength(0);

                gpPens = new Pen[length];
                gpBrushes = new SolidBrush[length];
                gpPens[0] = new Pen(Color.Blue);
                gpBrushes[0] = new SolidBrush(Color.Blue);

                if (length == 1)
                    return;

                gpPens[1] = new Pen(Color.Green);
                gpBrushes[1] = new SolidBrush(Color.Green);

                if (length == 2)
                    return;

                gpPens[2] = new Pen(Color.Orange);
                gpBrushes[2] = new SolidBrush(Color.Orange);

                if (length == 3)
                    return;

                gpPens[3] = new Pen(Color.Brown);
                gpBrushes[3] = new SolidBrush(Color.Brown);

                if (length == 4)
                    return;

                gpPens[4] = new Pen(Color.Magenta);
                gpBrushes[4] = new SolidBrush(Color.Magenta);

                if (length == 5)
                    return;

                gpPens[5] = new Pen(Color.Purple);
                gpBrushes[5] = new SolidBrush(Color.Purple);

                if (length == 6)
                    return;

                gpPens[6] = new Pen(Color.Olive);
                gpBrushes[6] = new SolidBrush(Color.Olive);

                if (length == 7)
                    return;

                gpPens[7] = new Pen(Color.Violet);
                gpBrushes[7] = new SolidBrush(Color.Violet);

                if (length == 8)
                    return;

                for (int i = 8; i < length; i++)
                {
                    gpPens[i] = new Pen(Color.Black);
                    gpBrushes[i] = new SolidBrush(Color.Black);
                }
            }

            public Setup(
                bool plot,
                bool majorAxisGridLines,
                bool minorAxisGridLines,
                bool verticleYAxisTitle,
                double[] x,
                double[,] y,
                int dotSize,
                string title,
                string xAxisTitle,
                string yAxisTitle,
                Color aColor,
                Color tColor,
                Color[] gpColors,
                Panel panel)
            {
                this.plot = plot;
                this.majorAxisGridLines = majorAxisGridLines;
                this.minorAxisGridLines = minorAxisGridLines;
                this.verticleYAxisTitle = verticleYAxisTitle;
                this.x = x;
                this.y = y;
                this.dotSize = dotSize;
                this.title = title;
                this.xAxisTitle = xAxisTitle;
                this.yAxisTitle = yAxisTitle;
                this.panel = panel;
                aPen = new Pen(aColor);
                tPen = new Pen(tColor);
                tBrush = new SolidBrush(tColor);
                gpPens = new Pen[gpColors.Length];
                gpBrushes = new SolidBrush[gpColors.Length];

                for (int i = 0; i < gpColors.Length; i++)
                {
                    gpPens[i] = new Pen(gpColors[i]);
                    gpBrushes[i] = new SolidBrush(gpColors[i]);
                }
            }
        }

        public XYScatter(
            bool plot,
            double[] x,
            double[,] y,
            string title,
            string xAxisTitle,
            string yAxisTitle,
            Panel panel)
        {
            su = new Setup(plot, x, y, title, xAxisTitle, yAxisTitle, panel);
            panel.Paint += Panel_Paint;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            DrawArea(e.Graphics);

            if (!su.plot)
                DrawLines(e.Graphics);

            else
                PlotPoints(e.Graphics);
        }

        public XYScatter(
            bool plot,
            bool majorAxisGridLines,
            bool minorAxisGridLines,
            bool verticleYAxisTitle,
            double[] x,
            double[,] y,
            int dotSize,
            string title,
            string xAxisTitle,
            string yAxisTitle,
            Color aColor,
            Color tColor,
            Color[] gpColors,
            Panel panel)
        {
            su = new Setup(plot, majorAxisGridLines, minorAxisGridLines, verticleYAxisTitle,
                x, y, dotSize, title, xAxisTitle, yAxisTitle, aColor, tColor, gpColors, panel);
            panel.Paint += Panel_Paint;
        }

        private void DrawArea(Graphics g)
        {
            double xmax = double.MinValue, xmin = double.MaxValue;
            double ymax = double.MinValue, ymin = double.MaxValue;

            oWidth = su.panel.Width;
            oHeight = su.panel.Height;
            iWidth = (int)((3.0 * oWidth) / 4.0);
            iHeight = (int)((3.0 * oHeight) / 4.0);
            ax0 = (int)(oWidth / 8.0);
            ay0 = (int)(oHeight / 8.0);
            ax1 = ax0 + iWidth;
            ay1 = ay0 + iHeight;
            g.DrawRectangle(su.aPen, ax0, ay0, iWidth, iHeight);

            for (int i = 0; i < su.x.Length; i++)
            {
                double x = su.x[i];

                if (x < xmin)
                    xmin = x;

                if (x > xmax)
                    xmax = x;
            }

            for (int i = 0; i < su.y.GetLength(0); i++)
            {
                double lYmax = double.MinValue, lYmin = double.MaxValue;

                for (int j = 0; j < su.y.GetLength(1); j++)
                {
                    double y = su.y[i, j];

                    lYmax = Math.Max(y, lYmax);
                    lYmin = Math.Min(y, lYmin);
                }

                ymax = Math.Max(ymax, lYmax);
                ymin = Math.Min(ymin, lYmin);
            }

            xSlope = iWidth / (xmax - xmin);
            xInter = ax0 - xSlope * xmin;
            ySlope = iHeight / (ymin - ymax);
            yInter = ay1 - ySlope * ymin;
            gpx = new int[su.x.Length];

            for (int i = 0; i < gpx.Length; i++)
                gpx[i] = (int)(xSlope * su.x[i] + xInter);

            gpy = new int[su.y.GetLength(0), su.y.GetLength(1)];

            for (int i = 0; i < su.y.GetLength(0); i++)
                for (int j = 0; j < su.y.GetLength(1); j++)
                    gpy[i, j] = (int)(ySlope * su.y[i, j] + yInter);

            int xdelta = iWidth / 4, ydelta = iHeight / 4;

            if (su.majorAxisGridLines)
                for (int i = 1; i <= 3; i++)
                    g.DrawLine(su.aPen, ax0 + i * xdelta, ay0, ax0 + i * xdelta, ay1);

            if (su.minorAxisGridLines)
                for (int i = 1; i <= 3; i++)
                    g.DrawLine(su.aPen, ax0, ay0 + i * ydelta, ax1, ay0 + i * ydelta);

            SizeF titleSize = g.MeasureString(su.title, su.panel.Font);
            SizeF xAxisTitleSize = g.MeasureString(su.xAxisTitle, su.panel.Font);
            SizeF yAxisTitleSize = g.MeasureString(su.yAxisTitle, su.panel.Font);

            if ((int)titleSize.Width < oWidth)
            {
                float fdeltax = (oWidth - titleSize.Width) / 2.0f;
                float fdeltay = (oHeight / 8.0f - titleSize.Height / 2.0f) / 2.0f;

                g.DrawString(su.title, su.panel.Font, su.tBrush, fdeltax, fdeltay);
            }

            if ((int)xAxisTitleSize.Width < oWidth)
            {
                float fdeltax = (oWidth - xAxisTitleSize.Width) / 2.0f;
                float fdeltay = oHeight - 2.0f * xAxisTitleSize.Height;

                g.DrawString(su.xAxisTitle, su.panel.Font, su.tBrush, fdeltax, fdeltay);
            }

            if ((int)(2.0f * xAxisTitleSize.Width) < oWidth - iWidth &&
                ((int)(oHeight - yAxisTitleSize.Height) / 2.0f) > 0.0f)
            {
                float fdeltax = 0;
                float fdeltay = (oHeight - yAxisTitleSize.Height) / 2.0f;
                StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);

                g.DrawString(su.yAxisTitle, su.panel.Font, su.tBrush, fdeltax, fdeltay, sf);
            }

            double xgrid = 0.25 * (xmax - xmin);
            double ygrid = 0.25 * (ymax - ymin);
            double u = xmin, v = ymin;
            int ix = ax0, iy = 0;

            for (int i = 0; i < 5; i++)
            {
                string s = u.ToString("E2");
                SizeF size = g.MeasureString(s, su.panel.Font);
                float shift = -size.Width / 2.0f;

                iy = ay1 + (int)size.Height;
                g.DrawString(s, su.panel.Font, su.tBrush, ix + (int)Math.Round(shift), iy);
                ix += xdelta;
                u += xgrid;
            }

            ix = ax0;
            iy = ay1;

            for (int i = 0; i < 5; i++)
            {
                string s = v.ToString("E2");
                SizeF size = g.MeasureString(s, su.panel.Font);
                float shift = size.Width - 4.0f;

                g.DrawString(s, su.panel.Font, su.tBrush,
                    ix - (int)Math.Round(shift), iy - (int)Math.Round(size.Height) / 2.0f);
                iy -= ydelta;
                v += ygrid;
            }
        }

        public void DrawLines(Graphics g)
        {
            for (int i = 0; i < gpx.Length - 1; i++)
            {
                int x0 = gpx[i];
                int x1 = gpx[i + 1];

                for (int j = 0; j < gpy.GetLength(0); j++)
                {
                    int y0 = gpy[j, i];
                    int y1 = gpy[j, i + 1];

                    g.DrawLine(su.gpPens[j], x0, y0, x1, y1);
                }
            }
        }

        public void PlotPoints(Graphics g)
        {
            for (int i = 0; i < gpx.Length; i++)
            {
                int x0 = gpx[i];

                for (int j = 0; j < gpy.GetLength(0); j++)
                {
                    int y0 = gpy[j, i];

                    g.FillEllipse(su.gpBrushes[j], x0, y0, su.dotSize, su.dotSize);
                }
            }
        }
    }
}