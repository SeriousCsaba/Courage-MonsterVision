using LibVLCSharp.Shared;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class PlayerPanel : UserControl
    {
        public static bool OldTVMode;

        EpisodeDatabase episodes;
        Action SwitchFullscreen;

        LibVLC VLCPlayer;
        Media currentMedia;
        ToolTip toolTip;
        bool ended, cursorHidden;
        string fileTitle;

        Process converter;
        bool converted;

        bool englishAudio, subtitles;

        public PlayerPanel()
        {
            InitializeComponent();
            this.EnableDoubleBuffering();
        }

        public void InitializeVLC(EpisodeDatabase episodes, Action SwitchFullscreen)
        {
            this.episodes = episodes;
            this.SwitchFullscreen = SwitchFullscreen;

            LibVLCSharp.Shared.Core.Initialize();
            if (OldTVMode)
                VLCPlayer = new LibVLC(new string[] { "--video-filter=colorthres", "--colorthres-color=0", "--sub-source=logo" });
            else
                VLCPlayer = new LibVLC("--sub-source=logo");

            VLCview.MediaPlayer = new MediaPlayer(VLCPlayer);
            VLCview.MediaPlayer.EnableKeyInput = false;
            VLCview.MediaPlayer.EnableMouseInput = false;
            VLCview.MouseWheel += VLCview_MouseWheel;
            VLCview.MediaPlayer.EndReached += VLCview_EndReached;
            timerPlayer.Enabled = true;

            barProgress.MouseWheel += BarProgress_MouseWheel;
            barVolume.MouseWheel += VLCview_MouseWheel;

            toolTip = new ToolTip();
            toolTip.SetToolTip(buttonPlay, "Play/Pause");
            toolTip.SetToolTip(buttonAudio, "Audio language");
            toolTip.SetToolTip(buttonSubtitle, "Subtitles");
            toolTip.SetToolTip(speaker, "Mute");
            toolTip.SetToolTip(buttonChapter, "Select chapter");
            toolTip.SetToolTip(buttonClose, "Back to menu");
            toolTip.SetToolTip(buttonReset, "Reset player");
            fileTitle = "";
        }

        void InitVLCSettings(bool changeAspectRatio = true)
        {
            while (currentMedia == null || currentMedia.Tracks.Count() == 0)
                Thread.Sleep(100);

            if (changeAspectRatio)
            {
                uint width = 0, height = 0;
                VLCview.MediaPlayer.Size(0, ref width, ref height);
                if (width / (float)height > 1.6f)
                    VLCview.MediaPlayer.AspectRatio = "16:9";
                else
                    VLCview.MediaPlayer.AspectRatio = "4:3";
                if (episodes.Selected == null || englishAudio) //BUG: Won't apply for HUN audio
                {
                    VLCview.MediaPlayer.Stop();
                    VLCview.MediaPlayer.Play(); //Apply aspect ratio
                }
                AreaChanged();
            }
            buttonChapter.Enabled = episodes.Selected != null;
            buttonAudio.Enabled = episodes.Selected != null;

            if (episodes.Selected != null && !englishAudio)
            {
                ApplyAudioChange();
                VLCview.MediaPlayer.Play();
                Thread.Sleep(600);
                VLCview.MediaPlayer.Mute = false;
            }
            ApplySubtitleChange();
        }



        void PrepareToPlayMedia()
        {
            Cursor = Cursors.Default;
            currentMedia = null;
            converted = false;
            ended = false;
            fileTitle = "";
            englishAudio = Settings.EnglishAudio;
            subtitles = Settings.Subtitles;
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 0);
        }

        void PlayMedia(string media, bool paused, string logo)
        {
            labelIntro.AutoSize = true;
            labelEpisode1.AutoSize = true;
            labelEpisode2.AutoSize = true;
            labelCredits.AutoSize = true;
            if (episodes.Selected != null)
            {
                labelEpisode1.Text = episodes.GetTitleEpisode1();
                labelEpisode2.Text = episodes.GetTitleEpisode2();
            }
            currentMedia = new Media(VLCPlayer, media);
            VLCview.MediaPlayer.Play(currentMedia);
            if (paused)
                VLCview.MediaPlayer.Pause();
            InitVLCSettings();
            if (episodes.PreferredStartingTime.TotalMilliseconds != 0)
                VLCview.MediaPlayer.Position = (float)(episodes.PreferredStartingTime.TotalMilliseconds / currentMedia.Duration);
            SetLogo(logo);
            timerPlayer.Enabled = true;
        }

        public async void PlayEpisode()
        {
            if (episodes.Selected == null)
                return;
            PrepareToPlayMedia();
            barVolumeMark.Left = barVolume.Width / 2 + barVolumeMark.Width / 2;
            barProgressMark.Left = 0;
            SetupLocalArea(4.0 / 3.0);
            if (!File.Exists(episodes.Selected.FileMP4) && !File.Exists(Path.Combine(Folder.Episodes, Converter.EXE)) && !File.Exists(Path.Combine(Folder.Episodes, Converter.BAT)))
            {
                FormMain.ShowErrorMessage("Unable to play episode");
                return;
            }
            if (!englishAudio)
                VLCview.MediaPlayer.Mute = true;
            Visible = true;
            loadingNoise = true;
            panelLoading.Visible = true;
            if (!File.Exists(episodes.Selected.FileMP4))
                if (File.Exists(Path.Combine(Folder.Episodes, Converter.BAT)))
                    await ConvertEpisodeBAT();
                else
                    await ConvertEpisodeEXE();
            if (criticalStop)
                return;
            PlayMedia(media: episodes.Selected.FileMP4, paused: !englishAudio, logo: Settings.Logo);
            panelLoading.Visible = false;
        }

        public void PlayVideo(string path, string title)
        {
            PrepareToPlayMedia();
            episodes.ClearSelection();
            fileTitle = title.Split('\\').Last();
            Visible = true;
            PlayMedia(media: path, paused: false, logo: "");
        }

        public void Stop()
        {
            try
            {
                ResetLogoAnimation();
                if (converted)
                {
                    VLCview.MediaPlayer.Stop();
                    File.Delete(episodes.Selected.FileMP4);
                }
            }
            catch { }
        }



        void ToggleFrame(bool visibility)
        {
            panelTop.Visible = visibility;
            panelBottom.Visible = visibility;
            panelLeft.Visible = visibility;
            panelRight.Visible = visibility;
            if (visibility && cursorHidden)
            {
                Cursor.Show();
                cursorHidden = false;
            }
            else if (!visibility && !cursorHidden)
            {
                Cursor.Hide();
                cursorHidden = true;
            }
            timerVisibility.Enabled = false;
            panelChapter.Visible = false;
            if (panelTop.Visible)
            {
                VLCview.Location = new Point(panelLeft.Width, panelTop.Height);
                VLCview.Size = new Size(Width - panelLeft.Width - panelRight.Width, Height - panelTop.Height - panelBottom.Height);
            }
            else
            {
                VLCview.Location = new Point(0, 0);
                VLCview.Size = new Size(Width, Height);
            }
        }

        void SetupLocalArea(double aspectRatio)
        {
            Bounds = WindowScreen.CalculateArea(Parent.ClientSize, aspectRatio);
        }

        public void AreaChanged()
        {
            SetupLocalArea((VLCview.MediaPlayer.AspectRatio == "16:9" && WindowScreen.Fullscreen) ? (16.0 / 9.0) : (4.0 / 3.0));
            timerPlayer_Tick(null, null);
        }



        void SetMessage(string message)
        {
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Enable, 1);
            VLCview.MediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, message.Replace("%", "%%").Replace(Environment.NewLine, "  " + Environment.NewLine) + "  ");
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Position, 6);
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Size, 28);
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Timeout, 1000);
            VLCview.MediaPlayer.SetMarqueeInt(VideoMarqueeOption.Y, 20);
        }

        void ToggleAudio(bool showMessage = true)
        {
            englishAudio = !englishAudio;
            ApplyAudioChange();
            if (showMessage)
                SetMessage("English audio: " + (englishAudio ? "YES" : "NO"));
        }

        void ApplyAudioChange()
        {
            try
            {
                if (episodes.Selected != null)
                    VLCview.MediaPlayer.SetAudioTrack(VLCview.MediaPlayer.AudioTrackDescription[englishAudio ? 1 : 2].Id);
            }
            catch { }
        }

        void ToggleSubtitle()
        {
            subtitles = !subtitles;
            ApplySubtitleChange();
            SetMessage("Subtitles: " + (subtitles ? "ON" : "OFF"));
        }

        void ApplySubtitleChange()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    if (VLCview.MediaPlayer.SpuCount > 0)
                    {
                        VLCview.MediaPlayer.SetSpu(subtitles ? VLCview.MediaPlayer.SpuDescription[1].Id : -1);
                        break;
                    }
                    Thread.Sleep(10);
                }
            }
            catch { }
        }

        float speed = 1;
        void ChangeSpeed(bool faster)
        {
            speed = Math.Min(Math.Max(speed - 0.5f + (faster ? 1 : 0), 0.5f), 2);
            VLCview.MediaPlayer.SetRate(speed);
            SetMessage("Speed: " + (int)speed + "." + ((int)((speed - (int)speed) * 100)).ToString("00") + "x");
        }

        async void ChangeVolume(int amount)
        {
            if (amount != 0)
            {
                int volume = Math.Max(0, Math.Min(100, VLCview.MediaPlayer.Volume + amount));
                VLCview.MediaPlayer.Volume = volume; //Doesn't update right away for some reason
                int waited = 0;
                while (VLCview.MediaPlayer.Volume != volume && waited < 500)
                {
                    await Task.Delay(3);
                    waited += 3;
                }
                SetMessage("Volume: " + VLCview.MediaPlayer.Volume + "%");
            }
        }

        int snapshot;
        string SnapshotName => "Snapshot-" + (episodes.Selected == null ? fileTitle : episodes.Selected.FileID) + "-" + snapshot.ToString("00000") + ".png";

        public void Shortcuts(Keys pressed)
        {
            if (panelLoading.Visible)
            {
                if (pressed == Keys.Escape)
                    panelLoading_MouseClick(null, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
            }
            else
            {
                float jumpAmount = OneSecond() * (ModifierKeys == Keys.Shift ? 5 : (ModifierKeys == Keys.Control ? 60 : 10));
                switch (pressed)
                {
                    case Keys.Tab:
                        SetLogo(LookForLogo());
                        break;
                    case Keys.Space:
                        SetMessage(VLCview.MediaPlayer.IsPlaying ? "|| " : "►");
                        VLCview.MediaPlayer.Pause();
                        break;
                    case Keys.Left:
                        if (VLCview.MediaPlayer.Position > jumpAmount)
                            VLCview.MediaPlayer.Position -= jumpAmount;
                        else
                            VLCview.MediaPlayer.Position = 0;
                        SetMessage(GetTime());
                        break;
                    case Keys.Right:
                        if (VLCview.MediaPlayer.Position < 1 - jumpAmount)
                            VLCview.MediaPlayer.Position += jumpAmount;
                        else
                            VLCview.MediaPlayer.Position = 1;
                        SetMessage(GetTime());
                        break;
                    case Keys.Up:
                        ChangeVolume(5);
                        break;
                    case Keys.Down:
                        ChangeVolume(-5);
                        break;
                    case Keys.F: VLCview_MouseDoubleClick(null, new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0)); break;
                    case Keys.M: speaker_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)); break;
                    case Keys.B: ToggleAudio(); break;
                    case Keys.V: ToggleSubtitle(); break;
                    case Keys.E: VLCview.MediaPlayer.NextFrame(); break;
                    case Keys.R: buttonReset_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)); break;
                    case Keys.Add: ChangeSpeed(faster: true); break;
                    case Keys.Subtract: ChangeSpeed(faster: false); break;
                    case Keys.S:
                        if (ModifierKeys == Keys.Shift)
                        {
                            while (File.Exists(SnapshotName))
                                snapshot++;
                            VLCview.MediaPlayer.TakeSnapshot(0, SnapshotName, 0, 0);
                        }
                        break;
                    case Keys.F1:
                        if (episodes.Selected != null)
                            for (int i = 0; i < episodes.Info.Count; i++)
                                if (episodes.Info[i].Season == episodes.Selected.Season && episodes.Info[i].Episode == episodes.Selected.Episode)
                                {
                                    if (i == episodes.Info.Count - 1)
                                        i--;
                                    else if (episodes.Info[i + 1].Episode != episodes.Info[i].Episode)
                                        i--;
                                    Cursor.Show();
                                    using (FormInfo info = new FormInfo(episodes.Info[i], episodes.Info[i + 1]))
                                        info.ShowDialog();
                                    Cursor.Hide();
                                    break;
                                }
                        break;
                    case Keys.Escape: buttonClose_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)); break;
                }
                timerPlayer_Tick(null, null);
            }
        }



        Point mousePreviousLocation;
        bool mouseCheck;

        private void VLCview_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseCheck)
            {
                if (MousePosition != mousePreviousLocation && Math.Sqrt(Math.Pow(mousePreviousLocation.X - MousePosition.X, 2) + Math.Pow(mousePreviousLocation.Y - MousePosition.Y, 2)) > 2)
                {
                    ToggleFrame(true);
                    timerVisibility.Enabled = true;
                }
                mousePreviousLocation = MousePosition;
            }
            mouseCheck = !mouseCheck;
        }

        private void VLCview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SwitchFullscreen.Invoke();
        }

        private void VLCview_MouseWheel(object sender, MouseEventArgs e)
        {
            ChangeVolume(Math.Sign(e.Delta) * 5);
        }

        private void VLCview_EndReached(object sender, EventArgs e)
        {
            ended = true;
        }



        TimeSpan GetChapterStartTime(int chapter)
        {
            if (chapter == 3)
                return new TimeSpan(0, 0, 0, 0, (int)currentMedia.Duration) - new TimeSpan(0, 0, ((episodes.Selected.Season == 2 && episodes.Selected.Episode == 13) || (episodes.Selected.Season == 4 && episodes.Selected.Episode == 7)) ? 43 : 41);

            foreach (EpisodeInfo ep in episodes.Info)
                if (ep.Season == episodes.Selected.Season && ep.Episode == episodes.Selected.Episode && ep.Chapter == chapter)
                    return ep.Timestamp;

            return new TimeSpan(0, 0, 0);
        }

        string GetTitle(TimeSpan passed, string episode1, string episode2)
        {
            if (passed > GetChapterStartTime(1) && passed < GetChapterStartTime(2))
                return episode1;
            if (passed > GetChapterStartTime(2) && passed < GetChapterStartTime(3))
                return episode2;
            return "";
        }

        string GetTitle(TimeSpan passed)
        {
            if (episodes.Selected == null)
                return fileTitle;
            return GetTitle(passed, episodes.GetTitleEpisode1(), episodes.GetTitleEpisode2());
        }

        string GetTime()
        {
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, (int)currentMedia.Duration);
            TimeSpan passed = new TimeSpan((long)(duration.Ticks * VLCview.MediaPlayer.Position));
            return GetTime(passed, duration);
        }

        string GetTime(TimeSpan passed, TimeSpan duration)
        {
            if (duration.Hours > 0)
                return passed.ToString(@"hh\:mm\:ss") + " / " + duration.ToString(@"hh\:mm\:ss");
            return passed.ToString(@"mm\:ss") + " / " + duration.ToString(@"mm\:ss");
        }

        float OneSecond()
        {
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, (int)currentMedia.Duration);
            return 1 - (float)(duration.TotalSeconds / (duration.TotalSeconds + 1));
        }



        private void panelBorder_MouseMove(object sender, MouseEventArgs e)
        {
            timerVisibility.Enabled = false;
        }

        private void panelBorder_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                panelChapter.Visible = false;
        }

        private void barProgress_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.X >= 0 && e.X <= barProgress.Width)
                {
                    TimeSpan time = new TimeSpan((long)(new TimeSpan(0, 0, 0, 0, (int)currentMedia.Duration).Ticks * (e.X / (float)barProgress.Width)));
                    toolTip.Show(time.ToString(time.Hours > 0 ? @"hh\:mm\:ss" : @"mm\:ss"), barProgress, e.X - 20, -20, 2000);
                    TimeSpan duration = new TimeSpan(0, 0, 0, 0, (int)currentMedia.Duration);
                    TimeSpan passed = new TimeSpan((long)(duration.Ticks * VLCview.MediaPlayer.Position));
                    string title = GetTitle(passed);
                    SetMessage((title != "" ? title + Environment.NewLine : "") + GetTime(passed, duration));
                }
                else
                    toolTip.Hide(barProgress);
            }
            catch { }
            barProgress_MouseDown(sender, e);
        }

        private void barProgress_MouseLeave(object sender, EventArgs e)
        {
            toolTip.Hide(barProgress);
        }

        private void barProgressLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VLCview.MediaPlayer.Position = 0;
                timerPlayer_Tick(null, null);
            }
        }

        private void barProgress_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int mark = barProgressMark.Width / 2;
                if (e.X < mark)
                {
                    VLCview.MediaPlayer.Position = 0;
                    timerPlayer_Tick(null, null);
                }
                else if (e.X < barProgress.Size.Width - mark)
                {
                    VLCview.MediaPlayer.Position = e.X / (float)barProgress.Width;
                    timerPlayer_Tick(null, null);
                }
            }
        }

        private void BarProgress_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 0)
                return;

            float tenSec = OneSecond() * 10;

            if (e.Delta > 0)
                if (VLCview.MediaPlayer.Position < 1 - tenSec)
                    VLCview.MediaPlayer.Position += tenSec;
                else
                    VLCview.MediaPlayer.Position = 0.99f;

            if (e.Delta < 0)
                if (VLCview.MediaPlayer.Position > tenSec)
                    VLCview.MediaPlayer.Position -= tenSec;
                else
                    VLCview.MediaPlayer.Position = 0;
            timerPlayer_Tick(null, null);
            ToggleFrame(true);
            timerVisibility.Enabled = true;
        }



        private void buttonClose_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                timerPlayer.Enabled = false;
                ended = true;
                VLCview.MediaPlayer.Stop();
                Cursor = Cursors.Default;
                if (cursorHidden)
                {
                    Cursor.Show();
                    cursorHidden = false;
                }
                panelChapter.Visible = false;
                Visible = false;
                if (episodes.Selected != null && converted)
                    File.Delete(episodes.Selected.FileMP4);
                converted = false;
            }
        }

        private void buttonPlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VLCview.MediaPlayer.Pause();
                timerPlayer_Tick(null, null);
            }
        }

        void ResizeLabelChapter(Label label, int width)
        {
            label.AutoSize = false;
            label.Width = width;
            label.Height = 28;
        }

        private void buttonChapter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (labelIntro.AutoSize)
                {
                    if (labelEpisode1.Text == labelEpisode2.Text)
                    {
                        labelEpisode1.Text += " (Part1)";
                        labelEpisode2.Text += " (Part2)";
                    }
                    int width = Math.Max(Math.Max(Math.Max(labelIntro.Width, labelCredits.Width), labelEpisode1.Width), labelEpisode2.Width);
                    ResizeLabelChapter(labelIntro, width);
                    ResizeLabelChapter(labelEpisode1, width);
                    ResizeLabelChapter(labelEpisode2, width);
                    ResizeLabelChapter(labelCredits, width);
                    labelCredits.Width = width;
                    panelChapter.Width = width;
                }
                panelChapter.Visible = !panelChapter.Visible;
                panelChapter.Location = new Point(panelRight.Location.X + 24 - panelChapter.Width, panelTop.Size.Height + buttonChapter.Location.Y + 16);
                panelChapter.BringToFront();
            }
        }

        private void buttonReset_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                float pos = VLCview.MediaPlayer.Position;
                VLCview.MediaPlayer.Stop();
                VLCview.MediaPlayer.Play();
                VLCview.MediaPlayer.Position = pos;
                for (int i = 0; i < 66; i++)
                    Thread.Sleep(5); //330
                InitVLCSettings(changeAspectRatio: false);
                timerPlayer_Tick(null, null);
            }
        }

        private void buttonAudio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ToggleAudio();
        }

        private void buttonSubtitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ToggleSubtitle();
        }

        private void speaker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VLCview.MediaPlayer.ToggleMute();
                Thread.Sleep(100);
                SetMessage(VLCview.MediaPlayer.Mute ? "🔇" : "Volume: " + VLCview.MediaPlayer.Volume + "%");
            }
        }

        private void barVolumeLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VLCview.MediaPlayer.Volume = 0;
                timerPlayer_Tick(null, null);
            }
        }

        private void barVolume_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X < 0)
                    VLCview.MediaPlayer.Volume = 0;
                else if (e.X > barVolume.Width)
                    VLCview.MediaPlayer.Volume = 100;
                else
                    VLCview.MediaPlayer.Volume = (int)Math.Round(e.X / (float)barVolume.Width * 100);
                timerPlayer_Tick(null, null);
            }
        }

        private void barVolume_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(barVolume.BackgroundImage, new Rectangle(0, 0, barVolume.Width / 2, barVolume.Height));
            e.Graphics.DrawImage(barVolume.BackgroundImage, new Rectangle(barVolume.Width / 2, 0, barVolume.Width / 2, barVolume.Height));
        }



        private void labelChapter_MouseEnter(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.Black;
            (sender as Label).ForeColor = Color.FromArgb(230, 219, 140);
        }

        private void labelChapter_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(230, 219, 140);
            (sender as Label).ForeColor = Color.Black;
        }

        void PlayChapter(MouseEventArgs e, int index)
        {
            if (e.Button == MouseButtons.Left)
            {
                panelChapter.Visible = false;
                VLCview.MediaPlayer.Position = OneSecond() * (float)GetChapterStartTime(index).TotalSeconds + OneSecond();
                timerPlayer_Tick(null, null);
            }
        }

        private void labelIntro_MouseDown(object sender, MouseEventArgs e)
        {
            PlayChapter(e, 0);
        }

        private void labelEpisode1_MouseDown(object sender, MouseEventArgs e)
        {
            PlayChapter(e, 1);
        }

        private void labelEpisode2_MouseDown(object sender, MouseEventArgs e)
        {
            PlayChapter(e, 2);
        }

        private void labelCredits_MouseDown(object sender, MouseEventArgs e)
        {
            PlayChapter(e, 3);
        }



        private void timerPlayer_Tick(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (ended)
                {
                    buttonClose_MouseDown(null, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    return;
                }
                barVolumeMark.Left = (int)(barVolume.Width * (VLCview.MediaPlayer.Volume / 100f)) - barProgressMark.Width / 2;
                if (barVolumeMark.Left < 0)
                    barVolumeMark.Left = 0;
                else if (barVolumeMark.Left > barVolume.Size.Width - barVolumeMark.Size.Width)
                    barVolumeMark.Left = barVolume.Size.Width - barVolumeMark.Size.Width;

                if (VLCview.MediaPlayer.Mute)
                {
                    if (speaker.BackgroundImage != Properties.Resources.player_speaker_mute)
                        speaker.BackgroundImage = Properties.Resources.player_speaker_mute;
                }
                else if (speaker.BackgroundImage != Properties.Resources.player_speaker)
                    speaker.BackgroundImage = Properties.Resources.player_speaker;

                barProgressMark.Left = (int)(barProgress.Width * VLCview.MediaPlayer.Position) - barProgressMark.Width / 2;
                if (barProgressMark.Left < 0)
                    barProgressMark.Left = 0;
                else if (barProgressMark.Left > barProgress.Size.Width - barProgressMark.Size.Width)
                    barProgressMark.Left = barProgress.Size.Width - barProgressMark.Size.Width;

                if (!VLCview.MediaPlayer.IsPlaying)
                {
                    if (buttonPlay.BackgroundImage != Properties.Resources.player_button_play)
                        buttonPlay.BackgroundImage = Properties.Resources.player_button_play;
                }
                else if (buttonPlay.BackgroundImage != Properties.Resources.player_button_pause)
                    buttonPlay.BackgroundImage = Properties.Resources.player_button_pause;

                Update();
            }
        }

        private void timerVisibility_Tick(object sender, EventArgs e)
        {
            if (Visible && VLCview.MediaPlayer.IsPlaying)
                ToggleFrame(false);
        }
    }
}
