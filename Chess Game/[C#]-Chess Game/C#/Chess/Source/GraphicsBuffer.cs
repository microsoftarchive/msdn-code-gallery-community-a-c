using System.Drawing;

namespace Chess.Source
{
    public sealed class GraphicsBuffer
    {
        private Graphics graphics;
        private int height;
        private Bitmap memoryBitmap;
        private int width;

        public Graphics Graphics
        {
            get { return graphics; }
        }

        public void CreateGraphicsBuffer(Graphics g, int W, int H)
        {
            if (memoryBitmap != null)
            {
                memoryBitmap.Dispose();
                memoryBitmap = null;
            }

            if (graphics != null)
            {
                graphics.Dispose();
                graphics = null;
            }

            if (W == 0 || H == 0)
                return;


            if ((W != width) || (H != height))
            {
                width = W;
                height = H;

                memoryBitmap = new Bitmap(width, height);
                graphics = Graphics.FromImage(memoryBitmap);
            }
        }

        public void Render(Graphics g)
        {
            if (memoryBitmap != null)
            {
                g.DrawImage(memoryBitmap, new Rectangle(0, 0, width, height), 0, 0, width, height, GraphicsUnit.Pixel);
            }
        }
    }
}