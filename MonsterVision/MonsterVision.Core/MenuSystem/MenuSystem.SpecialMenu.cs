using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemSpecialMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen menuSpecialRand, menuSpecial;

        void CreateSpecialMenu()
        {
            //Special panel with random button
            menuSpecialRand = new MenuScreen(Properties.Resources.menu_special1);

            MenuButton buttonSpecialRandom = new MenuButton();
            buttonSpecialRandom.SetClickAction(new Rectangle(390, 378, 77, 54), specialPanel.SelectRandom);
            buttonSpecialRandom.SetHoverImage(Properties.Resources.select_bone, new Point(387, 357), Tint.White);
            menuSpecialRand.AddButton(buttonSpecialRandom);

            MenuButton buttonSpecialPlay = new MenuButton();
            buttonSpecialPlay.SetClickAction(new Rectangle(485, 378, 77, 54), specialPanel.Play);
            buttonSpecialPlay.SetHoverImage(Properties.Resources.select_bone, new Point(482, 357), Tint.White);
            menuSpecialRand.AddButton(buttonSpecialPlay);

            MenuButton buttonSpecialBack = new MenuButton();
            buttonSpecialBack.SetClickAction(new Rectangle(576, 378, 69, 54), CloseSpecialMenu);
            buttonSpecialBack.SetHoverImage(Properties.Resources.select_bone, new Point(570, 357), Tint.White);
            menuSpecialRand.AddButton(buttonSpecialBack, isBackButton: true);

            //Special panel without random button
            menuSpecial = new MenuScreen(Properties.Resources.menu_special2);
            menuSpecial.AddButton(buttonSpecialPlay);
            menuSpecial.AddButton(buttonSpecialBack, isBackButton: true);


            specialPanel.TabChanged += SpecialPanel_TabChanged;
        }

        void OpenSpecialMenu()
        {
            specialPanel.Reset();
            specialPanel.Visible = true;
            Invalidate();
        }

        void CloseSpecialMenu()
        {
            specialPanel.Visible = false;
            Invalidate();
            currentMenu = menuPlay;
        }

        private void SpecialPanel_TabChanged(object sender, bool showRandMenu)
        {
            if (showRandMenu)
                currentMenu = menuSpecialRand;
            else
                currentMenu = menuSpecial;
            Refresh();
        }
    }
}
