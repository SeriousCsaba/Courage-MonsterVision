using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class SpecialPanel : UserControl
    {
        enum SelectedTab { Episodes, Commercials, Pilots, Movies }

        Rectangle listBoxSpecialBounds;
        int originalHeight;

        public event EventHandler<bool> TabChanged;
        EpisodeDatabase episodes;

        Action PlayEpisode;
        Action<string, string> PlayVideo;

        List<Image> sourceImages;

        public SpecialPanel()
        {
            InitializeComponent();
            this.EnableDoubleBuffering();
            originalHeight = Height;
            listBoxSpecialBounds = listBoxSpecial.Bounds;
            LoadImages();
        }

        async void LoadImages()
        {
            await Task.Run(() =>
            {
                if (Directory.Exists(Folder.TitleCards))
                {
                    string[] files = Directory.GetFiles(Folder.TitleCards, "*.png");
                    sourceImages = new List<Image>();
                    foreach (string file in files)
                        sourceImages.Add(Image.FromFile(file));
                }
            });
        }

        private void SpecialPanel_Load(object sender, EventArgs e)
        {
            SetImageList();
        }

        public void Initialize(EpisodeDatabase episodes, Action PlayEpisode, Action<string, string> PlayVideo)
        {
            this.episodes = episodes;
            this.PlayEpisode = PlayEpisode;
            this.PlayVideo = PlayVideo;
        }

        public void Reset()
        {
            tabControlSpecial.SelectedIndex = 0;
            tabControlSpecial_SelectedIndexChanged(null, null);
        }

        public void AreaChanged()
        {
            Location = new Point(WindowScreen.Area.X, WindowScreen.Area.Y);
            Width = WindowScreen.Area.Width;
            Height = WindowScreen.ScaleY(originalHeight);
            listBoxSpecial.Location = new Point(WindowScreen.ScaleX(listBoxSpecialBounds.X), WindowScreen.ScaleY(listBoxSpecialBounds.Y));
            listBoxSpecial.Width = WindowScreen.ScaleX(listBoxSpecialBounds.Width);
            listBoxSpecial.Height = WindowScreen.ScaleY(listBoxSpecialBounds.Height);
            listViewSpecial.Location = new Point(WindowScreen.ScaleX(listBoxSpecialBounds.X), WindowScreen.ScaleY(listBoxSpecialBounds.Y));
            listViewSpecial.Width = WindowScreen.ScaleX(listBoxSpecialBounds.Width);
            listViewSpecial.Height = WindowScreen.ScaleY(listBoxSpecialBounds.Height);
            tabControlSpecial.Location = new Point(listBoxSpecial.Location.X, listBoxSpecial.Location.Y - tabControlSpecial.Height);
            if (listViewSpecial.Visible)
                SetImageList();
        }

        private void listBoxSpecial_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Play();
        }

        private void listBoxSpecial_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listBoxSpecial.SelectedItem != null)
            {
                string item = listBoxSpecial.SelectedItem.ToString();
                switch ((SelectedTab)tabControlSpecial.SelectedIndex)
                {
                    case SelectedTab.Episodes:
                        for (int i = 0; i < episodes.Info.Count; i++)
                            if (episodes.Info[i].Title == item)
                            {
                                if (i == episodes.Info.Count - 1)
                                    i--;
                                else if (episodes.Info[i + 1].Episode != episodes.Info[i].Episode)
                                    i--;
                                using (FormInfo info = new FormInfo(episodes.Info[i], episodes.Info[i + 1]))
                                    info.ShowDialog();
                                break;
                            }
                        break;
                    case SelectedTab.Pilots:
                        string descriptionFile = Folder.Pilots + item + ".txt";
                        if (File.Exists(descriptionFile))
                            using (FormInfoPilot info = new FormInfoPilot(item, File.ReadAllText(descriptionFile)))
                                info.ShowDialog();
                        break;
                }
            }
        }

        bool IsVideoFile(string file)
        {
            string extension = Path.GetExtension(file).ToLower().Replace(".", "");
            string[] notVideo = { "txt", "srt", "bat", "exe", "dll", "jpg", "jpeg", "png", "gif", "swf", "ods", "mp3", "wav", "ogg" };
            return !notVideo.Contains(extension);
        }

        private void tabControlSpecial_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewSpecial.Visible = false;
            listBoxSpecial.Items.Clear();
            switch ((SelectedTab)tabControlSpecial.SelectedIndex)
            {
                case SelectedTab.Episodes:
                    if (sourceImages == null)
                    {
                        for (int i = 0; i < episodes.Info.Count; i++)
                            if (!listBoxSpecial.Items.Contains(episodes.Info[i].Title))
                                listBoxSpecial.Items.Add(episodes.Info[i].Title);
                    }
                    else
                    {
                        listViewSpecial.Visible = true;
                        SetImageList();
                    }
                    break;
                case SelectedTab.Commercials:
                    if (Directory.Exists(Folder.Commercials))
                    {
                        string[] ads = Directory.GetFiles(Folder.Commercials, "*.mp4", SearchOption.AllDirectories);
                        foreach (string file in ads)
                            if (!Path.GetFileNameWithoutExtension(file).EndsWith("_"))
                                listBoxSpecial.Items.Add(Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file)).Replace(Folder.Commercials, ""));
                    }
                    break;
                case SelectedTab.Pilots:
                    if (Directory.Exists(Folder.Pilots))
                    {
                        string[] pilots = Directory.GetFiles(Folder.Pilots);
                        foreach (string file in pilots)
                            if (IsVideoFile(file) && !Path.GetFileNameWithoutExtension(file).EndsWith("_"))
                                listBoxSpecial.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
                    break;
                case SelectedTab.Movies:
                    if (Directory.Exists(Folder.Movies))
                    {
                        string[] movies = Directory.GetFiles(Folder.Movies);
                        foreach (string file in movies)
                            if (IsVideoFile(file))
                                listBoxSpecial.Items.Add(Path.GetFileNameWithoutExtension(file));
                    }
                    break;
            }
            TabChanged?.Invoke(this, tabControlSpecial.SelectedIndex < 2);
        }

        int GetEpisodeImageIndex()
        {
            int index = listViewSpecial.SelectedItems[0].ImageIndex;
            if (index > 50)
                index++;
            if (index > 90)
                index++;
            return index;
        }

        private void listViewSpecial_ItemActivate(object sender, EventArgs e)
        {
            if (listViewSpecial.SelectedItems.Count != 0)
            {
                episodes.SelectEpisode(GetEpisodeImageIndex());
                PlayEpisode.Invoke();
            }
        }

        private void listViewSpecial_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && listViewSpecial.SelectedItems.Count != 0)
            {
                int index = GetEpisodeImageIndex();
                for (int i = 0; i < episodes.Info.Count; i++)
                    if (i == index)
                    {
                        if (i == episodes.Info.Count - 1)
                            i--;
                        else if (episodes.Info[i + 1].Episode != episodes.Info[i].Episode)
                            i--;
                        using (FormInfo info = new FormInfo(episodes.Info[i], episodes.Info[i + 1]))
                            info.ShowDialog();
                        break;
                    }
            }
        }

        const int scroll = 20;
        const int gap = 5;
        void SetImageList()
        {
            if (sourceImages != null)
            {
                if (listViewSpecial.Items.Count == 0)
                    for (int i = 0; i < sourceImages.Count; i++)
                        listViewSpecial.Items.Add(new ListViewItem() { ImageIndex = i });
                ImageList imageList = new ImageList();
                int size = Math.Min((listViewSpecial.Width - scroll - 4 * gap) / 3, 256);
                imageList.ImageSize = new Size(size, (int)(size / 4f * 3));
                imageList.ColorDepth = ColorDepth.Depth32Bit;
                foreach (Image img in sourceImages)
                    imageList.Images.Add(img);
                listViewSpecial.LargeImageList = imageList;
                listViewSpecial.SetSpacing(gap);
            }
        }

        public void SelectRandom()
        {
            if (sourceImages != null && (SelectedTab)tabControlSpecial.SelectedIndex == SelectedTab.Episodes)
            {
                int index = RNG.Next(listViewSpecial.Items.Count);
                listViewSpecial.SelectedItems.Clear();
                listViewSpecial.Items[index].Selected = true;
                listViewSpecial.Items[index].Focused = true;
                listViewSpecial.EnsureVisible(index);
            }
            else if (listBoxSpecial.Items.Count > 0)
                listBoxSpecial.SelectedIndex = RNG.Next(listBoxSpecial.Items.Count);
        }

        public void Play()
        {
            if (sourceImages != null && (SelectedTab)tabControlSpecial.SelectedIndex == SelectedTab.Episodes)
                listViewSpecial_ItemActivate(null, null);
            else if (listBoxSpecial.SelectedItem != null)
            {
                string title = listBoxSpecial.SelectedItem.ToString();
                switch ((SelectedTab)tabControlSpecial.SelectedIndex)
                {
                    case SelectedTab.Episodes:
                        episodes.SelectEpisode(title);
                        PlayEpisode.Invoke();
                        break;
                    case SelectedTab.Commercials:
                        string ad = Folder.Commercials + title + ".mp4";
                        if (!File.Exists(ad))
                            FormMain.ShowErrorMessage("Can't find commercial");
                        else
                            PlayVideo.Invoke(ad, title);
                        break;
                    case SelectedTab.Pilots:
                        string pilot = Folder.Pilots + title;
                        if (File.Exists(pilot + ".mp4"))
                            pilot += ".mp4";
                        else if (File.Exists(pilot + ".mkv"))
                            pilot += ".mkv";
                        else if (File.Exists(pilot + ".webm"))
                            pilot += ".webm";
                        if (!File.Exists(pilot))
                            FormMain.ShowErrorMessage("Can't find pilot episode");
                        else
                            PlayVideo.Invoke(pilot, title);
                        break;
                    case SelectedTab.Movies:
                        string movie = Folder.Movies + title;
                        if (File.Exists(movie + ".mkv"))
                            movie += ".mkv";
                        else if (File.Exists(movie + ".mp4"))
                            movie += ".mp4";
                        if (!File.Exists(movie))
                            FormMain.ShowErrorMessage("Can't find movie");
                        else
                            PlayVideo.Invoke(movie, title);
                        break;
                }
            }
        }
    }

    static class ListViewExtensions
    {
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        public static void SetSpacing(this ListView listView, int gap)
        {
            SendMessage(listView.Handle, 0x1035, IntPtr.Zero, (IntPtr)(((listView.LargeImageList.ImageSize.Height + gap) << 16) | ((listView.LargeImageList.ImageSize.Width + gap) & 0xFFFF)));
        }
    }
}
