using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace MonsterVision.Core
{
    class MenuButton
    {
        protected Point location;
        protected Rectangle area;
        protected Image image;
        Action onClick;

        HoverIcon hoverIcon;
        protected bool hovered;

        public MenuButton()
        {

        }

        public MenuButton(Image image)
        {
            this.image = image;
        }

        public MenuButton(Image image, Point location) : this(image)
        {
            this.location = location;
        }

        public void SetHoverImage(HoverIcon hoverIcon)
        {
            this.hoverIcon = hoverIcon;
        }

        public void SetHoverImage(Image image, Point location, ImageAttributes tint)
        {
            hoverIcon = new HoverIcon(image, location, tint);
        }

        public void SetClickAction(Action onClick)
        {
            this.onClick = onClick;
        }

        public void SetClickAction(Rectangle area, Action onClick)
        {
            this.area = area;
            this.onClick = onClick;
        }

        public virtual bool CheckHover(Point pos)
        {
            hovered = WindowScreen.Scale(area).Contains(pos);
            return hovered;
        }

        public bool CheckClick()
        {
            if (hovered)
                onClick?.Invoke();
            return hovered && onClick != null;
        }

        public void PerformClick()
        {
            onClick?.Invoke();
        }

        protected virtual void DrawImage(Graphics gfx)
        {
            if (image != null)
                gfx.DrawImage(image, WindowScreen.Scale(location, image.Size));
        }

        public void Draw(Graphics gfx)
        {
            //Debug
            //gfx.FillRectangle(new SolidBrush(Color.FromArgb(128, Color.Red)), WindowScreen.Scale(area));

            DrawImage(gfx);

            if (hovered)
                hoverIcon?.Draw(gfx);
        }
    }
}
