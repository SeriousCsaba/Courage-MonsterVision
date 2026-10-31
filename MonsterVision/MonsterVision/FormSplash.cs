using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterVision
{
    public partial class FormSplash : Form
    {
        const string coreName = "MonsterVision.Core";
        bool fading;

        Timer timer;

        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Shown(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 500;
            timer.Enabled = true;
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == 0x0112 && (message.WParam.ToInt32() & 0xfff0) == 0xF010)
                return; //Prevent window movement
            base.WndProc(ref message);
        }

        void Fade()
        {
            fading = true;
            timer.Interval = 1000 / 60;
            timer.Enabled = true;
        }

        async void LoadCore(string dll)
        {
            Form core = null;
            await Task.Run(() =>
            {
                Assembly assembly = Assembly.LoadFrom(dll);
                core = (Form)Activator.CreateInstance(assembly.GetType(coreName + ".FormMain"), new object[] { Program.OldTVMode });
                core.Shown += (object sender, EventArgs e) => Fade();
                core.FormClosed += (object sender, FormClosedEventArgs e) => Close();
            });
            core.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (fading)
            {
                Opacity -= 0.1f;
                if (Opacity < 0.1f)
                {
                    Hide();
                    timer.Enabled = false;
                }
            }
            else
            {
                timer.Enabled = false;
                string dll = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, coreName + ".dll", SearchOption.AllDirectories).FirstOrDefault();
                if (dll != "")
                    LoadCore(dll);
                else
                    Application.Exit();
            }
        }
    }
}
