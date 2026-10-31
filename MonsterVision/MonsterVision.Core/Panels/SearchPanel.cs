using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class SearchPanel : UserControl
    {
        Rectangle panelSearchBounds, listBoxSearchBounds, listBoxTagsBounds;
        int originalHeight;

        EpisodeDatabase episodes;
        Action PlayEpisode;

        public SearchPanel()
        {
            InitializeComponent();
            this.EnableDoubleBuffering();
            panelSearchBounds = panelSearch.Bounds;
            listBoxSearchBounds = listBoxSearch.Bounds;
            listBoxTagsBounds = listBoxTags.Bounds;
            originalHeight = Height;
        }

        public void Reset()
        {
            textBoxSearch.Clear();
            listBoxSearch.Items.Clear();
            radioButtonTags.Checked = true;
            listBoxTags.Visible = false;
        }

        public void AreaChanged()
        {
            Location = new Point(WindowScreen.Area.X, WindowScreen.Area.Y);
            Width = WindowScreen.Area.Width;
            Height = WindowScreen.ScaleY(originalHeight);
            panelSearch.Location = new Point(WindowScreen.ScaleX(panelSearchBounds.X), WindowScreen.ScaleY(panelSearchBounds.Y));
            panelSearch.Width = WindowScreen.ScaleX(panelSearchBounds.Width);
            listBoxSearch.Location = new Point(WindowScreen.ScaleX(listBoxSearchBounds.X), WindowScreen.ScaleY(listBoxSearchBounds.Y));
            listBoxSearch.Width = WindowScreen.ScaleX(listBoxSearchBounds.Width);
            listBoxSearch.Height = WindowScreen.ScaleY(listBoxSearchBounds.Height);
            listBoxTags.Location = new Point(WindowScreen.ScaleX(listBoxTagsBounds.X), WindowScreen.ScaleY(listBoxTagsBounds.Y));
            listBoxTags.Height = WindowScreen.ScaleY(listBoxTagsBounds.Height);
        }

        public void Initialize(EpisodeDatabase episodes, Action PlayEpisode)
        {
            this.episodes = episodes;
            this.PlayEpisode = PlayEpisode;
            try
            {
                List<string> tags = new List<string>();
                foreach (EpisodeInfo episode in episodes.Info)
                {
                    string[] episodeTags = episode.Tags.Split(' ');
                    foreach (string tag in episodeTags)
                        if (tag != "")
                            tags.Add(tag);
                }
                var result = tags.GroupBy(n => n).OrderBy(g => g.Count()).ThenBy(g => g.Key).SelectMany(g => g).Distinct().Reverse();
                foreach (string tag in result)
                    listBoxTags.Items.Add(tag);
            }
            catch { }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxSearch.Items.Clear();
            try
            {
                if (textBoxSearch.Text.Trim() != "")
                    for (int i = 0; i < episodes.Info.Count; i++)
                    {
                        if (radioButtonTags.Checked)
                        {
                            string[] searchTags = textBoxSearch.Text.ToLower().Replace(',', ' ').Split(' ');
                            string[] episodeTags = episodes.Info[i].Tags.Split(' ');
                            bool found1 = true;
                            foreach (string searchTag in searchTags)
                            {
                                if (searchTag != "")
                                {
                                    bool found2 = false;
                                    foreach (string episodeTag in episodeTags)
                                        if (episodeTag == searchTag)
                                        {
                                            found2 = true;
                                            break;
                                        }
                                    if (!found2)
                                        found1 = false;
                                }
                            }
                            if (found1)
                                listBoxSearch.Items.Add(episodes.Info[i].Title);
                        }
                        else if (radioButtonTitles.Checked && episodes.Info[i].Title.ToLower().Contains(textBoxSearch.Text.ToLower()))
                            listBoxSearch.Items.Add(episodes.Info[i].Title);
                        else if (radioButtonSubtitles.Checked)
                        {
                            episodes.SelectEpisode(i);
                            if (File.Exists(episodes.Selected.FileSUB) && File.ReadAllText(episodes.Selected.FileSUB).ToLower().Contains(textBoxSearch.Text))
                            {
                                string title1 = "", title2 = "";
                                if (i == episodes.Info.Count - 1)
                                {
                                    title1 = episodes.Info[i - 1].Title;
                                    title2 = episodes.Info[i].Title;
                                }
                                else
                                {
                                    if (episodes.Info[i].Season == episodes.Info[i + 1].Season && episodes.Info[i].Episode == episodes.Info[i + 1].Episode)
                                    {
                                        title1 = episodes.Info[i].Title;
                                        title2 = episodes.Info[i + 1].Title;
                                    }
                                    else
                                    {
                                        title1 = episodes.Info[i - 1].Title;
                                        title2 = episodes.Info[i].Title;
                                    }
                                }
                                if (title1 != "" && title2 != "")
                                {
                                    if (title1 == episodes.GetTitleEpisode1(2, 13) || title2 == episodes.GetTitleEpisode2(2, 13))
                                        listBoxSearch.Items.Add(episodes.GetTitleEpisode1(2, 13));
                                    else if (title1 == episodes.GetTitleEpisode1(4, 7) || title2 == episodes.GetTitleEpisode2(4, 7))
                                        listBoxSearch.Items.Add(episodes.GetTitleEpisode1(4, 7));
                                    else
                                        listBoxSearch.Items.Add(title1 + " / " + title2);
                                }
                            }
                        }
                    }
                string[] distinct = listBoxSearch.Items.Cast<string>().Distinct().ToArray();
                listBoxSearch.Items.Clear();
                foreach (string item in distinct)
                    listBoxSearch.Items.Add(item);
            }
            catch { }
        }

        public void search_Click(object sender, EventArgs e)
        {
            listBoxTags.Visible = false;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            buttonTags.Visible = radioButtonTags.Checked;
            textBoxSearch.Clear();
        }

        private void listBoxSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Play();
        }

        private void listBoxSearch_MouseDown(object sender, MouseEventArgs e)
        {
            listBoxTags.Visible = false;
            if (e.Button == MouseButtons.Right && listBoxSearch.SelectedItem != null)
            {
                string title = listBoxSearch.SelectedItem.ToString();
                if (title.Contains(" / "))
                    title = title.Split('/')[0].Trim();
                for (int i = 0; i < episodes.Info.Count; i++)
                    if (episodes.Info[i].Title == title)
                    {
                        if (i == episodes.Info.Count - 1)
                            i--;
                        else if (episodes.Info[i + 1].Episode != episodes.Info[i].Episode)
                            i--;
                        using (FormInfo info = new FormInfo(episodes.Info[i], episodes.Info[i + 1], radioButtonTags.Checked ? textBoxSearch.Text.ToLower() : "", radioButtonSubtitles.Checked ? textBoxSearch.Text.ToLower() : ""))
                            info.ShowDialog();
                        break;
                    }
            }
        }

        private void buttonTags_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                listBoxTags.Visible = !listBoxTags.Visible;
                listBoxTags.BringToFront();
            }
        }

        private void SearchPanel_MouseClick(object sender, MouseEventArgs e)
        {
            listBoxTags.Visible = false;
        }

        private void listBoxTags_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBoxTags.SelectedItem != null)
            {
                if (textBoxSearch.Text != "")
                    textBoxSearch.Text += " ";
                textBoxSearch.Text += listBoxTags.SelectedItem.ToString();
                listBoxTags.ClearSelected();
                listBoxTags.Visible = false;
            }
        }

        public void Play()
        {
            listBoxTags.Visible = false;
            if (listBoxSearch.SelectedItem != null)
            {
                string title = listBoxSearch.SelectedItem.ToString();
                if (title.Contains(" / "))
                    title = title.Split('/')[0].Trim();
                episodes.SelectEpisode(title, radioButtonSubtitles.Checked ? textBoxSearch.Text : null);
                PlayEpisode();
            }
        }
    }
}
