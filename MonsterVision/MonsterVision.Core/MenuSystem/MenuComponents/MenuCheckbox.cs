using System;
using System.Drawing;

namespace MonsterVision.Core
{
    class MenuCheckbox : MenuButton
    {
        Func<bool> IsChecked; //Pass a getter to this
        Image imageOn;

        Image currentImage => IsChecked.Invoke() == true ? imageOn : image;

        public MenuCheckbox(Image imageOff, Image imageOn, Point location, Func<bool> isChecked) : base(imageOff, location)
        {
            area = new Rectangle(location, image.Width > imageOn.Width ? image.Size : imageOn.Size);
            //this.location.X -= area.Width / 2;
            this.imageOn = imageOn;
            IsChecked = isChecked;
        }

        protected override void DrawImage(Graphics gfx)
        {
            gfx.DrawImage(currentImage, WindowScreen.Scale(new Point(location.X + area.Width / 2 - currentImage.Size.Width / 2, location.Y), currentImage.Size));
        }
    }
}
