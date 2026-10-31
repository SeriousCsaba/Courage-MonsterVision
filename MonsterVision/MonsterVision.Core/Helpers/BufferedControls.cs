using System.Reflection;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    static class BufferedControls
    {
        public static void EnableDoubleBuffering(this Control control)
        {
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, control, new object[] { true });
        }

        public static void EnableDoubleBuffering(this ContainerControl container)
        {
            foreach (Control control in container.Controls)
                if (control is Panel || control is Label)
                    control.EnableDoubleBuffering();
        }
    }
}
