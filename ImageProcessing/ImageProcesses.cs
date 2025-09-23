using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageProcessing
{
    public static class Processes
    {
        public static Bitmap result;

        public static Bitmap Copy(Bitmap src)
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
        public static Bitmap GreyScale(Bitmap src)
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
        public static Bitmap InvertColor(Bitmap src)
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

        public static Bitmap Histogram(Bitmap src)
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

        public static Bitmap Sepia(Bitmap src)
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

        public static Bitmap Subtract(Bitmap src1, Bitmap src2)
        {
            int width = Math.Min(src1.Width, src2.Width);
            int height = Math.Min(src1.Height, src2.Height);
            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color c1 = src1.GetPixel(x, y);
                    Color c2 = src2.GetPixel(x, y);
                    int r = Math.Max(0, c1.R - c2.R);
                    int g = Math.Max(0, c1.G - c2.G);
                    int b = Math.Max(0, c1.B - c2.B);
                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return result;
        }
    }
}
