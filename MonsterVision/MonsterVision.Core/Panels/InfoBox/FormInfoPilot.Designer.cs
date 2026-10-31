
namespace MonsterVision.Core
{
    partial class FormInfoPilot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfoPilot));
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTitle.Location = new System.Drawing.Point(72, 28);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(300, 20);
            this.textBoxTitle.TabIndex = 3;
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(72, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(300, 13);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxDescription.DetectUrls = false;
            this.richTextBoxDescription.Location = new System.Drawing.Point(12, 128);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.ReadOnly = true;
            this.richTextBoxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBoxDescription.Size = new System.Drawing.Size(360, 200);
            this.richTextBoxDescription.TabIndex = 7;
            this.richTextBoxDescription.Text = "";
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(12, 112);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(360, 13);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxSource
            // 
            this.textBoxSource.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxSource.Location = new System.Drawing.Point(12, 70);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ReadOnly = true;
            this.textBoxSource.Size = new System.Drawing.Size(360, 20);
            this.textBoxSource.TabIndex = 5;
            // 
            // labelSource
            // 
            this.labelSource.Location = new System.Drawing.Point(12, 54);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(360, 13);
            this.labelSource.TabIndex = 4;
            this.labelSource.Text = "Source";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelDate
            // 
            this.labelDate.Location = new System.Drawing.Point(12, 12);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(50, 13);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxDate
            // 
            this.textBoxDate.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDate.Location = new System.Drawing.Point(12, 28);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.ReadOnly = true;
            this.textBoxDate.Size = new System.Drawing.Size(50, 20);
            this.textBoxDate.TabIndex = 1;
            // 
            // FormInfoPilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(219)))), ((int)(((byte)(140)))));
            this.ClientSize = new System.Drawing.Size(384, 347);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.textBoxTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormInfoPilot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Episode Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxDate;
    }
}