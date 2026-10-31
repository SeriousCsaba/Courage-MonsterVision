using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystem { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen currentMenu;
        bool hand;

        void InitializeMenu()
        {
            CreateMainMenu();
            CreatePlayMenu();
            CreateSearchMenu();
            CreateSettingsMenu();
            CreateSpecialMenu();
            CreateEpisodesMenu();
            currentMenu = menuMain;
        }

        void MenuMouseMove(Point location)
        {
            bool hand = currentMenu.CheckHover(location);
            if (this.hand != hand)
            {
                Cursor = hand ? Cursors.Hand : Cursors.Default;
                this.hand = hand;
            }
            Invalidate();
        }

        bool MenuMouseLeftClick()
        {
            bool click = currentMenu.CheckClick();
            if (click)
                MenuMouseMove(Point.Empty);
            return click;
        }

        void MenuUpdate()
        {
            currentMenu.Update();
            Invalidate();
        }

        void MenuDraw(Graphics gfx)
        {
            currentMenu.Draw(gfx);
        }
    }
}
