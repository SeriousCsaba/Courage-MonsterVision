using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class FormMain : Form
    {
        bool ignoreDoubleClick;

        public FormMain(bool oldTVMode)
        {
            PlayerPanel.OldTVMode = oldTVMode;
            InitializeComponent();
            this.EnableDoubleBuffering();
            WindowScreen.SetupArea(ClientSize);
            Settings.Load();
            InitializeMenu();
            InitializeEpisodes();
        }

        public static void ShowErrorMessage(string message, bool critical = false)
        {
            MessageBox.Show("Error: " + message + "!", "MonsterVision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (critical)
                Application.Exit();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            playerPanel.InitializeVLC(episodes, SwitchFullscreen);
            timerUpdate.Enabled = true;
        }

        Rectangle defaultBounds;
        void SwitchFullscreen()
        {
            WindowScreen.Fullscreen = !WindowScreen.Fullscreen;
            if (WindowScreen.Fullscreen)
            {
                defaultBounds = Bounds;
                FormBorderStyle = FormBorderStyle.None;
                Bounds = Screen.FromControl(this).Bounds;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
                Bounds = defaultBounds;
            }

            WindowScreen.SetupArea(ClientSize);
            //Panel size update for the ones that need a single update after resize by fullscreen switch
            searchPanel.AreaChanged();
            specialPanel.AreaChanged();
            Invalidate();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            //Panel size update for the ones that need constant update during any resize event
            playerPanel.AreaChanged();
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (!playerPanel.Visible)
                MenuMouseMove(e.Location);
            else
                Cursor = Cursors.Default;
        }

        private void FormMain_MouseClick(object sender, MouseEventArgs e)
        {
            searchPanel.search_Click(sender, e);
            ignoreDoubleClick = false;
            if (e.Button == MouseButtons.Left && !playerPanel.Visible)
                ignoreDoubleClick = MenuMouseLeftClick();
        }

        private void FormMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!ignoreDoubleClick && e.Button == MouseButtons.Left)
                SwitchFullscreen();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (playerPanel.Visible)
                playerPanel.Shortcuts(e.KeyCode);
            else
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        currentMenu.Back?.PerformClick();
                        Invalidate();
                        break;
                    case Keys.F1:
                        MessageBox.Show("Made by SeriousCsaba 2020-2026", "MonsterVision", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
        }

        private void FormMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Escape)
                e.IsInputKey = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            playerPanel.Stop();
        }

        void PanelUpdate(UserControl panel)
        {
            if (playerPanel.Visible)
            {
                if (panel.Enabled)
                {
                    panel.Enabled = false;
                    panel.SendToBack();
                    Focus();
                }
            }
            else if (!panel.Enabled)
                panel.Enabled = true;
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            PanelUpdate(searchPanel);
            PanelUpdate(specialPanel);
            if (!playerPanel.Visible)
                MenuUpdate();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            if (!playerPanel.Visible)
                MenuDraw(e.Graphics);
        }
    }
}
