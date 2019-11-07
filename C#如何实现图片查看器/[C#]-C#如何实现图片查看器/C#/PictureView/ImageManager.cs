using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace 图片查看器
{
    public class ImageManager
    {
        // 如果你想把图片旋转任何角度可以使用System.Drawing.Drawing2D.Matrix类
        /// <summary>
        ///  获得旋转之后的图片对象
        /// </summary>
        /// <param name="bmp">图片对象</param>
        /// <param name="angle">旋转的角度</param>
        /// <param name="bkColor"></param>
        /// <returns></returns>
        public static Bitmap RotateImg(Bitmap bmp, float angle, Color bkColor)
        {
            // 获得图片的高度和宽度
            int width = bmp.Width;
            int height = bmp.Height;
            // PixelFormat指定图像中每个像素的颜色数据的格式
            PixelFormat pixelFormat = default(PixelFormat);
            if (bkColor == Color.Transparent)
            {
                pixelFormat = PixelFormat.Format32bppArgb;
            }
            else
            {
                // 获取图像像素格式
                pixelFormat = bmp.PixelFormat;
            }

            Bitmap tempImg = new Bitmap(width, height, pixelFormat);
            // 一个 GDI+ 绘图图面
            // 创建画布对象
            Graphics g = Graphics.FromImage(tempImg);
            g.Clear(bkColor);

            // 在由坐标对指定的位置，使用图像的原始物理大小绘制指定的图像
            g.DrawImageUnscaled(bmp, 1, 1);
            g.Dispose();

            // 画布路径
            GraphicsPath path = new GraphicsPath();
            // 向路径添加一个矩形
            path.AddRectangle(new RectangleF(0f,0f,width,height));
            // 创建一个单位矩阵
            Matrix matrix = new Matrix();
            // 沿原点并按指定角度顺时针旋转
            matrix.Rotate(angle);

            RectangleF rct = path.GetBounds(matrix);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pixelFormat);
            g = Graphics.FromImage(newImg);
            g.Clear(bkColor);
            // 平移来更改坐标的原点
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            
            return newImg;
        }

        // 获得预览图片文件路径下的图片集合
        public static List<string> GetImgCollection(string path)
        {
            string[] imgarray = Directory.GetFiles(path);
            var result = from imgstring in imgarray
                         where imgstring.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || 
                         imgstring.EndsWith("png", StringComparison.OrdinalIgnoreCase)||
                         imgstring.EndsWith("bmp", StringComparison.OrdinalIgnoreCase)
                         select imgstring;
            return result.ToList();
        }
    }
}
