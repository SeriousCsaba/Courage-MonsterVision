using System.Drawing;
using System.Drawing.Imaging;

namespace MonsterVision.Core
{
    class HoverIcon
    {
        Image image;
        Point location;
        ImageAttributes tint;

        public HoverIcon(Image image, Point location, ImageAttributes tint)
        {
            this.image = image;
            this.location = location;
            this.tint = tint;
        }

        public void Draw(Graphics gfx)
        {
            gfx.DrawImage(image, WindowScreen.Scale(location, image.Size), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, tint);
        }
    }
}
