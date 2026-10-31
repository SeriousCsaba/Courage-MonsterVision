
namespace MonsterVision.Core
{
    partial class SpecialPanel
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
            this.listBoxSpecial = new System.Windows.Forms.ListBox();
            this.tabControlSpecial = new System.Windows.Forms.TabControl();
            this.tabPageSpecialEpisodes = new System.Windows.Forms.TabPage();
            this.tabPageSpecialAds = new System.Windows.Forms.TabPage();
            this.tabPageSpecialPilots = new System.Windows.Forms.TabPage();
            this.tabPageSpecialMovies = new System.Windows.Forms.TabPage();
            this.listViewSpecial = new System.Windows.Forms.ListView();
            this.tabControlSpecial.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxSpecial
            // 
            this.listBoxSpecial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxSpecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.listBoxSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSpecial.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxSpecial.ForeColor = System.Drawing.Color.Black;
            this.listBoxSpecial.FormattingEnabled = true;
            this.listBoxSpecial.ItemHeight = 16;
            this.listBoxSpecial.Location = new System.Drawing.Point(466, 145);
            this.listBoxSpecial.Name = "listBoxSpecial";
            this.listBoxSpecial.ScrollAlwaysVisible = true;
            this.listBoxSpecial.Size = new System.Drawing.Size(475, 290);
            this.listBoxSpecial.TabIndex = 0;
            this.listBoxSpecial.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSpecial_MouseDoubleClick);
            this.listBoxSpecial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSpecial_MouseDown);
            // 
            // tabControlSpecial
            // 
            this.tabControlSpecial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControlSpecial.Controls.Add(this.tabPageSpecialEpisodes);
            this.tabControlSpecial.Controls.Add(this.tabPageSpecialAds);
            this.tabControlSpecial.Controls.Add(this.tabPageSpecialPilots);
            this.tabControlSpecial.Controls.Add(this.tabPageSpecialMovies);
            this.tabControlSpecial.Location = new System.Drawing.Point(466, 125);
            this.tabControlSpecial.Name = "tabControlSpecial";
            this.tabControlSpecial.SelectedIndex = 0;
            this.tabControlSpecial.Size = new System.Drawing.Size(475, 20);
            this.tabControlSpecial.TabIndex = 1;
            this.tabControlSpecial.SelectedIndexChanged += new System.EventHandler(this.tabControlSpecial_SelectedIndexChanged);
            // 
            // tabPageSpecialEpisodes
            // 
            this.tabPageSpecialEpisodes.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecialEpisodes.Name = "tabPageSpecialEpisodes";
            this.tabPageSpecialEpisodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecialEpisodes.Size = new System.Drawing.Size(467, 0);
            this.tabPageSpecialEpisodes.TabIndex = 0;
            this.tabPageSpecialEpisodes.Text = "Episodes";
            this.tabPageSpecialEpisodes.UseVisualStyleBackColor = true;
            // 
            // tabPageSpecialAds
            // 
            this.tabPageSpecialAds.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecialAds.Name = "tabPageSpecialAds";
            this.tabPageSpecialAds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecialAds.Size = new System.Drawing.Size(467, 0);
            this.tabPageSpecialAds.TabIndex = 1;
            this.tabPageSpecialAds.Text = "Commercials";
            this.tabPageSpecialAds.UseVisualStyleBackColor = true;
            // 
            // tabPageSpecialPilots
            // 
            this.tabPageSpecialPilots.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecialPilots.Name = "tabPageSpecialPilots";
            this.tabPageSpecialPilots.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecialPilots.Size = new System.Drawing.Size(467, 0);
            this.tabPageSpecialPilots.TabIndex = 2;
            this.tabPageSpecialPilots.Text = "Pilots";
            this.tabPageSpecialPilots.UseVisualStyleBackColor = true;
            // 
            // tabPageSpecialMovies
            // 
            this.tabPageSpecialMovies.Location = new System.Drawing.Point(4, 22);
            this.tabPageSpecialMovies.Name = "tabPageSpecialMovies";
            this.tabPageSpecialMovies.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSpecialMovies.Size = new System.Drawing.Size(467, 0);
            this.tabPageSpecialMovies.TabIndex = 3;
            this.tabPageSpecialMovies.Text = "Movies";
            this.tabPageSpecialMovies.UseVisualStyleBackColor = true;
            // 
            // listViewSpecial
            // 
            this.listViewSpecial.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listViewSpecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.listViewSpecial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSpecial.HideSelection = false;
            this.listViewSpecial.Location = new System.Drawing.Point(466, 145);
            this.listViewSpecial.MultiSelect = false;
            this.listViewSpecial.Name = "listViewSpecial";
            this.listViewSpecial.Size = new System.Drawing.Size(475, 290);
            this.listViewSpecial.TabIndex = 2;
            this.listViewSpecial.UseCompatibleStateImageBehavior = false;
            this.listViewSpecial.Visible = false;
            this.listViewSpecial.ItemActivate += new System.EventHandler(this.listViewSpecial_ItemActivate);
            this.listViewSpecial.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewSpecial_MouseDown);
            // 
            // SpecialPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listViewSpecial);
            this.Controls.Add(this.listBoxSpecial);
            this.Controls.Add(this.tabControlSpecial);
            this.DoubleBuffered = true;
            this.Name = "SpecialPanel";
            this.Size = new System.Drawing.Size(960, 502);
            this.Load += new System.EventHandler(this.SpecialPanel_Load);
            this.tabControlSpecial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSpecial;
        private System.Windows.Forms.TabControl tabControlSpecial;
        private System.Windows.Forms.TabPage tabPageSpecialEpisodes;
        private System.Windows.Forms.TabPage tabPageSpecialAds;
        private System.Windows.Forms.TabPage tabPageSpecialPilots;
        private System.Windows.Forms.TabPage tabPageSpecialMovies;
        private System.Windows.Forms.ListView listViewSpecial;
    }
}
