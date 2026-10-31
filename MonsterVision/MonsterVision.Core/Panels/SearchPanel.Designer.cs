
namespace MonsterVision.Core
{
    partial class SearchPanel
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
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.buttonTags = new System.Windows.Forms.Label();
            this.radioButtonSubtitles = new System.Windows.Forms.RadioButton();
            this.radioButtonTitles = new System.Windows.Forms.RadioButton();
            this.radioButtonTags = new System.Windows.Forms.RadioButton();
            this.listBoxSearch = new System.Windows.Forms.ListBox();
            this.listBoxTags = new System.Windows.Forms.ListBox();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.textBoxSearch.Location = new System.Drawing.Point(5, 5);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(390, 24);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Click += new System.EventHandler(this.search_Click);
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.buttonTags);
            this.panelSearch.Controls.Add(this.radioButtonSubtitles);
            this.panelSearch.Controls.Add(this.radioButtonTitles);
            this.panelSearch.Controls.Add(this.radioButtonTags);
            this.panelSearch.Controls.Add(this.textBoxSearch);
            this.panelSearch.Location = new System.Drawing.Point(19, 145);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(430, 60);
            this.panelSearch.TabIndex = 0;
            this.panelSearch.Click += new System.EventHandler(this.search_Click);
            // 
            // buttonTags
            // 
            this.buttonTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonTags.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTags.ForeColor = System.Drawing.Color.Black;
            this.buttonTags.Location = new System.Drawing.Point(400, 5);
            this.buttonTags.Name = "buttonTags";
            this.buttonTags.Size = new System.Drawing.Size(23, 24);
            this.buttonTags.TabIndex = 2;
            this.buttonTags.Text = "+";
            this.buttonTags.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonTags_MouseClick);
            // 
            // radioButtonSubtitles
            // 
            this.radioButtonSubtitles.AutoSize = true;
            this.radioButtonSubtitles.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonSubtitles.ForeColor = System.Drawing.Color.Black;
            this.radioButtonSubtitles.Location = new System.Drawing.Point(147, 34);
            this.radioButtonSubtitles.Name = "radioButtonSubtitles";
            this.radioButtonSubtitles.Size = new System.Drawing.Size(74, 17);
            this.radioButtonSubtitles.TabIndex = 5;
            this.radioButtonSubtitles.Text = "Subtitles";
            this.radioButtonSubtitles.UseVisualStyleBackColor = false;
            this.radioButtonSubtitles.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            this.radioButtonSubtitles.Click += new System.EventHandler(this.search_Click);
            // 
            // radioButtonTitles
            // 
            this.radioButtonTitles.AutoSize = true;
            this.radioButtonTitles.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonTitles.ForeColor = System.Drawing.Color.Black;
            this.radioButtonTitles.Location = new System.Drawing.Point(77, 34);
            this.radioButtonTitles.Name = "radioButtonTitles";
            this.radioButtonTitles.Size = new System.Drawing.Size(55, 17);
            this.radioButtonTitles.TabIndex = 4;
            this.radioButtonTitles.Text = "Titles";
            this.radioButtonTitles.UseVisualStyleBackColor = false;
            this.radioButtonTitles.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            this.radioButtonTitles.Click += new System.EventHandler(this.search_Click);
            // 
            // radioButtonTags
            // 
            this.radioButtonTags.AutoSize = true;
            this.radioButtonTags.Checked = true;
            this.radioButtonTags.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonTags.ForeColor = System.Drawing.Color.Black;
            this.radioButtonTags.Location = new System.Drawing.Point(7, 34);
            this.radioButtonTags.Name = "radioButtonTags";
            this.radioButtonTags.Size = new System.Drawing.Size(51, 17);
            this.radioButtonTags.TabIndex = 3;
            this.radioButtonTags.TabStop = true;
            this.radioButtonTags.Text = "Tags";
            this.radioButtonTags.UseVisualStyleBackColor = false;
            this.radioButtonTags.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            this.radioButtonTags.Click += new System.EventHandler(this.search_Click);
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.listBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSearch.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxSearch.ForeColor = System.Drawing.Color.Black;
            this.listBoxSearch.FormattingEnabled = true;
            this.listBoxSearch.ItemHeight = 16;
            this.listBoxSearch.Location = new System.Drawing.Point(466, 145);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.ScrollAlwaysVisible = true;
            this.listBoxSearch.Size = new System.Drawing.Size(475, 290);
            this.listBoxSearch.TabIndex = 7;
            this.listBoxSearch.Click += new System.EventHandler(this.search_Click);
            this.listBoxSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxSearch_MouseDoubleClick);
            this.listBoxSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxSearch_MouseDown);
            // 
            // listBoxTags
            // 
            this.listBoxTags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.listBoxTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxTags.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxTags.FormattingEnabled = true;
            this.listBoxTags.ItemHeight = 16;
            this.listBoxTags.Location = new System.Drawing.Point(431, 165);
            this.listBoxTags.Name = "listBoxTags";
            this.listBoxTags.ScrollAlwaysVisible = true;
            this.listBoxTags.Size = new System.Drawing.Size(140, 322);
            this.listBoxTags.TabIndex = 6;
            this.listBoxTags.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxTags_MouseClick);
            // 
            // SearchPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.listBoxTags);
            this.Controls.Add(this.listBoxSearch);
            this.Controls.Add(this.panelSearch);
            this.DoubleBuffered = true;
            this.Name = "SearchPanel";
            this.Size = new System.Drawing.Size(960, 502);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SearchPanel_MouseClick);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.RadioButton radioButtonTags;
        private System.Windows.Forms.RadioButton radioButtonTitles;
        private System.Windows.Forms.RadioButton radioButtonSubtitles;
        private System.Windows.Forms.ListBox listBoxSearch;
        private System.Windows.Forms.Label buttonTags;
        private System.Windows.Forms.ListBox listBoxTags;
    }
}
