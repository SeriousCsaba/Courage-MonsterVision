using System;
using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class MenuSystemEpisodesMenu { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class FormMain : Form
    {
        readonly HoverIcon[] Episodes1HoverIcons = new HoverIcon[] {
                new HoverIcon(Properties.Resources.select_bat1, new Point(194, 70), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat2, new Point(396, 56), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat2, new Point(474, 126), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat3, new Point(197, 208), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat4, new Point(390, 211), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat5, new Point(471, 188), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat4, new Point(185, 338), Tint.Blue),
                new HoverIcon(Properties.Resources.select_bat6, new Point(383,302), Tint.Blue)
            };

        readonly HoverIcon[] Episodes2HoverIcons = new HoverIcon[] {
                new HoverIcon(Properties.Resources.select_bat1, new Point(194, 70), Tint.LightGreen),
                new HoverIcon(Properties.Resources.select_bat4, new Point(393,121), Tint.LightGreen),
                new HoverIcon(Properties.Resources.select_bat2, new Point(571,130), Tint.LightGreen),
                new HoverIcon(Properties.Resources.select_bat4, new Point(271,287), Tint.LightGreen),
                new HoverIcon(Properties.Resources.select_bat6, new Point(458,238), Tint.LightGreen)
            };

        readonly int TitleHeight = 13;
        readonly Point[] TitleLocations = new Point[13] {
                new Point(157, 172),
                new Point(366, 131),
                new Point(570, 160),
                new Point(160, 282),
                new Point(354, 264),
                new Point(561, 295),
                new Point(152, 408),
                new Point(338, 402),
                new Point(156, 172),
                new Point(358, 192),
                new Point(558, 160),
                new Point(372, 360),
                new Point(562, 321)
            };

        MenuScreen
            menuSeason1Episodes1, menuSeason2Episodes1, menuSeason3Episodes1, menuSeason4Episodes1,
            menuSeason1Episodes2, menuSeason2Episodes2, menuSeason3Episodes2, menuSeason4Episodes2;

        void CreateEpisodesMenu()
        {
            menuSeason1Episodes1 = CreateEpisodes1Menu(
                season: 1,
                background: Properties.Resources.season1_episodes1,
                thumbnails1: Properties.Resources.season1_episodes1_thumbnails1,
                thumbnails2: Properties.Resources.season1_episodes1_thumbnails2,
                next: () => currentMenu = menuSeason1Episodes2,
                titleWidths: new int[16] { 162, 125, 154, 207, 148, 57, 169, 78, 145, 87, 116, 123, 124, 116, 177, 165 });

            menuSeason2Episodes1 = CreateEpisodes1Menu(
               season: 2,
               background: Properties.Resources.season2_episodes1,
               thumbnails1: Properties.Resources.season2_episodes1_thumbnails1,
               thumbnails2: Properties.Resources.season2_episodes1_thumbnails2,
               next: () => currentMenu = menuSeason2Episodes2,
               titleWidths: new int[16] { 176, 84, 195, 127, 100, 146, 175, 99, 107, 116, 101, 76, 81, 184, 86, 142 });

            menuSeason3Episodes1 = CreateEpisodes1Menu(
               season: 3,
               background: Properties.Resources.season3_episodes1,
               thumbnails1: Properties.Resources.season3_episodes1_thumbnails1,
               thumbnails2: Properties.Resources.season3_episodes1_thumbnails2,
               next: () => currentMenu = menuSeason3Episodes2,
               titleWidths: new int[16] { 153, 178, 120, 77, 107, 132, 127, 159, 110, 188, 124, 112, 133, 83, 160, 145 });

            menuSeason4Episodes1 = CreateEpisodes1Menu(
               season: 4,
               background: Properties.Resources.season4_episodes1,
               thumbnails1: Properties.Resources.season4_episodes1_thumbnails1,
               thumbnails2: Properties.Resources.season4_episodes1_thumbnails2,
               next: () => currentMenu = menuSeason4Episodes2,
               titleWidths: new int[16] { 98, 98, 103, 73, 111, 114, 131, 196, 159, 65, 106, 121, 62, 0, 179, 87 });


            menuSeason1Episodes2 = CreateEpisodes2Menu(
                season: 1,
                background: Properties.Resources.season1_episodes2,
                thumbnails1: Properties.Resources.season1_episodes2_thumbnails1,
                thumbnails2: Properties.Resources.season1_episodes2_thumbnails2,
                prev: () => currentMenu = menuSeason1Episodes1,
                titleWidths: new int[10] { 170, 158, 143, 156, 91, 64, 123, 220, 77, 103 },
                titleWidthsExtra: new int[10] { 0, 0, 0, 174, 0, 0, 166, 0, 0, 0 });

            menuSeason2Episodes2 = CreateEpisodes2Menu(
                season: 2,
                background: Properties.Resources.season2_episodes2,
                thumbnails1: Properties.Resources.season2_episodes2_thumbnails1,
                thumbnails2: Properties.Resources.season2_episodes2_thumbnails2,
                prev: () => currentMenu = menuSeason2Episodes1,
                titleWidths: new int[10] { 129, 95, 137, 112, 71, 139, 152, 152, 149, 0 });

            menuSeason3Episodes2 = CreateEpisodes2Menu(
                season: 3,
                background: Properties.Resources.season3_episodes2,
                thumbnails1: Properties.Resources.season3_episodes2_thumbnails1,
                thumbnails2: Properties.Resources.season3_episodes2_thumbnails2,
                prev: () => currentMenu = menuSeason3Episodes1,
                titleWidths: new int[10] { 89, 112, 91, 129, 95, 133, 89, 96, 77, 176 });

            menuSeason4Episodes2 = CreateEpisodes2Menu(
                season: 4,
                background: Properties.Resources.season4_episodes2,
                thumbnails1: Properties.Resources.season4_episodes2_thumbnails1,
                thumbnails2: Properties.Resources.season4_episodes2_thumbnails2,
                prev: () => currentMenu = menuSeason4Episodes1,
                titleWidths: new int[10] { 85, 123, 143, 231, 111, 100, 109, 142, 195, 46 });
        }

        MenuScreen CreateEpisodes1Menu(int season, Image background, Image thumbnails1, Image thumbnails2, Action next, int[] titleWidths, int[] titleWidthsExtra = null)
        {
            MenuScreen menuEpisodes1 = new MenuScreen(Properties.Resources.menu_episodes1);

            menuEpisodes1.AddButton(new MenuButton(background));

            for (int i = 0; i < 8; i++)
                AddEpisodeButtons(
                    menuEpisodes1,
                    Episodes1HoverIcons[i],
                    thumbnails1,
                    thumbnails2,
                    season: season,
                    index: i,
                    widthA: titleWidths[i * 2],
                    widthB: titleWidths[i * 2 + 1],
                    widthExtraA: titleWidthsExtra == null ? 0 : titleWidthsExtra[i * 2],
                    widthExtraB: titleWidthsExtra == null ? 0 : titleWidthsExtra[i * 2 + 1]);

            MenuButton buttonEpisodes1Back = new MenuButton();
            buttonEpisodes1Back.SetClickAction(new Rectangle(577, 329, 67, 54), () => currentMenu = menuPlay);
            buttonEpisodes1Back.SetHoverImage(Properties.Resources.select_bat8, new Point(536, 331), Tint.Blue);
            menuEpisodes1.AddButton(buttonEpisodes1Back, isBackButton: true);

            MenuButton buttonEpisodes1Next = new MenuButton();
            buttonEpisodes1Next.SetClickAction(new Rectangle(644, 359, 67, 54), next);
            buttonEpisodes1Next.SetHoverImage(Properties.Resources.select_bat7, new Point(647, 404), Tint.Blue);
            menuEpisodes1.AddButton(buttonEpisodes1Next);

            return menuEpisodes1;
        }

        MenuScreen CreateEpisodes2Menu(int season, Image background, Image thumbnails1, Image thumbnails2, Action prev, int[] titleWidths, int[] titleWidthsExtra = null)
        {
            MenuScreen menuEpisodes2 = new MenuScreen(Properties.Resources.menu_episodes2);

            menuEpisodes2.AddButton(new MenuButton(background));

            for (int i = 0; i < 5; i++)
                AddEpisodeButtons(
                    menuEpisodes2,
                    Episodes2HoverIcons[i],
                    thumbnails1,
                    thumbnails2,
                    season: season,
                    index: i + 8,
                    widthA: titleWidths[i * 2],
                    widthB: titleWidths[i * 2 + 1],
                    widthExtraA: titleWidthsExtra == null ? 0 : titleWidthsExtra[i * 2],
                    widthExtraB: titleWidthsExtra == null ? 0 : titleWidthsExtra[i * 2 + 1]);

            MenuButton buttonEpisodes2Back = new MenuButton();
            buttonEpisodes2Back.SetClickAction(new Rectangle(513, 348, 67, 54), () => currentMenu = menuPlay);
            buttonEpisodes2Back.SetHoverImage(Properties.Resources.select_bat8, new Point(472, 350), Tint.LightGreen);
            menuEpisodes2.AddButton(buttonEpisodes2Back, isBackButton: true);

            MenuButton buttonEpisodesPrev = new MenuButton();
            buttonEpisodesPrev.SetClickAction(new Rectangle(580, 378, 67, 54), prev);
            buttonEpisodesPrev.SetHoverImage(Properties.Resources.select_bat7, new Point(582, 425), Tint.LightGreen);
            menuEpisodes2.AddButton(buttonEpisodesPrev);

            return menuEpisodes2;
        }

        void AddEpisodeButtons(MenuScreen menuEpisodes, HoverIcon hoverIcon, Image thumbnails1, Image thumbnails2, int season, int index, int widthA, int widthB, int widthExtraA = 0, int widthExtraB = 0)
        {
            //Episode thumbnail
            MenuButtonEpisode buttonEpisode = new MenuButtonEpisode(thumbnails1, thumbnails2, index);
            buttonEpisode.SetClickAction(() => { episodes.SelectEpisode(season, index + 1); playerPanel.PlayEpisode(); });
            buttonEpisode.SetHoverImage(hoverIcon);
            menuEpisodes.AddButton(buttonEpisode);

            //Episode titles

            int TitleX(int width) => TitleLocations[index].X - width / 2;
            int TitleY(int line, int gap) => TitleLocations[index].Y + TitleHeight * line + gap;
            Action TitleAction(int chapter) => () => { episodes.SelectEpisode(season, index + 1, chapter); playerPanel.PlayEpisode(); };

            // Chapter1

            MenuButton buttonTitleA = new MenuButton();
            buttonTitleA.SetClickAction(new Rectangle(TitleX(widthA), TitleY(line: 0, gap: 0), widthA, TitleHeight), TitleAction(chapter: 1));
            buttonTitleA.SetHoverImage(hoverIcon);
            menuEpisodes.AddButton(buttonTitleA);

            if (widthExtraA > 0)
            {
                MenuButton buttonTitleExtraA = new MenuButton();
                buttonTitleExtraA.SetClickAction(new Rectangle(TitleX(widthExtraA), TitleY(line: 1, gap: 0), widthExtraA, TitleHeight), TitleAction(chapter: 1));
                buttonTitleExtraA.SetHoverImage(hoverIcon);
                menuEpisodes.AddButton(buttonTitleExtraA);
            }

            // Chapter2

            if (widthB > 0)
            {
                MenuButtonEpisodeSwitcher buttonTitleB = new MenuButtonEpisodeSwitcher(buttonEpisode);
                buttonTitleB.SetClickAction(new Rectangle(TitleX(widthB), TitleY(line: widthExtraA > 0 ? 2 : 1, gap: 1), widthB, TitleHeight), TitleAction(chapter: 2));
                buttonTitleB.SetHoverImage(hoverIcon);
                menuEpisodes.AddButton(buttonTitleB);

                if (widthExtraB > 0)
                {
                    MenuButtonEpisodeSwitcher buttonTitleExtraB = new MenuButtonEpisodeSwitcher(buttonEpisode);
                    buttonTitleExtraB.SetClickAction(new Rectangle(TitleX(widthExtraB), TitleY(line: widthExtraA > 0 ? 3 : 2, gap: 1), widthExtraB, TitleHeight), TitleAction(chapter: 2));
                    buttonTitleExtraB.SetHoverImage(hoverIcon);
                    menuEpisodes.AddButton(buttonTitleExtraB);
                }
            }
        }
    }
}
