using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public static class Processes
    {
        public static Bitmap result;

        public static Bitmap LegacyCopy(Bitmap src)
        {
            result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for ( int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);

                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }
        public static Bitmap LegacyGreyScale(Bitmap src)
        {
            result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);

                    // Adobe Greyscale Formula
                    int grey = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);

                    pixel = Color.FromArgb(grey, grey, grey);

                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }
        public static Bitmap LegacyInvertColor(Bitmap src)
        {
            result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);


                    Color inverted = Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B);

                    result.SetPixel(x, y, inverted);
                }
            }

            return result;
        }

        public static Bitmap LegacyHistogram(Bitmap src)
        {
            int width = 256, height = 100;
            Bitmap histImage = new Bitmap(width, height);
            int[] hist = new int[256];

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);

                    //Adobe Greyscale Formula
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    hist[gray]++;
                }
            }

            int max = hist.Max();
            for (int x = 0; x < width; x++)
            {
                int value = (int)((hist[x] / (float)max) * (height - 1));
                for (int y = height - 1; y >= height - value; y--)
                {
                    histImage.SetPixel(x, y, Color.Black);
                }
            }
            return histImage;
        }

        public static Bitmap LegacySepia(Bitmap src)
        {
            result = new Bitmap(src.Width, src.Height);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);

                    // Adobe Sepia Formula
                    int r = (int)(pixel.R * 0.393 + pixel.G * 0.769 + pixel.B * 0.189);
                    int g = (int)(pixel.R * 0.349 + pixel.G * 0.686 + pixel.B * 0.168);
                    int b = (int)(pixel.R * 0.272 + pixel.G * 0.534 + pixel.B * 0.131);

                    Color sepia = Color.FromArgb(
                        Math.Min(255, r),
                        Math.Min(255, g),
                        Math.Min(255, b)
                        );

                    result.SetPixel(x, y, sepia);
                }
            }

            return result;
        }

        public static Bitmap LegacySubtract(Bitmap src1, Bitmap src2)
        {
            int width = Math.Min(src1.Width, src2.Width);
            int height = Math.Min(src1.Height, src2.Height);
            Bitmap result = new Bitmap(width, height);

            int mygreen = 100; 
            int threshold = 60;   

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = src1.GetPixel(x, y);
                    Color backpixel = src2.GetPixel(x, y);

                    if (pixel.G > mygreen && 
                        pixel.G - pixel.R > threshold && 
                        pixel.G - pixel.B > threshold)
                    {
                        result.SetPixel(x, y, backpixel);
                    }
                    else
                    {
                        result.SetPixel(x, y, pixel);
                    }
                }
            }
            return result;
        }

        //////////////
        // Pointer-based approach for faster processing
        //////////////

        public static Bitmap Copy(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height, src.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);

            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);

            int bytes = Math.Abs(srcData.Stride) * src.Height;
            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* destPtr = (byte*)destData.Scan0;
                for (int i = 0; i < bytes; i++)
                {
                    destPtr[i] = srcPtr[i];
                }
            }

            src.UnlockBits(srcData);
            dest.UnlockBits(destData);
            return dest;
        }

        public static Bitmap GreyScale(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height, src.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);

            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;
            int height = src.Height;
            int width = src.Width;

            unsafe
            {
                byte* srcScan0 = (byte*)srcData.Scan0;
                byte* destScan0 = (byte*)destData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* srcRow = srcScan0 + (y * srcData.Stride);
                    byte* destRow = destScan0 + (y * destData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        byte b = srcRow[x * bytesPerPixel + 0];
                        byte g = srcRow[x * bytesPerPixel + 1];
                        byte r = srcRow[x * bytesPerPixel + 2];
                        int grey = (int)(r * 0.299 + g * 0.587 + b * 0.114);
                        destRow[x * bytesPerPixel + 0] = (byte)grey;
                        destRow[x * bytesPerPixel + 1] = (byte)grey;
                        destRow[x * bytesPerPixel + 2] = (byte)grey;
                        if (bytesPerPixel == 4)
                            destRow[x * bytesPerPixel + 3] = srcRow[x * bytesPerPixel + 3]; // alpha
                    }
                }
            }

            src.UnlockBits(srcData);
            dest.UnlockBits(destData);
            return dest;
        }

        public static Bitmap InvertColor(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height, src.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);

            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;
            int height = src.Height;
            int width = src.Width;

            unsafe
            {
                byte* srcScan0 = (byte*)srcData.Scan0;
                byte* destScan0 = (byte*)destData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* srcRow = srcScan0 + (y * srcData.Stride);
                    byte* destRow = destScan0 + (y * destData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        destRow[x * bytesPerPixel + 0] = (byte)(255 - srcRow[x * bytesPerPixel + 0]); // B
                        destRow[x * bytesPerPixel + 1] = (byte)(255 - srcRow[x * bytesPerPixel + 1]); // G
                        destRow[x * bytesPerPixel + 2] = (byte)(255 - srcRow[x * bytesPerPixel + 2]); // R
                        if (bytesPerPixel == 4)
                            destRow[x * bytesPerPixel + 3] = srcRow[x * bytesPerPixel + 3]; // alpha
                    }
                }
            }

            src.UnlockBits(srcData);
            dest.UnlockBits(destData);
            return dest;
        }

        public static Bitmap Histogram(Bitmap src)
        {
            int width = 256, height = 100;
            Bitmap histImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            int[] hist = new int[256];

            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;

            unsafe
            {
                byte* srcScan0 = (byte*)srcData.Scan0;
                for (int y = 0; y < src.Height; y++)
                {
                    byte* srcRow = srcScan0 + (y * srcData.Stride);
                    for (int x = 0; x < src.Width; x++)
                    {
                        byte b = srcRow[x * bytesPerPixel + 0];
                        byte g = srcRow[x * bytesPerPixel + 1];
                        byte r = srcRow[x * bytesPerPixel + 2];
                        int gray = (int)(r * 0.299 + g * 0.587 + b * 0.114);
                        hist[gray]++;
                    }
                }
            }
            src.UnlockBits(srcData);

            int max = hist.Max();
            using (Graphics g = Graphics.FromImage(histImage))
            {
                g.Clear(Color.White);
            }
            for (int x = 0; x < width; x++)
            {
                int value = (int)((hist[x] / (float)max) * (height - 1));
                for (int y = height - 1; y >= height - value; y--)
                {
                    histImage.SetPixel(x, y, Color.Black);
                }
            }
            return histImage;
        }

        public static Bitmap Sepia(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height, src.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);

            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);
            BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(src.PixelFormat) / 8;
            int height = src.Height;
            int width = src.Width;

            unsafe
            {
                byte* srcScan0 = (byte*)srcData.Scan0;
                byte* destScan0 = (byte*)destData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* srcRow = srcScan0 + (y * srcData.Stride);
                    byte* destRow = destScan0 + (y * destData.Stride);
                    for (int x = 0; x < width; x++)
                    {
                        byte b = srcRow[x * bytesPerPixel + 0];
                        byte g = srcRow[x * bytesPerPixel + 1];
                        byte r = srcRow[x * bytesPerPixel + 2];

                        int tr = (int)(r * 0.393 + g * 0.769 + b * 0.189);
                        int tg = (int)(r * 0.349 + g * 0.686 + b * 0.168);
                        int tb = (int)(r * 0.272 + g * 0.534 + b * 0.131);

                        destRow[x * bytesPerPixel + 2] = (byte)Math.Min(255, tr); // R
                        destRow[x * bytesPerPixel + 1] = (byte)Math.Min(255, tg); // G
                        destRow[x * bytesPerPixel + 0] = (byte)Math.Min(255, tb); // B
                        if (bytesPerPixel == 4)
                            destRow[x * bytesPerPixel + 3] = srcRow[x * bytesPerPixel + 3]; // alpha
                    }
                }
            }

            src.UnlockBits(srcData);
            dest.UnlockBits(destData);
            return dest;
        }

        public static Bitmap Subtract(Bitmap src1, Bitmap src2)
        {
            int width = Math.Min(src1.Width, src2.Width);
            int height = Math.Min(src1.Height, src2.Height);
            Bitmap dest = new Bitmap(width, height, src1.PixelFormat);
            Rectangle rect = new Rectangle(0, 0, width, height);

            BitmapData data1 = src1.LockBits(rect, ImageLockMode.ReadOnly, src1.PixelFormat);
            BitmapData data2 = src2.LockBits(rect, ImageLockMode.ReadOnly, src2.PixelFormat);
            BitmapData destData = dest.LockBits(rect, ImageLockMode.WriteOnly, src1.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(src1.PixelFormat) / 8;

            int mygreen = 100;
            int threshold = 60;

            unsafe
            {
                byte* scan0_1 = (byte*)data1.Scan0;
                byte* scan0_2 = (byte*)data2.Scan0;
                byte* destScan0 = (byte*)destData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* row1 = scan0_1 + y * data1.Stride;
                    byte* row2 = scan0_2 + y * data2.Stride;
                    byte* destRow = destScan0 + y * destData.Stride;
                    for (int x = 0; x < width; x++)
                    {
                        byte b = row1[x * bytesPerPixel + 0];
                        byte g = row1[x * bytesPerPixel + 1];
                        byte r = row1[x * bytesPerPixel + 2];

                        if (g > mygreen && g - r > threshold && g - b > threshold)
                        {
                            // Use background pixel
                            destRow[x * bytesPerPixel + 0] = row2[x * bytesPerPixel + 0];
                            destRow[x * bytesPerPixel + 1] = row2[x * bytesPerPixel + 1];
                            destRow[x * bytesPerPixel + 2] = row2[x * bytesPerPixel + 2];
                            if (bytesPerPixel == 4)
                                destRow[x * bytesPerPixel + 3] = row1[x * bytesPerPixel + 3];
                        }
                        else
                        {
                            // Use foreground pixel
                            destRow[x * bytesPerPixel + 0] = b;
                            destRow[x * bytesPerPixel + 1] = g;
                            destRow[x * bytesPerPixel + 2] = r;
                            if (bytesPerPixel == 4)
                                destRow[x * bytesPerPixel + 3] = row1[x * bytesPerPixel + 3];
                        }
                    }
                }
            }

            src1.UnlockBits(data1);
            src2.UnlockBits(data2);
            dest.UnlockBits(destData);
            return dest;
        }
    }
}
