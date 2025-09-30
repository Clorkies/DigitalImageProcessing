using System;
using System.Drawing;
using System.Drawing.Imaging;

public class ConvolutionMatrix

{

    public int TopLeft = 0, TopMid = 0, TopRight = 0;

    public int MidLeft = 0, Pixel = 1, MidRight = 0;

    public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;

    public int Factor = 1;

    public int Offset = 0;

    public void SetAll(int nVal)

    {

        TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight =
                  BottomLeft = BottomMid = BottomRight = nVal;

    }


    public static bool Conv3x3(Bitmap b, ConvolutionMatrix m)

    {

        // Avoid divide by zero errors 

        if (0 == m.Factor)

            return false; Bitmap

        // GDI+ still lies to us - the return format is BGR, NOT RGB.  

        bSrc = (Bitmap)b.Clone();

        BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),

                            ImageLockMode.ReadWrite,

                            PixelFormat.Format24bppRgb);

        BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),

                           ImageLockMode.ReadWrite,

                           PixelFormat.Format24bppRgb);

        int stride = bmData.Stride;

        int stride2 = stride * 2;


        System.IntPtr Scan0 = bmData.Scan0;

        System.IntPtr SrcScan0 = bmSrc.Scan0;

        unsafe
        {

            byte* p = (byte*)(void*)Scan0;

            byte* pSrc = (byte*)(void*)SrcScan0;

            int nOffset = stride - b.Width * 3;

            int nWidth = b.Width - 2;

            int nHeight = b.Height - 2;


            int nPixel;


            for (int y = 0; y < nHeight; ++y)

            {

                for (int x = 0; x < nWidth; ++x)

                {

                    nPixel = ((((pSrc[2] * m.TopLeft) +

                        (pSrc[5] * m.TopMid) +

                        (pSrc[8] * m.TopRight) +

                        (pSrc[2 + stride] * m.MidLeft) +

                        (pSrc[5 + stride] * m.Pixel) +

                        (pSrc[8 + stride] * m.MidRight) +

                        (pSrc[2 + stride2] * m.BottomLeft) +

                        (pSrc[5 + stride2] * m.BottomMid) +

                        (pSrc[8 + stride2] * m.BottomRight))

                        / m.Factor) + m.Offset);



                    if (nPixel < 0) nPixel = 0;

                    if (nPixel > 255) nPixel = 255;

                    p[5 + stride] = (byte)nPixel;



                    nPixel = ((((pSrc[1] * m.TopLeft) +

                        (pSrc[4] * m.TopMid) +

                        (pSrc[7] * m.TopRight) +

                        (pSrc[1 + stride] * m.MidLeft) +

                        (pSrc[4 + stride] * m.Pixel) +

                        (pSrc[7 + stride] * m.MidRight) +

                        (pSrc[1 + stride2] * m.BottomLeft) +

                        (pSrc[4 + stride2] * m.BottomMid) +

                        (pSrc[7 + stride2] * m.BottomRight))

                        / m.Factor) + m.Offset);



                    if (nPixel < 0) nPixel = 0;

                    if (nPixel > 255) nPixel = 255;

                    p[4 + stride] = (byte)nPixel;



                    nPixel = ((((pSrc[0] * m.TopLeft) +

                                   (pSrc[3] * m.TopMid) +

                                   (pSrc[6] * m.TopRight) +

                                   (pSrc[0 + stride] * m.MidLeft) +

                                   (pSrc[3 + stride] * m.Pixel) +

                                   (pSrc[6 + stride] * m.MidRight) +

                                   (pSrc[0 + stride2] * m.BottomLeft) +

                                   (pSrc[3 + stride2] * m.BottomMid) +

                                   (pSrc[6 + stride2] * m.BottomRight))

                        / m.Factor) + m.Offset);



                    if (nPixel < 0) nPixel = 0;

                    if (nPixel > 255) nPixel = 255;

                    p[3 + stride] = (byte)nPixel;



                    p += 3;

                    pSrc += 3;

                }

                p += nOffset;

                pSrc += nOffset;

            }

        }



        b.UnlockBits(bmData);

        bSrc.UnlockBits(bmSrc);

        return true;

    }

    //Emboss
    public static bool Emboss(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = -1;
        m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
        m.Pixel = 4;
        m.Factor = 1;
        m.Offset = 127;
        return Conv3x3(b, m);
    }

    //Smoothen
    public static bool Smooth(Bitmap b, int nWeight /* default to 1 */)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(1);
        m.Pixel = nWeight;
        m.Factor = nWeight + 8;
        return Conv3x3(b, m);

    }


    //Sharpen
    public static bool Sharpen(Bitmap b, int nCenter = 11)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = 0;
        m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = -2;
        m.Pixel = nCenter;
        m.Factor = 3;
        return Conv3x3(b, m);
    }

    //Gaussian Blur
    public static bool GaussianBlur(Bitmap b, int nWeight = 4)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(1);
        m.Pixel = nWeight;
        m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
        m.Factor = nWeight + 12;

        return Conv3x3(b, m);
    }

    //Mean Removal
    public static bool? MeanRemoval(Bitmap b, int nWeight = 9)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(-1);
        m.Pixel = nWeight;
        m.Factor = nWeight - 8;

        return Conv3x3(b, m);
    }

    ///////////
    //Emboss Variants
    ///////////
    public static bool EmbossLaplacian(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(-1);
        m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 0;
        m.Pixel = 4;
        m.Offset = 127;

        return Conv3x3(b, m);
    }


    public static bool EmbossAllDirections(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(-1);
        m.Pixel = 8;
        m.Offset = 127;

        return Conv3x3(b, m);
    }

    public static bool EmbossLossy(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.TopLeft = m.TopRight = m.BottomMid = 1;
        m.TopMid = m.MidLeft = m.MidRight = m.BottomLeft = m.BottomRight = -2;
        m.Pixel = 4;
        m.Offset = 127;

        return Conv3x3(b, m);
    }

    public static bool EmbossHorizontal(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(0);
        m.MidLeft = m.MidRight = -1;
        m.Pixel = 2;
        m.Offset = 127;

        return Conv3x3(b, m);
    }

    public static bool EmbossVertical(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.SetAll(0);
        m.TopMid = -1;
        m.BottomMid = 1;
        m.Offset = 127;

        return Conv3x3(b, m);
    }
    public static bool EmbossHorzVertical(Bitmap b)
    {
        ConvolutionMatrix m = new ConvolutionMatrix();
        m.TopLeft = m.TopRight = m.BottomLeft = m.BottomRight = 0;
        m.TopMid = m.MidLeft = m.MidRight = -1;
        m.Pixel = 4;
        m.Offset = 127;

        return Conv3x3(b, m);
    }
}