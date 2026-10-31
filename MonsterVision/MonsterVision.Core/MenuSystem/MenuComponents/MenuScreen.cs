using System.Collections.Generic;
using System.Drawing;

namespace MonsterVision.Core
{
    class MenuScreen
    {
        Image background;
        List<MenuButton> buttons;
        public MenuButton Back { get; private set; }

        public MenuScreen(Image background)
        {
            this.background = background;
            buttons = new List<MenuButton>();
        }

        public void AddButton(MenuButton button, bool isBackButton = false)
        {
            buttons.Add(button);
            if (isBackButton)
                Back = button;
        }

        public bool CheckHover(Point pos)
        {
            bool hand = false;
            foreach (MenuButton button in buttons)
                hand |= button.CheckHover(pos);
            return hand;
        }

        public bool CheckClick()
        {
            bool result = false;
            foreach (MenuButton button in buttons)
                result |= button.CheckClick();
            return result;
        }

        public void Update()
        {
            foreach (MenuButton button in buttons)
                if (button is MenuButtonEpisode episodeButton)
                    episodeButton.UpdateTimer();
        }

        public void Draw(Graphics gfx)
        {
            gfx.DrawImageHighQuality(background, WindowScreen.Area);
            foreach (MenuButton button in buttons)
                button.Draw(gfx);
        }
    }
}
