using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    public partial class FormInfo : Form
    {
        public FormInfo(EpisodeInfo episode1, EpisodeInfo episode2, string search, string find)
        {
            InitializeComponent();
            Text += " " + episode1.FileID;

            //Title
            textBoxTitle1.Text = episode1.Title;
            if (episode1.Title == episode2.Title)
                textBoxTitle2.Visible = false;
            else
                textBoxTitle2.Text = episode2.Title;

            //Tags
            SetupTags(episode1, search, listBoxTags1);
            if (episode1.Title == episode2.Title)
            {
                listBoxTags2.Visible = false;
                listBoxTags1.Width = labelTags.Width;
            }
            else
                SetupTags(episode2, search, listBoxTags2);
            listBoxTags1.SelectedIndexChanged += listBoxTags_SelectedIndexChanged;
            listBoxTags2.SelectedIndexChanged += listBoxTags_SelectedIndexChanged;

            //Subtitles
            if (File.Exists(episode1.FileSUB))
            {
                richTextBoxSub.Text = File.ReadAllText(episode1.FileSUB);
                if (find != "")
                {
                    richTextBoxSub.Select(richTextBoxSub.Find(find), find.Length);
                    richTextBoxSub.SelectionBackColor = SystemColors.Highlight;
                    richTextBoxSub.SelectionColor = Color.White;
                    richTextBoxSub.ScrollToCaret();
                }
            }
            else
            {
                labelSub.Visible = false;
                richTextBoxSub.Visible = false;
            }
        }

        public FormInfo(EpisodeInfo episode1, EpisodeInfo episode2) : this(episode1, episode2, "", "")
        {
            textBoxTitle1.SelectionStart = 0;
        }

        void SetupTags(EpisodeInfo episode, string search, ListBox tags)
        {
            foreach (string tag in episode.Tags.Split(' '))
                tags.Items.Add(tag);
            if (search != "")
                foreach (string s in search.Split(' '))
                    for (int i = 0; i < tags.Items.Count; i++)
                        if (tags.Items[i].ToString() == s)
                        {
                            tags.SetSelected(i, true);
                            break;
                        }
        }

        private void listBoxTags_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            listBoxTags1.ClearSelected();
            listBoxTags2.ClearSelected();
        }
    }
}
