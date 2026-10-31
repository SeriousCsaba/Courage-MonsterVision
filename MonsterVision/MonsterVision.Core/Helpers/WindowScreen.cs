using System;
using System.Drawing;

namespace MonsterVision.Core
{
    static class WindowScreen
    {
        static readonly Size OriginalAreaSize = new Size(720, 480); //Image size
        static readonly Size OriginalSize = new Size(960, 720); //Original window size
        static readonly double AspectRatio = OriginalSize.Width / (double)OriginalSize.Height;

        public static Rectangle Area { get { return area; } }
        static Rectangle area;

        static PointF scale;
        public static Rectangle Scale(Rectangle rectangle) => new Rectangle(Scale(rectangle.Location), Scale(rectangle.Size));
        public static Rectangle Scale(Point location, Size size) => new Rectangle(Scale(location), Scale(size));
        public static Point Scale(Point location) => new Point((int)(location.X * scale.X + area.X), (int)(location.Y * scale.Y + area.Y));
        public static Size Scale(Size size) => new Size((int)(size.Width * scale.X), (int)(size.Height * scale.Y));
        public static int ScaleX(int x) => (int)(x / (double)OriginalSize.Width * area.Width);
        public static int ScaleY(int y) => (int)(y / (double)OriginalSize.Height * area.Height);

        public static bool Fullscreen { get; set; }

        public static Rectangle CalculateArea(Size clientSize, double aspectRatio)
        {
            Rectangle area = new Rectangle();

            //Update size
            int newWidth = (int)Math.Ceiling(clientSize.Height * aspectRatio);
            int newHeight = (int)Math.Ceiling(clientSize.Width / aspectRatio);
            if (clientSize.Width > newWidth && clientSize.Height > newHeight)
            {
                area.Width = clientSize.Width;
                area.Height = newHeight;
            }
            else
            {
                area.Width = newWidth;
                area.Height = clientSize.Height;
            }

            //Update position
            area.X = (clientSize.Width - area.Width) / 2;
            area.Y = (clientSize.Height - area.Height) / 2;

            return area;
        }

        public static void SetupArea(Size clientSize)
        {
            area = CalculateArea(clientSize, AspectRatio);

            //Update scale
            scale.X = (float)area.Width / OriginalAreaSize.Width;
            scale.Y = (float)area.Height / OriginalAreaSize.Height;
        }
    }
}
