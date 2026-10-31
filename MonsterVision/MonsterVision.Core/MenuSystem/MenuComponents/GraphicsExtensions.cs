using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MonsterVision.Core
{
    static class GraphicsExtensions
    {
        static readonly ImageAttributes WrapAttributes = GetWrapAttributes();

        static ImageAttributes GetWrapAttributes()
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetWrapMode(WrapMode.TileFlipXY);
            return attr;
        }

        public static void DrawImageHighQuality(this Graphics gfx, Image image, Rectangle destination)
        {
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(image, destination, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, WrapAttributes);
            gfx.InterpolationMode = InterpolationMode.Default;
        }
    }

    static class Tint
    {
        static ImageAttributes GetTintAttributes(int red, int green, int blue)
        {
            ImageAttributes attr = new ImageAttributes();
            attr.SetColorMatrix(new ColorMatrix(new float[][]
            {
                new float[] { red / 255f, 0, 0, 0, 0},
                new float[] {0, green / 255f, 0, 0, 0},
                new float[] {0, 0, blue / 255f, 0, 0},
                new float[] {0, 0, 0, 0.9f, 0},
                new float[] {0, 0, 0, 0, 1}
            }));
            return attr;
        }

        public static readonly ImageAttributes Green = GetTintAttributes(106, 160, 67); //Main
        public static readonly ImageAttributes Lime = GetTintAttributes(219, 224, 72); //Play
        public static readonly ImageAttributes Brown = GetTintAttributes(160, 84, 24); //Other1
        public static readonly ImageAttributes White = GetTintAttributes(228, 226, 227); //Other2
        public static readonly ImageAttributes Blue = GetTintAttributes(173, 218, 227); //Episodes1
        public static readonly ImageAttributes LightGreen = GetTintAttributes(134, 177, 66); //Episodes2
    }
}
