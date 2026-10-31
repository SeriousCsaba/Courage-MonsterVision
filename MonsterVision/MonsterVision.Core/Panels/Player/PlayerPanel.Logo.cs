using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class PlayerPanelLogo { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class PlayerPanel : UserControl
    {
        int logoFrame, logoTotalFrame, logoPause;
        bool logoPingpong = false;
        string animatedLogoPath = "";

        public string LookForLogo()
        {
            Cursor.Show();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Logo";
                string folderLogo = Directory.GetCurrentDirectory();
                openFileDialog.InitialDirectory = folderLogo;
                try
                {
                    if (Directory.Exists(Path.Combine(folderLogo, "Logo")))
                        openFileDialog.InitialDirectory = Path.Combine(folderLogo, "Logo");
                    else
                    {
                        folderLogo = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Logo");
                        if (Directory.Exists(folderLogo))
                            openFileDialog.InitialDirectory = folderLogo;
                    }
                }
                catch { }
                openFileDialog.Filter = "PNG (*.png)|*.png|All files (*.*)|*.*";
                bool resultOK = openFileDialog.ShowDialog() == DialogResult.OK;
                Cursor.Hide();
                if (resultOK)
                    return openFileDialog.FileName;
            }
            return "";
        }

        void ExtractLogoFrames(string logoFile, int amount)
        {
            animatedLogoPath = Path.Combine(Path.GetDirectoryName(logoFile), "Animation");
            if (Directory.Exists(animatedLogoPath))
                Directory.Delete(animatedLogoPath, true);
            Directory.CreateDirectory(animatedLogoPath);

            using (Image logoImage = Image.FromFile(logoFile))
            using (Image outImage = new Bitmap(logoImage.Width / amount, logoImage.Height))
            using (Graphics gfx = Graphics.FromImage(outImage))
                for (int i = 0; i < amount; i++)
                {
                    gfx.Clear(Color.Transparent);
                    gfx.DrawImage(logoImage, new Rectangle(0, 0, outImage.Width, outImage.Height), new Rectangle(i * outImage.Width, 0, outImage.Width, outImage.Height), GraphicsUnit.Pixel);
                    outImage.Save(Path.Combine(animatedLogoPath, i + ".png"), ImageFormat.Png);
                }
        }

        void SetLogo(string logoFile)
        {
            try
            {
                ResetLogoAnimation();
                if (logoFile == "")
                    VLCview.MediaPlayer.SetLogoString(VideoLogoOption.File, "");
                else
                {
                    VLCview.MediaPlayer.SetLogoString(VideoLogoOption.File, logoFile.Contains("-animate") ? "" : logoFile);
                    VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.X, 0);
                    VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.Y, 0);
                    VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.Opacity, 255);

                    string[] logoParams = Path.GetFileNameWithoutExtension(logoFile).Split('-');
                    Dictionary<string, Action<int>> SetVLCLogoValue = new Dictionary<string, Action<int>>()
                                    {
                                        { "x", val => VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.X, val)},
                                        { "y", val => VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.Y, val) },
                                        { "opacity", val => VLCview.MediaPlayer.SetLogoInt(VideoLogoOption.Opacity, val) },
                                        { "animate", val => logoTotalFrame = val },
                                        { "pause", val => logoPause = val },
                                    };
                    Dictionary<string, Action> SetVLCLogoSwitch = new Dictionary<string, Action>()
                                    {
                                        { "pingpong", () => logoPingpong = true },
                                    };
                    for (int i = 1; i < logoParams.Length; i++)
                    {
                        if (logoParams[i].Any(char.IsDigit))
                        {
                            foreach (string option in SetVLCLogoValue.Keys)
                            {
                                if (logoParams[i].ToLower().StartsWith(option))
                                {
                                    if (int.TryParse(logoParams[i].Substring(option.Length), out int value))
                                        SetVLCLogoValue[option](value);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            foreach (string option in SetVLCLogoSwitch.Keys)
                            {
                                if (logoParams[i].ToLower().StartsWith(option))
                                {
                                    SetVLCLogoSwitch[option]();
                                    break;
                                }
                            }
                        }
                    }
                    if (logoTotalFrame > 0)
                    {
                        ExtractLogoFrames(logoFile, logoTotalFrame);
                        timerLogo.Start();
                        if (!VLCview.MediaPlayer.IsPlaying)
                        {
                            VLCview.MediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, "");
                            VLCview.MediaPlayer.SetLogoString(VideoLogoOption.File, Path.Combine(animatedLogoPath, "0.png"));
                        }
                    }
                }
            }
            catch { }
        }

        private void timerLogo_Tick(object sender, EventArgs e)
        {
            const int FPS = 25;
            try
            {
                if (VLCview.MediaPlayer.IsPlaying)
                {
                    int frame = logoFrame;
                    if (frame >= logoTotalFrame)
                        frame = Math.Abs(frame - logoTotalFrame * 2) - 1;
                    VLCview.MediaPlayer.SetMarqueeString(VideoMarqueeOption.Text, "");
                    VLCview.MediaPlayer.SetLogoString(VideoLogoOption.File, Path.Combine(animatedLogoPath, frame + ".png"));
                    if (logoFrame == 0 && logoPause > 0)
                        timerLogo.Interval = logoPause;
                    else
                        timerLogo.Interval = 1000 / FPS;
                    logoFrame++;
                    int total = logoTotalFrame;
                    if (logoPingpong)
                        total = logoTotalFrame * 2 - 1;
                    if (logoFrame >= total)
                        logoFrame = 0;
                }
                else
                    timerLogo.Interval = 1000 / FPS;
            }
            catch { }
        }

        void ResetLogoAnimation()
        {
            timerLogo.Stop();
            timerLogo.Interval = 40;
            logoTotalFrame = 0;
            logoPause = 0;
            logoPingpong = false;
            if (animatedLogoPath.EndsWith("Animation"))
            {
                if (Directory.Exists(animatedLogoPath))
                    Directory.Delete(animatedLogoPath, true);
                animatedLogoPath = "";
            }
        }
    }
}
