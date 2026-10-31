using System;
using System.Windows.Forms;

namespace MonsterVision
{
    static class Program
    {
        public static bool OldTVMode;

        static bool IsParameterSet(string[] args, string parameter)
        {
            if (args.Length > 0)
                foreach (string arg in args)
                    if (arg.ToLower().Replace("-", "").Contains(parameter))
                        return true;
            return false;
        }


        [STAThread]
        static void Main(string[] args)
        {
            OldTVMode = IsParameterSet(args, "oldtv") || IsParameterSet(args, "oldtvmode") || IsParameterSet(args, "tvmode");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSplash());
        }
    }
}
