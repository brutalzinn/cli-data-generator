using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGenerator.Utils
{
    public static class BitmapUtils
    {
       public static Bitmap GenerateBitmap(int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);

            Random rand = new Random();

            int r = rand.Next(0, 255);
            int g = rand.Next(0, 255);
            int b = rand.Next(0, 255);
            int a = rand.Next(0, 255);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            return bmp;
        }

        public static string BitmapToBase64(this Bitmap bmp)
        {
            using (MemoryStream jpegStream = new MemoryStream())
            {
                bmp.Save(jpegStream, ImageFormat.Jpeg);
                return Convert.ToBase64String(jpegStream.ToArray());
            }
        }

        public static void SaveBitmap(this Bitmap bmp, string filename, ImageFormat format)
        {
            if (!Directory.Exists("imgs"))
            {
                Directory.CreateDirectory("imgs");
            }
            bmp.Save(filename, format);
        }
    }
}
