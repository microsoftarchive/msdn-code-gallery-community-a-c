using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace nQuant
{
    public class nQuant
    {
        public static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("You must provide a file name to quantize");
                Environment.Exit(1);
            }
            var sourcePath = args[0];
            if(!File.Exists(sourcePath))
            {
                Console.WriteLine("The source file you specified does not exist.");
                Environment.Exit(1);
            }

            var lastDot = sourcePath.LastIndexOf('.');
            var targetPath = sourcePath.Insert(lastDot, "-quant");
            if(args.Length > 1)
                targetPath = args[1];

            var quantizer = new WuQuantizer();
            using(var bitmap = new Bitmap(sourcePath))
            {
                using(var quantized = quantizer.QuantizeImage(bitmap))
                {
                    quantized.Save(targetPath, ImageFormat.Png);
                }
            }

        }
    }
}
