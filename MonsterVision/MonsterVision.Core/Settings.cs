using System.IO;

namespace MonsterVision.Core
{
    static class Settings
    {
        static readonly string SettingsFile = "MonsterVision.settings";

        public static bool EnglishAudio { get; set; }
        public static bool Subtitles { get; set; }
        public static string Logo { get; set; }
        public static bool LogoIsSet { get { return Logo != null && Logo != ""; } }

        public static void Save()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFile, FileMode.Create)))
            {
                writer.Write(EnglishAudio);
                writer.Write(Subtitles);
                writer.Write(Logo ?? "");
            }
        }

        public static void Load()
        {
            try
            {
                if (!File.Exists(SettingsFile))
                    Reset();
                else
                    using (BinaryReader reader = new BinaryReader(File.OpenRead(SettingsFile)))
                    {
                        EnglishAudio = reader.ReadBoolean();
                        Subtitles = reader.ReadBoolean();
                        Logo = reader.ReadString();
                    }
            }
            catch
            {
                Reset();
            }
        }

        public static void Reset()
        {
            EnglishAudio = true;
            Subtitles = false;
            Logo = "";
            try
            {
                if (File.Exists(SettingsFile))
                    File.Delete(SettingsFile);
            }
            catch { }
        }
    }
}
