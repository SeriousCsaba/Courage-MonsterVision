using System.Drawing;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class FormInfoPilot : Form
    {
        public FormInfoPilot(string title, string description)
        {
            InitializeComponent();

            //Date
            if (title.Contains("(") && title.Contains(")"))
            {
                textBoxDate.Text = title.Substring(title.IndexOf("(") + 1, title.IndexOf(")") - title.IndexOf("(") - 1);
                title = title.Replace("(" + textBoxDate.Text + ")", "").Trim();
            }

            //Title
            textBoxTitle.Text = title;

            //Source
            if (description.StartsWith("http"))
            {
                textBoxSource.Text = description.Split('\n')[0];
                description = description.Replace(textBoxSource.Text, "").Trim();
            }
            else
            {
                labelSource.Visible = false;
                textBoxSource.Visible = false;
                const int amount = 42;
                labelDescription.Location = new Point(labelDescription.Location.X, labelDescription.Location.Y - amount);
                richTextBoxDescription.Location = new Point(richTextBoxDescription.Location.X, richTextBoxDescription.Location.Y - amount);
                richTextBoxDescription.Height += amount;
            }

            //Description
            richTextBoxDescription.Text = description;
        }
    }
}
