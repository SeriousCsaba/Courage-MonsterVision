using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemMainMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen menuMain;

        void CreateMainMenu()
        {
            menuMain = new MenuScreen(Properties.Resources.menu_main);

            MenuButton buttonMainPlay = new MenuButton();
            buttonMainPlay.SetClickAction(new Rectangle(469, 266, 91, 29), () => currentMenu = menuPlay);
            buttonMainPlay.SetHoverImage(Properties.Resources.select_skull1, new Point(421, 230), Tint.Green);
            menuMain.AddButton(buttonMainPlay);

            MenuButton buttonMainSearch = new MenuButton();
            buttonMainSearch.SetClickAction(new Rectangle(448, 304, 134, 28), OpenSearchMenu);
            buttonMainSearch.SetHoverImage(Properties.Resources.select_skull2, new Point(390, 295), Tint.Green);
            menuMain.AddButton(buttonMainSearch);

            MenuButton buttonMainSettings = new MenuButton();
            buttonMainSettings.SetClickAction(new Rectangle(436, 345, 156, 27), () => currentMenu = menuSettings);
            buttonMainSettings.SetHoverImage(Properties.Resources.select_skull2, new Point(586, 315), Tint.Green);
            menuMain.AddButton(buttonMainSettings);

            MenuButton buttonMainExit = new MenuButton();
            buttonMainExit.SetClickAction(new Rectangle(474, 385, 79, 25), Application.Exit);
            buttonMainExit.SetHoverImage(Properties.Resources.select_skull1, new Point(555, 374), Tint.Green);
            menuMain.AddButton(buttonMainExit, isBackButton: true);
        }
    }
}
