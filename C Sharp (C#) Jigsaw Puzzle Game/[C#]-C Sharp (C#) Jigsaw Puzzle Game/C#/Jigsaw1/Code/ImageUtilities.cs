using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageProcessing
{    
    // ====================================================================
    // http://www.codeproject.com/Articles/1989/Image-Processing-for-Dummies-with-C-and-GDI-Part-1
    // http://ithoughthecamewithyou.com/post/Fastest-image-merge-%28alpha-blend%29-in-GDI2b.aspx
    // ====================================================================
    public class ImageUtilities
    {                    
        public static bool EdgeDetectHorizontal(Bitmap b)
        {
            Bitmap bmTemp = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmData2 = bmTemp.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr Scan02 = bmData2.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* p2 = (byte*)(void*)Scan02;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                int nPixel = 0;

                p += stride;
                p2 += stride;

                for (int y = 1; y < b.Height - 1; ++y)
                {
                    p += 9;
                    p2 += 9;

                    for (int x = 9; x < nWidth - 9; ++x)
                    {
                        nPixel = ((p2 + stride - 9)[0] +
                            (p2 + stride - 6)[0] +
                            (p2 + stride - 3)[0] +
                            (p2 + stride)[0] +
                            (p2 + stride + 3)[0] +
                            (p2 + stride + 6)[0] +
                            (p2 + stride + 9)[0] -
                            (p2 - stride - 9)[0] -
                            (p2 - stride - 6)[0] -
                            (p2 - stride - 3)[0] -
                            (p2 - stride)[0] -
                            (p2 - stride + 3)[0] -
                            (p2 - stride + 6)[0] -
                            (p2 - stride + 9)[0]);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        (p + stride)[0] = (byte)nPixel;

                        ++p;
                        ++p2;
                    }

                    p += 9 + nOffset;
                    p2 += 9 + nOffset;
                }
            }

            b.UnlockBits(bmData);
            bmTemp.UnlockBits(bmData2);

            return true;
        }

        public static bool EdgeDetectVertical(Bitmap b)
        {
            Bitmap bmTemp = (Bitmap)b.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmData2 = bmTemp.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr Scan02 = bmData2.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* p2 = (byte*)(void*)Scan02;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                int nPixel = 0;

                int nStride2 = stride * 2;
                int nStride3 = stride * 3;

                p += nStride3;
                p2 += nStride3;

                for (int y = 3; y < b.Height - 3; ++y)
                {
                    p += 3;
                    p2 += 3;

                    for (int x = 3; x < nWidth - 3; ++x)
                    {
                        nPixel = ((p2 + nStride3 + 3)[0] +
                            (p2 + nStride2 + 3)[0] +
                            (p2 + stride + 3)[0] +
                            (p2 + 3)[0] +
                            (p2 - stride + 3)[0] +
                            (p2 - nStride2 + 3)[0] +
                            (p2 - nStride3 + 3)[0] -
                            (p2 + nStride3 - 3)[0] -
                            (p2 + nStride2 - 3)[0] -
                            (p2 + stride - 3)[0] -
                            (p2 - 3)[0] -
                            (p2 - stride - 3)[0] -
                            (p2 - nStride2 - 3)[0] -
                            (p2 - nStride3 - 3)[0]);

                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;

                        p[0] = (byte)nPixel;

                        ++p;
                        ++p2;
                    }

                    p += 3 + nOffset;
                    p2 += 3 + nOffset;
                }
            }

            b.UnlockBits(bmData);
            bmTemp.UnlockBits(bmData2);

            return true;
        }
        
        public static Bitmap AlphaBlendMatrix(Bitmap destImage, Bitmap srcImage, byte alpha)
        {            
            Bitmap alphaBlendedImage = (Bitmap)destImage.Clone();

            // for the matrix the range is 0.0 - 1.0
            float alphaNorm = (float)alpha / 255.0F;

            // just change the alpha
            ColorMatrix matrix = new ColorMatrix(new float[][]{
                            new float[] {1F, 0, 0, 0, 0},
                            new float[] {0, 1F, 0, 0, 0},
                            new float[] {0, 0, 1F, 0, 0},
                            new float[] {0, 0, 0, alphaNorm, 0},
                            new float[] {0, 0, 0, 0, 1F}});

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix);

            int offsetX = (destImage.Width - srcImage.Width) / 2;
            int offsetY = (destImage.Height - srcImage.Height) / 2;

            using (Graphics g = Graphics.FromImage(alphaBlendedImage))
            {
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;

                // Scaled image (stretched)
                //g.DrawImage(srcImage,
                //    new Rectangle(0, 0, destImage.Width, destImage.Height),
                //    0,
                //    0,
                //    srcImage.Width,
                //    srcImage.Height,
                //    GraphicsUnit.Pixel,
                //    imageAttributes);

                // No scaling
                g.DrawImage(srcImage,
                    new Rectangle(offsetX, offsetY, srcImage.Width, srcImage.Height),
                    0,
                    0,
                    srcImage.Width,
                    srcImage.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }

            return alphaBlendedImage;
        }

        public static Bitmap ResizeImage(Image srcImage, int destFrameWidth, int destFrameHeight, bool retainDestDimensions)
        {            
            double srcImageWidth = (double)srcImage.Width;
            double srcImageHeight = (double)srcImage.Height;

            // Determine which ratio to use
            double destToSrcRatioWidth = (double)destFrameWidth / srcImageWidth;
            double destToSrcRatioHeight = (double)destFrameHeight / srcImageHeight;
            double destToSrcRatio = destToSrcRatioWidth < destToSrcRatioHeight ? destToSrcRatioWidth : destToSrcRatioHeight;

            // Resize the image based on the ratio
            int resizedImageWidth = (int)(srcImageWidth * destToSrcRatio);
            int resizedImageHeight = (int)(srcImageHeight * destToSrcRatio);

            int offsetX = Math.Abs(destFrameWidth - resizedImageWidth) / 2;
            int offsetY = Math.Abs(destFrameHeight - resizedImageHeight) / 2;

            Bitmap canvas = null;

            if (retainDestDimensions)
            {
                canvas = new Bitmap(destFrameWidth, destFrameHeight);
            }
            else
            {
                canvas = new Bitmap(resizedImageWidth, resizedImageHeight);
            }

            using (Graphics gfx = Graphics.FromImage(canvas))
            {
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

                if (retainDestDimensions)
                {
                    gfx.FillRectangle(Brushes.Gray, 0, 0, destFrameWidth, destFrameHeight);
                    gfx.DrawImage(srcImage, offsetX, offsetY, resizedImageWidth, resizedImageHeight);
                }
                else
                {
                    gfx.FillRectangle(Brushes.Gray, 0, 0, resizedImageWidth, resizedImageHeight);
                    gfx.DrawImage(srcImage, 0, 0, resizedImageWidth, resizedImageHeight);
                }
            }

            return canvas;
        }
    }   
}