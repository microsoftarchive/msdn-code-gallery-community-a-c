using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Base64Bitmaps
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("NavForward.png");
            Bitmap bmp = new Bitmap(streamReader.BaseStream);
            streamReader.Close();

            string base64ImageString = bmp.ToBase64String(ImageFormat.Png);

            Console.WriteLine(base64ImageString);

            Bitmap bmpFromString = base64ImageString.Base64StringToBitmap();
            bmpFromString.Save("FromBase64String.png", ImageFormat.Png);

            Process.Start("FromBase64String.png");

            Console.ReadKey();
        }
    }
}
