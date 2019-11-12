using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace Conways_Game_of_Life_cs
{
    public class Animation
    {

        private exDGV gridControl;
        private int[][] cellValues = new int[100][];

        public bool cancelled = false;
        public Animation(exDGV dgv)
        {
            this.gridControl = dgv;
            for (int r = 0; r <= 99; r++)
            {
                cellValues[r] = new int[100];
            }
        }

        private void clear()
        {
            for (int r = 0; r <= 99; r++)
            {
                for (int c = 0; c <= 99; c++)
                {
                    cellValues[r][c] = 0;
                }
            }
        }

        private void repaint()
        {
            if (cancelled)
                return;
            for (int r = 0; r <= 99; r++)
            {
                for (int c = 0; c <= 99; c++)
                {
                    if (cellValues[r][c] > 0)
                    {
                        gridControl.Rows[r].Cells[c].Style.BackColor = Color.Black;
                    }
                    else
                    {
                        gridControl.Rows[r].Cells[c].Style.BackColor = Color.White;
                    }
                }
            }
        }

        public void setSeed(int x)
        {
            cancelled = true;
            clear();

            switch (x)
            {
                case 1:
                    //diamond
                    for (int r = 47; r <= 48; r++)
                    {
                        for (int c = 49; c <= 50; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 49; r <= 50; r++)
                    {
                        for (int c = 49; c <= 50; c++)
                        {
                            cellValues[r][c] = -1;
                        }
                    }

                    for (int r = 49; r <= 50; r++)
                    {
                        for (int c = 51; c <= 52; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 51; r <= 52; r++)
                    {
                        for (int c = 49; c <= 50; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 49; r <= 50; r++)
                    {
                        for (int c = 47; c <= 48; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    break;
                case 2:
                    //square
                    for (int r = 48; r <= 51; r++)
                    {
                        for (int c = 48; c <= 51; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    break;
                case 3:
                    //cross
                    for (int r = 47; r <= 48; r++)
                    {
                        for (int c = 47; c <= 48; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 47; r <= 48; r++)
                    {
                        for (int c = 51; c <= 52; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 49; r <= 50; r++)
                    {
                        for (int c = 49; c <= 50; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 51; r <= 52; r++)
                    {
                        for (int c = 47; c <= 48; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    for (int r = 51; r <= 52; r++)
                    {
                        for (int c = 51; c <= 52; c++)
                        {
                            cellValues[r][c] = 1;
                        }
                    }

                    break;
            }
            cancelled = false;
            repaint();
            cancelled = true;

        }

        public void animate(object i)
        {
            int index = (int)i;
            cancelled = false;
            int l = 0;
            int t = 0;
            int r = 0;
            int b = 0;
            switch (index)
            {
                case 1:
                case 3:
                    t = 47;
                    b = 52;
                    l = 47;
                    r = 52;
                    break;
                case 2:
                    t = 48;
                    b = 51;
                    l = 48;
                    r = 51;
                    break;
            }
            int g = 2;
            while (!cancelled)
            {
                for (int y = t; y <= b; y++)
                {
                    for (int x = l; x <= r; x++)
                    {
                        if (cancelled)
                        {
                            return;
                        }
                        if (cellValues[y][x] > 0 && cellValues[y][x] < g)
                        {
                            grow(g, y, x);
                        }
                    }
                }
                //Pause for 50 milliseconds
                Thread.Sleep(50);
                for (int y = t; y <= b; y++)
                {
                    for (int x = l; x <= r; x++)
                    {
                        if (cancelled)
                        {
                            return;
                        }
                        if (cellValues[y][x] > 0 && cellValues[y][x] < g)
                        {
                            int count = surrounding(y, x);
                            if (count < 2)
                            {
                                cellValues[y][x] = -1;
                            }
                            else if (count > 3)
                            {
                                cellValues[y][x] = -1;
                            }
                        }
                    }
                }
                //Pause for 50 milliseconds
                Thread.Sleep(50);
                for (int y = t; y <= b; y++)
                {
                    for (int x = l; x <= r; x++)
                    {
                        if (cancelled)
                        {
                            return;
                        }
                        if (cellValues[y][x] == -1)
                        {
                            int count = surrounding(y, x);
                            if (count == 3)
                            {
                                cellValues[y][x] = 1;
                            }
                        }
                    }
                }
                //Pause for 50 milliseconds
                Thread.Sleep(50);
                t -= 1;
                l -= 1;
                b += 1;
                r += 1;
                g += 1;
                if (t < 0 || l < 0)
                {
                    cancelled = true;
                }
                repaint();
            }
        }

        private void grow(int g, int r, int c)
        {
            if (r > 0)
            {
                if (cellValues[r - 1][c] == 0)
                {
                    cellValues[r - 1][c] = g;
                }
                if (c > 0)
                {
                    if (cellValues[r - 1][c - 1] == 0)
                    {
                        cellValues[r - 1][c - 1] = g;
                    }
                }
                if (c < 99)
                {
                    if (cellValues[r - 1][c + 1] == 0)
                    {
                        cellValues[r - 1][c + 1] = g;
                    }
                }
            }
            if (c > 0)
            {
                if (cellValues[r][c - 1] == 0)
                {
                    cellValues[r][c - 1] = g;
                }
            }
            if (c < 99)
            {
                if (cellValues[r][c + 1] == 0)
                {
                    cellValues[r][c + 1] = g;
                }
            }
            if (r < 99)
            {
                if (cellValues[r + 1][c] == 0)
                {
                    cellValues[r + 1][c] = g;
                }
                if (c > 0)
                {
                    if (cellValues[r + 1][c - 1] == 0)
                    {
                        cellValues[r + 1][c - 1] = g;
                    }
                }
                if (c < 99)
                {
                    if (cellValues[r + 1][c + 1] == 0)
                    {
                        cellValues[r + 1][c + 1] = g;
                    }
                }
            }
        }

        private int surrounding(int r, int c)
        {
            int count = 0;
            if (r > 0)
            {
                if (cellValues[r - 1][c] > 0)
                {
                    count += 1;
                }
                if (c > 0)
                {
                    if (cellValues[r - 1][c - 1] > 0)
                    {
                        count += 1;
                    }
                }
                if (c < 99)
                {
                    if (cellValues[r - 1][c + 1] > 0)
                    {
                        count += 1;
                    }
                }
            }
            if (c > 0)
            {
                if (cellValues[r][c - 1] > 0)
                {
                    count += 1;
                }
            }
            if (c < 99)
            {
                if (cellValues[r][c + 1] > 0)
                {
                    count += 1;
                }
            }
            if (r < 99)
            {
                if (cellValues[r + 1][c] > 0)
                {
                    count += 1;
                }
                if (c > 0)
                {
                    if (cellValues[r + 1][c - 1] > 0)
                    {
                        count += 1;
                    }
                }
                if (c < 99)
                {
                    if (cellValues[r + 1][c + 1] > 0)
                    {
                        count += 1;
                    }
                }
            }

            return count;
        }

    }
}
