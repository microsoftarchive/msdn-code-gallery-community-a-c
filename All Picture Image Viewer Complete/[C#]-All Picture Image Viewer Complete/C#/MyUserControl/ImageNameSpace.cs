using System.Windows.Media.Imaging;
using System.Drawing;
using System;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Media;

namespace MyUserControl
{
    class ImgWrapper
    {
        public Bitmap Bitmap;
        public BitmapImage BitmapImage;
    }

    class Img
    {
        public ImgWrapper Image = new ImgWrapper();
        public ImgWrapper Load(string path)
        {
            Image.Bitmap = (Bitmap)Bitmap.FromFile(path);
            Image.BitmapImage = new BitmapImage(new Uri(path));
            return Image;
        }

        public void Save(string path)
        {
            Image.Bitmap.Save(path, Image.Bitmap.RawFormat);
        }

        public ImgWrapper ImgWrapperBitmap(Bitmap newBmp)
        {
            var stream = new MemoryStream();
            newBmp.Save(stream, ImageFormat.Png);
            stream.Position = 0;
            var result = new BitmapImage();
            result.BeginInit();
            result.StreamSource = stream;
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.EndInit();

            Image.Bitmap = newBmp;
            Image.BitmapImage = result;
            return Image;
        }


        public ImgWrapper ImgWrapperBitmapImage(BitmapImage bitmapImage)
        {
            Image.Bitmap = new Bitmap(bitmapImage.StreamSource);
            Image.BitmapImage = bitmapImage;
            return Image;
        }
    }
}
