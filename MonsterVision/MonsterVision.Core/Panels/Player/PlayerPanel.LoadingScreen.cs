using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    class LoadingScreen { } //Added dummy class so Visual Studio won't open this file in designer

    public partial class PlayerPanel : UserControl
    {
        bool criticalStop;

        private void panelLoading_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && converter != null)
            {
                criticalStop = true;
                foreach (Process process in Process.GetProcessesByName(Converter.EXE.Replace(".exe", "")))
                    process.Kill();
                Thread.Sleep(200);
                if (File.Exists(episodes.Selected.FileMP4))
                    File.Delete(episodes.Selected.FileMP4);
                Application.Exit();
            }
        }

        void DrawPanel(Graphics graphics, Panel panel, Point shift)
        {
            graphics.DrawImage(panel.BackgroundImage, new Rectangle(shift.X + panel.Left, shift.Y + panel.Top, panel.Width, panel.Height));
        }

        void DrawPanelTile(Graphics graphics, Panel panel, Point shift)
        {
            for (int i = 0; i < barProgress.Width / barProgress.BackgroundImage.Width + 1; i++)
                graphics.DrawImage(panel.BackgroundImage, new Rectangle(shift.X + panel.Left + i * panel.BackgroundImage.Width, shift.Y + panel.Top, panel.BackgroundImage.Width, panel.BackgroundImage.Height));
        }

        bool loadingNoise;

        private void panelLoading_Paint(object sender, PaintEventArgs e)
        {
            if (loadingNoise)
            {
                int pixelSize = Height / 90;
                for (int y = panelTop.Height; y < Height - panelBottom.Height; y += pixelSize)
                    for (int x = panelLeft.Width; x < Width - panelRight.Width; x += pixelSize)
                        if (RNG.Next(3) == 0)
                            e.Graphics.FillRectangle(RNG.Next(2) == 0 ? Brushes.DimGray : (RNG.Next(2) == 0 ? Brushes.Gray : Brushes.DarkGray), x, y, pixelSize * 2, pixelSize);
            }
            DrawPanel(e.Graphics, panelTop, Point.Empty);
            DrawPanel(e.Graphics, panelLeft, Point.Empty);
            DrawPanel(e.Graphics, panelRight, Point.Empty);
            DrawPanel(e.Graphics, panelBottom, Point.Empty);
            DrawPanel(e.Graphics, buttonClose, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, buttonPlay, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, buttonChapter, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, buttonReset, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, buttonAudio, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, buttonSubtitle, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, speaker, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, barVolumeLeft, new Point(panelRight.Left, panelRight.Top));
            e.Graphics.DrawImage(barVolume.BackgroundImage, new Rectangle(panelRight.Left + barVolume.Left, panelRight.Top + barVolume.Top, barVolume.Width / 2, barVolume.Height));
            e.Graphics.DrawImage(barVolume.BackgroundImage, new Rectangle(panelRight.Left + barVolume.Left + barVolume.Width / 2, panelRight.Top + barVolume.Top, barVolume.Width / 2, barVolume.Height));
            DrawPanel(e.Graphics, barVolumeMark, new Point(panelRight.Left + barVolume.Left, panelRight.Top + barVolume.Top));
            DrawPanel(e.Graphics, barVolumeRight, new Point(panelRight.Left, panelRight.Top));
            DrawPanel(e.Graphics, barProgressLeft, new Point(panelBottom.Left, panelBottom.Top));
            DrawPanelTile(e.Graphics, barProgress, new Point(panelBottom.Left, panelBottom.Top));
            DrawPanel(e.Graphics, barProgressMark, new Point(panelBottom.Left + barProgress.Left, panelBottom.Top + barProgress.Top));
            DrawPanel(e.Graphics, barProgressRight, new Point(panelBottom.Left, panelBottom.Top));
            Thread.Sleep(70);
            panelLoading.Invalidate();
        }
    }
}
