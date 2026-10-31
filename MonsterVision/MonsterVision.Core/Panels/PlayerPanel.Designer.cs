
namespace MonsterVision.Core
{
    partial class PlayerPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VLCview = new LibVLCSharp.WinForms.VideoView();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.barProgressRight = new System.Windows.Forms.Panel();
            this.barProgressLeft = new System.Windows.Forms.Panel();
            this.barProgress = new System.Windows.Forms.Panel();
            this.barProgressMark = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.barVolumeRight = new System.Windows.Forms.Panel();
            this.barVolumeLeft = new System.Windows.Forms.Panel();
            this.barVolume = new System.Windows.Forms.Panel();
            this.barVolumeMark = new System.Windows.Forms.Panel();
            this.speaker = new System.Windows.Forms.Panel();
            this.buttonSubtitle = new System.Windows.Forms.Panel();
            this.buttonAudio = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Panel();
            this.buttonChapter = new System.Windows.Forms.Panel();
            this.buttonPlay = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelChapter = new System.Windows.Forms.Panel();
            this.labelIntro = new System.Windows.Forms.Label();
            this.labelEpisode1 = new System.Windows.Forms.Label();
            this.labelEpisode2 = new System.Windows.Forms.Label();
            this.labelCredits = new System.Windows.Forms.Label();
            this.timerPlayer = new System.Windows.Forms.Timer(this.components);
            this.timerVisibility = new System.Windows.Forms.Timer(this.components);
            this.panelLoading = new System.Windows.Forms.Label();
            this.timerLogo = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VLCview)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.barProgress.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.barVolume.SuspendLayout();
            this.panelChapter.SuspendLayout();
            this.SuspendLayout();
            // 
            // VLCview
            // 
            this.VLCview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VLCview.BackColor = System.Drawing.Color.Black;
            this.VLCview.Location = new System.Drawing.Point(0, 0);
            this.VLCview.MediaPlayer = null;
            this.VLCview.Name = "VLCview";
            this.VLCview.Size = new System.Drawing.Size(960, 720);
            this.VLCview.TabIndex = 0;
            this.VLCview.TabStop = false;
            this.VLCview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VLCview_MouseDoubleClick);
            this.VLCview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VLCview_MouseMove);
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bottom;
            this.panelBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelBottom.Controls.Add(this.barProgressRight);
            this.panelBottom.Controls.Add(this.barProgressLeft);
            this.panelBottom.Controls.Add(this.barProgress);
            this.panelBottom.Location = new System.Drawing.Point(92, 648);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(776, 72);
            this.panelBottom.TabIndex = 13;
            this.panelBottom.Visible = false;
            this.panelBottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelBottom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            // 
            // barProgressRight
            // 
            this.barProgressRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.barProgressRight.BackColor = System.Drawing.Color.Transparent;
            this.barProgressRight.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_right;
            this.barProgressRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barProgressRight.Location = new System.Drawing.Point(736, 16);
            this.barProgressRight.Name = "barProgressRight";
            this.barProgressRight.Size = new System.Drawing.Size(16, 41);
            this.barProgressRight.TabIndex = 2;
            // 
            // barProgressLeft
            // 
            this.barProgressLeft.BackColor = System.Drawing.Color.Transparent;
            this.barProgressLeft.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_left;
            this.barProgressLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barProgressLeft.Location = new System.Drawing.Point(24, 16);
            this.barProgressLeft.Name = "barProgressLeft";
            this.barProgressLeft.Size = new System.Drawing.Size(16, 41);
            this.barProgressLeft.TabIndex = 2;
            this.barProgressLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barProgressLeft_MouseDown);
            // 
            // barProgress
            // 
            this.barProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.barProgress.BackColor = System.Drawing.Color.Transparent;
            this.barProgress.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_center;
            this.barProgress.Controls.Add(this.barProgressMark);
            this.barProgress.Location = new System.Drawing.Point(40, 16);
            this.barProgress.Name = "barProgress";
            this.barProgress.Size = new System.Drawing.Size(696, 41);
            this.barProgress.TabIndex = 2;
            this.barProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barProgress_MouseDown);
            this.barProgress.MouseLeave += new System.EventHandler(this.barProgress_MouseLeave);
            this.barProgress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barProgress_MouseMove);
            // 
            // barProgressMark
            // 
            this.barProgressMark.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_mark;
            this.barProgressMark.Enabled = false;
            this.barProgressMark.Location = new System.Drawing.Point(0, 4);
            this.barProgressMark.Name = "barProgressMark";
            this.barProgressMark.Size = new System.Drawing.Size(9, 33);
            this.barProgressMark.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_right;
            this.panelRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelRight.Controls.Add(this.barVolumeRight);
            this.panelRight.Controls.Add(this.barVolumeLeft);
            this.panelRight.Controls.Add(this.barVolume);
            this.panelRight.Controls.Add(this.speaker);
            this.panelRight.Controls.Add(this.buttonSubtitle);
            this.panelRight.Controls.Add(this.buttonAudio);
            this.panelRight.Controls.Add(this.buttonReset);
            this.panelRight.Controls.Add(this.buttonChapter);
            this.panelRight.Controls.Add(this.buttonPlay);
            this.panelRight.Controls.Add(this.buttonClose);
            this.panelRight.Location = new System.Drawing.Point(868, 66);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(92, 654);
            this.panelRight.TabIndex = 14;
            this.panelRight.Visible = false;
            this.panelRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            // 
            // barVolumeRight
            // 
            this.barVolumeRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barVolumeRight.BackColor = System.Drawing.Color.Transparent;
            this.barVolumeRight.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_right;
            this.barVolumeRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barVolumeRight.Location = new System.Drawing.Point(66, 552);
            this.barVolumeRight.Name = "barVolumeRight";
            this.barVolumeRight.Size = new System.Drawing.Size(9, 23);
            this.barVolumeRight.TabIndex = 5;
            // 
            // barVolumeLeft
            // 
            this.barVolumeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barVolumeLeft.BackColor = System.Drawing.Color.Transparent;
            this.barVolumeLeft.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_left;
            this.barVolumeLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barVolumeLeft.Location = new System.Drawing.Point(15, 552);
            this.barVolumeLeft.Name = "barVolumeLeft";
            this.barVolumeLeft.Size = new System.Drawing.Size(9, 23);
            this.barVolumeLeft.TabIndex = 5;
            this.barVolumeLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barVolumeLeft_MouseDown);
            // 
            // barVolume
            // 
            this.barVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barVolume.BackColor = System.Drawing.Color.Transparent;
            this.barVolume.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_center;
            this.barVolume.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barVolume.Controls.Add(this.barVolumeMark);
            this.barVolume.Location = new System.Drawing.Point(24, 552);
            this.barVolume.Name = "barVolume";
            this.barVolume.Size = new System.Drawing.Size(42, 23);
            this.barVolume.TabIndex = 5;
            this.barVolume.Paint += new System.Windows.Forms.PaintEventHandler(this.barVolume_Paint);
            this.barVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barVolume_MouseDown);
            this.barVolume.MouseMove += new System.Windows.Forms.MouseEventHandler(this.barVolume_MouseDown);
            // 
            // barVolumeMark
            // 
            this.barVolumeMark.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_bar_mark;
            this.barVolumeMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barVolumeMark.Enabled = false;
            this.barVolumeMark.Location = new System.Drawing.Point(0, 3);
            this.barVolumeMark.Name = "barVolumeMark";
            this.barVolumeMark.Size = new System.Drawing.Size(4, 18);
            this.barVolumeMark.TabIndex = 4;
            // 
            // speaker
            // 
            this.speaker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.speaker.BackColor = System.Drawing.Color.Transparent;
            this.speaker.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_speaker;
            this.speaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.speaker.Location = new System.Drawing.Point(11, 450);
            this.speaker.Name = "speaker";
            this.speaker.Size = new System.Drawing.Size(70, 94);
            this.speaker.TabIndex = 0;
            this.speaker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.speaker_MouseDown);
            // 
            // buttonSubtitle
            // 
            this.buttonSubtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.buttonSubtitle.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_sub;
            this.buttonSubtitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSubtitle.Location = new System.Drawing.Point(54, 380);
            this.buttonSubtitle.Name = "buttonSubtitle";
            this.buttonSubtitle.Size = new System.Drawing.Size(46, 56);
            this.buttonSubtitle.TabIndex = 7;
            this.buttonSubtitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonSubtitle_MouseDown);
            // 
            // buttonAudio
            // 
            this.buttonAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAudio.BackColor = System.Drawing.Color.Transparent;
            this.buttonAudio.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_audio;
            this.buttonAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAudio.Location = new System.Drawing.Point(5, 380);
            this.buttonAudio.Name = "buttonAudio";
            this.buttonAudio.Size = new System.Drawing.Size(46, 56);
            this.buttonAudio.TabIndex = 8;
            this.buttonAudio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonAudio_MouseDown);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReset.BackColor = System.Drawing.Color.Transparent;
            this.buttonReset.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_reset;
            this.buttonReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReset.Location = new System.Drawing.Point(54, 310);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(46, 56);
            this.buttonReset.TabIndex = 14;
            this.buttonReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonReset_MouseDown);
            // 
            // buttonChapter
            // 
            this.buttonChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonChapter.BackColor = System.Drawing.Color.Transparent;
            this.buttonChapter.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_chapter;
            this.buttonChapter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChapter.Location = new System.Drawing.Point(5, 310);
            this.buttonChapter.Name = "buttonChapter";
            this.buttonChapter.Size = new System.Drawing.Size(46, 56);
            this.buttonChapter.TabIndex = 13;
            this.buttonChapter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonChapter_MouseDown);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Transparent;
            this.buttonPlay.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_pause;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlay.Location = new System.Drawing.Point(11, 155);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(74, 98);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonPlay_MouseDown);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_button_power;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.Location = new System.Drawing.Point(11, 45);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(74, 98);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonClose_MouseDown);
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_left;
            this.panelLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLeft.Location = new System.Drawing.Point(0, 66);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(92, 654);
            this.panelLeft.TabIndex = 14;
            this.panelLeft.Visible = false;
            this.panelLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            // 
            // panelTop
            // 
            this.panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTop.BackgroundImage = global::MonsterVision.Core.Properties.Resources.player_top;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(960, 66);
            this.panelTop.TabIndex = 14;
            this.panelTop.Visible = false;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            // 
            // panelChapter
            // 
            this.panelChapter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelChapter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.panelChapter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChapter.Controls.Add(this.labelIntro);
            this.panelChapter.Controls.Add(this.labelEpisode1);
            this.panelChapter.Controls.Add(this.labelEpisode2);
            this.panelChapter.Controls.Add(this.labelCredits);
            this.panelChapter.Location = new System.Drawing.Point(100, 0);
            this.panelChapter.Name = "panelChapter";
            this.panelChapter.Size = new System.Drawing.Size(731, 122);
            this.panelChapter.TabIndex = 17;
            this.panelChapter.Visible = false;
            this.panelChapter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBorder_MouseMove);
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIntro.Location = new System.Drawing.Point(0, 8);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(48, 22);
            this.labelIntro.TabIndex = 13;
            this.labelIntro.Text = "Intro";
            this.labelIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelIntro.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelIntro_MouseDown);
            this.labelIntro.MouseEnter += new System.EventHandler(this.labelChapter_MouseEnter);
            this.labelIntro.MouseLeave += new System.EventHandler(this.labelChapter_MouseLeave);
            // 
            // labelEpisode1
            // 
            this.labelEpisode1.AutoSize = true;
            this.labelEpisode1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEpisode1.Location = new System.Drawing.Point(0, 36);
            this.labelEpisode1.Name = "labelEpisode1";
            this.labelEpisode1.Size = new System.Drawing.Size(92, 22);
            this.labelEpisode1.TabIndex = 14;
            this.labelEpisode1.Text = "Episode1";
            this.labelEpisode1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEpisode1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelEpisode1_MouseDown);
            this.labelEpisode1.MouseEnter += new System.EventHandler(this.labelChapter_MouseEnter);
            this.labelEpisode1.MouseLeave += new System.EventHandler(this.labelChapter_MouseLeave);
            // 
            // labelEpisode2
            // 
            this.labelEpisode2.AutoSize = true;
            this.labelEpisode2.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEpisode2.Location = new System.Drawing.Point(0, 64);
            this.labelEpisode2.Name = "labelEpisode2";
            this.labelEpisode2.Size = new System.Drawing.Size(92, 22);
            this.labelEpisode2.TabIndex = 15;
            this.labelEpisode2.Text = "Episode2";
            this.labelEpisode2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEpisode2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelEpisode2_MouseDown);
            this.labelEpisode2.MouseEnter += new System.EventHandler(this.labelChapter_MouseEnter);
            this.labelEpisode2.MouseLeave += new System.EventHandler(this.labelChapter_MouseLeave);
            // 
            // labelCredits
            // 
            this.labelCredits.AutoSize = true;
            this.labelCredits.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCredits.Location = new System.Drawing.Point(0, 92);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(71, 22);
            this.labelCredits.TabIndex = 16;
            this.labelCredits.Text = "Credits";
            this.labelCredits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCredits.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelCredits_MouseDown);
            this.labelCredits.MouseEnter += new System.EventHandler(this.labelChapter_MouseEnter);
            this.labelCredits.MouseLeave += new System.EventHandler(this.labelChapter_MouseLeave);
            // 
            // timerPlayer
            // 
            this.timerPlayer.Interval = 750;
            this.timerPlayer.Tick += new System.EventHandler(this.timerPlayer_Tick);
            // 
            // timerVisibility
            // 
            this.timerVisibility.Interval = 1500;
            this.timerVisibility.Tick += new System.EventHandler(this.timerVisibility_Tick);
            // 
            // panelLoading
            // 
            this.panelLoading.BackColor = System.Drawing.Color.Black;
            this.panelLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoading.Location = new System.Drawing.Point(0, 0);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new System.Drawing.Size(960, 720);
            this.panelLoading.TabIndex = 12;
            this.panelLoading.Visible = false;
            this.panelLoading.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLoading_Paint);
            this.panelLoading.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelLoading_MouseClick);
            // 
            // timerLogo
            // 
            this.timerLogo.Interval = 40;
            this.timerLogo.Tick += new System.EventHandler(this.timerLogo_Tick);
            // 
            // PlayerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.panelLoading);
            this.Controls.Add(this.panelChapter);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.VLCview);
            this.DoubleBuffered = true;
            this.Name = "PlayerPanel";
            this.Size = new System.Drawing.Size(960, 720);
            ((System.ComponentModel.ISupportInitialize)(this.VLCview)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.barProgress.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.barVolume.ResumeLayout(false);
            this.panelChapter.ResumeLayout(false);
            this.panelChapter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private LibVLCSharp.WinForms.VideoView VLCview;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel barProgress;
        private System.Windows.Forms.Panel barProgressMark;
        private System.Windows.Forms.Panel barProgressLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel buttonClose;
        private System.Windows.Forms.Panel buttonPlay;
        private System.Windows.Forms.Panel buttonChapter;
        private System.Windows.Forms.Panel buttonReset;
        private System.Windows.Forms.Panel buttonAudio;
        private System.Windows.Forms.Panel buttonSubtitle;
        private System.Windows.Forms.Panel speaker;
        private System.Windows.Forms.Panel barVolume;
        private System.Windows.Forms.Panel barVolumeLeft;
        private System.Windows.Forms.Panel barVolumeMark;
        private System.Windows.Forms.Panel barVolumeRight;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelChapter;
        private System.Windows.Forms.Label labelCredits;
        private System.Windows.Forms.Label labelEpisode2;
        private System.Windows.Forms.Label labelEpisode1;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Timer timerPlayer;
        private System.Windows.Forms.Timer timerVisibility;
        private System.Windows.Forms.Panel barProgressRight;
        private System.Windows.Forms.Label panelLoading;
        private System.Windows.Forms.Timer timerLogo;
    }
}
