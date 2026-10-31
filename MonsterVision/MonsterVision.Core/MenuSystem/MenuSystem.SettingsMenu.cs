using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemSettingsMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        MenuScreen menuSettings;

        void CreateSettingsMenu()
        {
            menuSettings = new MenuScreen(Properties.Resources.menu_settings);

            MenuCheckbox buttonSettingsAudio = new MenuCheckbox(
                imageOff: Properties.Resources.settings_hun,
                imageOn: Properties.Resources.settings_eng,
                location: new Point(412, 92),
                isChecked: () => Settings.EnglishAudio);
            buttonSettingsAudio.SetClickAction(() =>
                {
                    Settings.EnglishAudio = !Settings.EnglishAudio;
                    Settings.Save();
                }
            );
            buttonSettingsAudio.SetHoverImage(Properties.Resources.select_bone, new Point(406, 110), Tint.White);
            menuSettings.AddButton(buttonSettingsAudio);

            MenuCheckbox buttonSettingsSubtitles = new MenuCheckbox(
                imageOff: Properties.Resources.settings_off,
                imageOn: Properties.Resources.settings_on,
                location: new Point(416, 122),
                isChecked: () => Settings.Subtitles);
            buttonSettingsSubtitles.SetClickAction(() =>
                {
                    Settings.Subtitles = !Settings.Subtitles;
                    Settings.Save();
                }
            );
            buttonSettingsSubtitles.SetHoverImage(Properties.Resources.select_bone, new Point(406, 140), Tint.White);
            menuSettings.AddButton(buttonSettingsSubtitles);

            MenuCheckbox buttonSettingsLogo = new MenuCheckbox(
                imageOff: Properties.Resources.settings_off,
                imageOn: Properties.Resources.settings_on,
                location: new Point(416, 152),
                isChecked: () => Settings.LogoIsSet);
            buttonSettingsLogo.SetClickAction(() =>
                {
                    Settings.Logo = playerPanel.LookForLogo();
                    Settings.Save();
                }
            );
            buttonSettingsLogo.SetHoverImage(Properties.Resources.select_bone, new Point(406, 170), Tint.White);
            menuSettings.AddButton(buttonSettingsLogo);

            MenuButton buttonSettingsReset = new MenuButton();
            buttonSettingsReset.SetClickAction(new Rectangle(485, 378, 77, 54), Settings.Reset);
            buttonSettingsReset.SetHoverImage(Properties.Resources.select_bone, new Point(482, 357), Tint.White);
            menuSettings.AddButton(buttonSettingsReset);

            MenuButton buttonSettingsBack = new MenuButton();
            buttonSettingsBack.SetClickAction(new Rectangle(576, 378, 69, 54), () => currentMenu = menuMain);
            buttonSettingsBack.SetHoverImage(Properties.Resources.select_bone, new Point(570, 357), Tint.White);
            menuSettings.AddButton(buttonSettingsBack, isBackButton: true);
        }
    }
}
