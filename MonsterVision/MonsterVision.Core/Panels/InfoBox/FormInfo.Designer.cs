
namespace MonsterVision.Core
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.textBoxTitle1 = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle2 = new System.Windows.Forms.TextBox();
            this.listBoxTags1 = new System.Windows.Forms.ListBox();
            this.listBoxTags2 = new System.Windows.Forms.ListBox();
            this.labelTags = new System.Windows.Forms.Label();
            this.richTextBoxSub = new System.Windows.Forms.RichTextBox();
            this.labelSub = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxTitle1
            // 
            this.textBoxTitle1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTitle1.Location = new System.Drawing.Point(12, 28);
            this.textBoxTitle1.Name = "textBoxTitle1";
            this.textBoxTitle1.ReadOnly = true;
            this.textBoxTitle1.Size = new System.Drawing.Size(360, 20);
            this.textBoxTitle1.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(360, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxTitle2
            // 
            this.textBoxTitle2.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTitle2.Location = new System.Drawing.Point(12, 54);
            this.textBoxTitle2.Name = "textBoxTitle2";
            this.textBoxTitle2.ReadOnly = true;
            this.textBoxTitle2.Size = new System.Drawing.Size(360, 20);
            this.textBoxTitle2.TabIndex = 2;
            // 
            // listBoxTags1
            // 
            this.listBoxTags1.FormattingEnabled = true;
            this.listBoxTags1.Location = new System.Drawing.Point(12, 109);
            this.listBoxTags1.Name = "listBoxTags1";
            this.listBoxTags1.ScrollAlwaysVisible = true;
            this.listBoxTags1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTags1.Size = new System.Drawing.Size(160, 199);
            this.listBoxTags1.TabIndex = 4;
            // 
            // listBoxTags2
            // 
            this.listBoxTags2.FormattingEnabled = true;
            this.listBoxTags2.Location = new System.Drawing.Point(212, 109);
            this.listBoxTags2.Name = "listBoxTags2";
            this.listBoxTags2.ScrollAlwaysVisible = true;
            this.listBoxTags2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxTags2.Size = new System.Drawing.Size(160, 199);
            this.listBoxTags2.TabIndex = 5;
            // 
            // labelTags
            // 
            this.labelTags.Location = new System.Drawing.Point(12, 93);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(360, 13);
            this.labelTags.TabIndex = 3;
            this.labelTags.Text = "Tags";
            this.labelTags.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBoxSub
            // 
            this.richTextBoxSub.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxSub.DetectUrls = false;
            this.richTextBoxSub.Location = new System.Drawing.Point(12, 342);
            this.richTextBoxSub.Name = "richTextBoxSub";
            this.richTextBoxSub.ReadOnly = true;
            this.richTextBoxSub.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxSub.Size = new System.Drawing.Size(360, 200);
            this.richTextBoxSub.TabIndex = 7;
            this.richTextBoxSub.Text = "";
            this.richTextBoxSub.WordWrap = false;
            // 
            // labelSub
            // 
            this.labelSub.Location = new System.Drawing.Point(12, 326);
            this.labelSub.Name = "labelSub";
            this.labelSub.Size = new System.Drawing.Size(360, 13);
            this.labelSub.TabIndex = 6;
            this.labelSub.Text = "Subtitles";
            this.labelSub.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.labelSub);
            this.Controls.Add(this.richTextBoxSub);
            this.Controls.Add(this.labelTags);
            this.Controls.Add(this.listBoxTags2);
            this.Controls.Add(this.listBoxTags1);
            this.Controls.Add(this.textBoxTitle2);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Episode Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle2;
        private System.Windows.Forms.ListBox listBoxTags1;
        private System.Windows.Forms.ListBox listBoxTags2;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.RichTextBox richTextBoxSub;
        private System.Windows.Forms.Label labelSub;
    }
}