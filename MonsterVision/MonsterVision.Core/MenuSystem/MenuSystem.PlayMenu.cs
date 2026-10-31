using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemPlayMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen menuPlay;

        void CreatePlayMenu()
        {
            menuPlay = new MenuScreen(Properties.Resources.menu_play);

            MenuButton buttonPlayS1 = new MenuButton();
            buttonPlayS1.SetClickAction(new Rectangle(436, 304, 32, 32), () => currentMenu = menuSeason1Episodes1);
            buttonPlayS1.SetHoverImage(Properties.Resources.select_skull1, new Point(397, 270), Tint.Lime);
            menuPlay.AddButton(buttonPlayS1);

            MenuButton buttonPlayS2 = new MenuButton();
            buttonPlayS2.SetClickAction(new Rectangle(473, 304, 32, 32), () => currentMenu = menuSeason2Episodes1);
            buttonPlayS2.SetHoverImage(Properties.Resources.select_skull2, new Point(580, 270), Tint.Lime);
            menuPlay.AddButton(buttonPlayS2);

            MenuButton buttonPlayS3 = new MenuButton();
            buttonPlayS3.SetClickAction(new Rectangle(513, 304, 32, 32), () => currentMenu = menuSeason3Episodes1);
            buttonPlayS3.SetHoverImage(Properties.Resources.select_skull1, new Point(397, 270), Tint.Lime);
            menuPlay.AddButton(buttonPlayS3);

            MenuButton buttonPlayS4 = new MenuButton();
            buttonPlayS4.SetClickAction(new Rectangle(556, 304, 32, 32), () => currentMenu = menuSeason4Episodes1);
            buttonPlayS4.SetHoverImage(Properties.Resources.select_skull2, new Point(580, 270), Tint.Lime);
            menuPlay.AddButton(buttonPlayS4);

            MenuButton buttonPlaySpecial = new MenuButton();
            buttonPlaySpecial.SetClickAction(new Rectangle(445, 345, 138, 27), OpenSpecialMenu);
            buttonPlaySpecial.SetHoverImage(Properties.Resources.select_skull2, new Point(577, 315), Tint.Lime);
            menuPlay.AddButton(buttonPlaySpecial);

            MenuButton buttonPlayBack = new MenuButton();
            buttonPlayBack.SetClickAction(new Rectangle(469, 386, 92, 25), () => currentMenu = menuMain);
            buttonPlayBack.SetHoverImage(Properties.Resources.select_skull1, new Point(561, 375), Tint.Lime);
            menuPlay.AddButton(buttonPlayBack, isBackButton: true);
        }
    }
}
