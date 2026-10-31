using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemSearchMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen menuSearch;

        void CreateSearchMenu()
        {
            menuSearch = new MenuScreen(Properties.Resources.menu_search);

            MenuButton buttonSearchPlay = new MenuButton();
            buttonSearchPlay.SetClickAction(new Rectangle(485, 378, 77, 54), searchPanel.Play);
            buttonSearchPlay.SetHoverImage(Properties.Resources.select_bone, new Point(482, 357), Tint.Brown);
            menuSearch.AddButton(buttonSearchPlay);

            MenuButton buttonSearchBack = new MenuButton();
            buttonSearchBack.SetClickAction(new Rectangle(576, 378, 69, 54), CloseSearchMenu);
            buttonSearchBack.SetHoverImage(Properties.Resources.select_bone, new Point(570, 357), Tint.Brown);
            menuSearch.AddButton(buttonSearchBack, isBackButton: true);
        }

        void OpenSearchMenu()
        {
            searchPanel.Reset();
            searchPanel.Visible = true;
            Invalidate();
            currentMenu = menuSearch;
        }

        void CloseSearchMenu()
        {
            searchPanel.Visible = false;
            Invalidate();
            currentMenu = menuMain;
        }
    }
}
