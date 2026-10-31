
namespace MonsterVision.Core
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.specialPanel = new MonsterVision.Core.SpecialPanel();
            this.searchPanel = new MonsterVision.Core.SearchPanel();
            this.playerPanel = new MonsterVision.Core.PlayerPanel();
            this.SuspendLayout();
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // specialPanel
            // 
            this.specialPanel.BackColor = System.Drawing.Color.Transparent;
            this.specialPanel.Location = new System.Drawing.Point(0, 0);
            this.specialPanel.Name = "specialPanel";
            this.specialPanel.Size = new System.Drawing.Size(960, 502);
            this.specialPanel.TabIndex = 1;
            this.specialPanel.TabStop = false;
            this.specialPanel.Visible = false;
            this.specialPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.specialPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDoubleClick);
            this.specialPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.Transparent;
            this.searchPanel.Location = new System.Drawing.Point(0, 0);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(960, 502);
            this.searchPanel.TabIndex = 0;
            this.searchPanel.TabStop = false;
            this.searchPanel.Visible = false;
            this.searchPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.searchPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDoubleClick);
            this.searchPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            // 
            // playerPanel
            // 
            this.playerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.playerPanel.Location = new System.Drawing.Point(0, 0);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(960, 720);
            this.playerPanel.TabIndex = 2;
            this.playerPanel.TabStop = false;
            this.playerPanel.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(960, 720);
            this.Controls.Add(this.playerPanel);
            this.Controls.Add(this.specialPanel);
            this.Controls.Add(this.searchPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MonsterVision";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormMain_PreviewKeyDown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerUpdate;
        private SearchPanel searchPanel;
        private SpecialPanel specialPanel;
        private PlayerPanel playerPanel;
    }
}

