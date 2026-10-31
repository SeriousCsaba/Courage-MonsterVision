using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public class EpisodeDatabase
    {
        public List<EpisodeInfo> Info { get; private set; }
        public EpisodeInfo Selected { get; private set; }
        public TimeSpan PreferredStartingTime { get; private set; }

        public EpisodeDatabase()
        {
            Info = new List<EpisodeInfo>();
            for (int s = 1; s <= 4; s++)
                for (int e = 1; e <= 13; e++)
                    for (int c = 1; c <= 2; c++)
                        try
                        {
                            Info.Add(new EpisodeInfo(s, e, c));
                            if (Info[Info.Count - 1].Title == null)
                                Info.RemoveAt(Info.Count - 1);
                        }
                        catch
                        {
                            FormMain.ShowErrorMessage("Unable to load S" + s + "E" + e + "C" + c + " info");
                            return;
                        }
            PreferredStartingTime = TimeSpan.Zero;
        }

        public string GetTitleEpisode1()
        {
            if (Selected == null)
                return "";
            return GetTitleEpisode1(Selected.Season, Selected.Episode);
        }

        public string GetTitleEpisode1(int season, int episode)
        {
            foreach (EpisodeInfo ep in Info)
                if (ep.Season == season && ep.Episode == episode && ep.Chapter == 1)
                    return ep.Title;
            return "";
        }

        public string GetTitleEpisode2()
        {
            if (Selected == null)
                return "";
            return GetTitleEpisode2(Selected.Season, Selected.Episode);
        }

        public string GetTitleEpisode2(int season, int episode)
        {
            foreach (EpisodeInfo ep in Info)
                if (ep.Season == season && ep.Episode == episode && ep.Chapter == 2)
                    return ep.Title;
            return "";
        }


        public void SelectEpisode(int season, int episode, int chapter)
        {
            foreach (EpisodeInfo ep in Info)
                if (ep.Season == season && ep.Episode == episode && ep.Chapter == chapter)
                {
                    PreferredStartingTime = ep.Timestamp;
                    Selected = ep;
                    break;
                }
        }

        public void SelectEpisode(int season, int episode)
        {
            foreach (EpisodeInfo ep in Info)
                if (ep.Season == season && ep.Episode == episode)
                {
                    PreferredStartingTime = TimeSpan.Zero;
                    Selected = ep;
                    break;
                }
        }

        public void SelectEpisode(string title, string subtitleSearch = null)
        {
            foreach (EpisodeInfo ep in Info)
                if (ep.Title == title)
                {
                    Selected = ep;
                    PreferredStartingTime = ep.Timestamp;
                    if (subtitleSearch != null)
                    {
                        try
                        {
                            string[] lines = File.ReadAllLines(Selected.FileSUB);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].ToLower().Contains(subtitleSearch))
                                {
                                    for (int j = 1; j < 10; j++)
                                        if (lines[i - j].Contains("-->"))
                                        {
                                            PreferredStartingTime = TimeSpan.Parse(lines[i - j].Split(',')[0]);
                                            break;
                                        }
                                    break;
                                }
                            }
                        }
                        catch { }
                    }
                    break;
                }
        }

        public void SelectEpisode(int index)
        {
            Selected = Info[index];
            PreferredStartingTime = Info[index].Timestamp;
        }

        public void ClearSelection()
        {
            Selected = null;
            PreferredStartingTime = TimeSpan.Zero;
        }
    }

    public partial class FormMain : Form
    {
        EpisodeDatabase episodes;

        void InitializeEpisodes()
        {
            episodes = new EpisodeDatabase();
            searchPanel.Initialize(episodes, playerPanel.PlayEpisode);
            specialPanel.Initialize(episodes, playerPanel.PlayEpisode, playerPanel.PlayVideo);
        }
    }
}
