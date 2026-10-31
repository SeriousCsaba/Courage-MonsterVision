using System.Drawing;

namespace MonsterVision.Core
{
    class MenuButtonEpisode : MenuButton
    {
        static readonly Point[] EpisodeLocations = new Point[] {
            new Point(91, 89),
            new Point(303, 52),
            new Point(500, 70),
            new Point(96, 206),
            new Point(288, 187),
            new Point(498, 211),
            new Point(88, 333),
            new Point(273, 318),
            new Point(91, 89),
            new Point(294, 111),
            new Point(491, 71),
            new Point(308, 284),
            new Point(498, 237)
        };
        static readonly Size EpisodeSize = new Size(130, 72);

        Image secondaryImage;
        bool showSecondary, forcedSecondary;

        public MenuButtonEpisode(Image image, Image secondaryImage, int areaIndex) : base(image)
        {
            this.secondaryImage = secondaryImage;
            area = new Rectangle(EpisodeLocations[areaIndex], EpisodeSize);
        }

        public override bool CheckHover(Point pos)
        {
            base.CheckHover(pos);
            if (!hovered)
                showSecondary = false;
            return hovered;
        }

        public void UpdateTimer()
        {
            showSecondary = hovered ? !showSecondary : false;
        }

        public void ForceSecondary()
        {
            showSecondary = true;
            forcedSecondary = true;
        }

        public void HideSecondary()
        {
            showSecondary = false;
            forcedSecondary = false;
        }

        protected override void DrawImage(Graphics gfx)
        {
            gfx.SetClip(WindowScreen.Scale(area));
            gfx.DrawImage((showSecondary || forcedSecondary) ? secondaryImage : image, WindowScreen.Scale(location, image.Size));
            gfx.ResetClip();
        }
    }
}
