using System.Drawing;

namespace MonsterVision.Core
{
    class MenuButtonEpisodeSwitcher : MenuButton
    {
        MenuButtonEpisode episodeButton;

        public MenuButtonEpisodeSwitcher(MenuButtonEpisode episodeButton)
        {
            this.episodeButton = episodeButton;
        }

        public override bool CheckHover(Point pos)
        {
            bool wasHovered = hovered;
            base.CheckHover(pos);
            if (hovered)
                episodeButton.ForceSecondary();
            else if (wasHovered)
                episodeButton.HideSecondary();
            return hovered;
        }
    }
}
