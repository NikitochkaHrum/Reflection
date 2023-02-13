using PluginInterface;
using System.Drawing;
using System.Drawing.Imaging;

namespace Transforms
{
    [Version(1, 0)]
    public class ReverseTransform : IPlugin
    {
        public string Name
        {
            get
            {
                return "Увеличение яркости";
            }
        }

        public string Author
        {
            get
            {
                return "Me";
            }
        }

        public void Transform(Bitmap bmap)
        {
            int brightness = 100;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    Color c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb(cR, cG, cB));
                }
            }
            //for (int i = 0; i < bmap.Width; ++i)
            //    for (int j = 0; j < bmap.Height / 2; ++j)
            //    {
            //        Color color = bmap.GetPixel(i, j);
            //        bmap.SetPixel(i, j, bmap.GetPixel(i, bmap.Height - j - 1));
            //        bmap.SetPixel(i, bmap.Height - j - 1, color);
            //    }

        }
    }
}
