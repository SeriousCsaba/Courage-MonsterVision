using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterVision.Core
{
    static class Converter //Added class so Visual Studio won't open this file in designer
    {
        public static readonly string EXE = "ffmpeg.exe";
        public static readonly string BAT = "CONVERT.bat";
    }

    public partial class PlayerPanel : UserControl
    {
        void StartConverting(string tool, string args)
        {
            ProcessStartInfo startInfo;
            startInfo = new ProcessStartInfo(tool, args);
            startInfo.WorkingDirectory = Folder.Episodes;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            converter = Process.Start(startInfo);
        }

        void WaitForFinish()
        {
            converter.WaitForExit();
            loadingNoise = false;
            Thread.Sleep(100);
            converter = null;
            converted = true;
            if (!File.Exists(episodes.Selected.FileMP4))
            {
                criticalStop = true;
                FormMain.ShowErrorMessage("Unable to play episode", critical: true);
            }
        }

        async Task ConvertEpisodeBAT()
        {
            StartConverting(Converter.BAT, episodes.Selected.Season + " " + episodes.Selected.Episode);
            await Task.Run(WaitForFinish);
        }

        async Task ConvertEpisodeEXE()
        {
            bool generatedTxt = false;
            string vidInput = Path.Combine(Folder.English.Replace(Folder.Episodes, ""), episodes.Selected.FileID + ".txt");
            string hunInput = Path.Combine(Folder.Hungarian.Replace(Folder.Episodes, ""), episodes.Selected.FileID + ".mp3");
            string subInput = Path.Combine(Folder.Subtitles.Replace(Folder.Episodes, ""), episodes.Selected.FileID + ".srt");
            string map = "";
            string hunMeta = "";
            string subMeta = "";
            string subEncode = "";

            //Gonna need a txt file containing names of both chapter video files
            if (!File.Exists(Path.Combine(Folder.Episodes, vidInput)))
            {
                string txt = "";

                string[] files = Directory.GetFiles(Folder.English);
                List<string> videoFiles = new List<string>();
                foreach (string file in files)
                    if (Path.GetExtension(file).ToLower() == ".mkv" || Path.GetExtension(file).ToLower() == ".mp4")
                        videoFiles.Add(file);

                int index = episodes.Info.IndexOf(episodes.Selected);
                if (episodes.Selected.Season == 4 && episodes.Selected.Episode > 7) //After S04E07
                    index--;
                if (episodes.Selected.Season > 2) //After S02E13
                    index--;

                txt = "file '" + Path.GetFileName(videoFiles[index]) + "'" + Environment.NewLine;
                if (!(episodes.Selected.Season == 2 && episodes.Selected.Episode == 13) && !(episodes.Selected.Season == 4 && episodes.Selected.Episode == 7)) //S02E13 and S04E07 got only one file
                    txt += "file '" + Path.GetFileName(videoFiles[index + 1]) + "'" + Environment.NewLine;

                File.WriteAllText(Path.Combine(Folder.Episodes, vidInput), txt);
                generatedTxt = true;
            }

            //Add hungarian audio if exists
            if (File.Exists(Path.Combine(Folder.Episodes, hunInput)))
            {
                hunInput = " -i " + hunInput;
                map = " -map 1:0";
                hunMeta = " -metadata:s:a:1 language=hun";
            }
            else
                hunInput = "";

            //Add subtitles if exists
            if (File.Exists(Path.Combine(Folder.Episodes, subInput)))
            {
                subInput = " -i " + subInput;
                map += " -map " + (map == "" ? 1 : 2) + ":0";
                subMeta = " -metadata:s:s:0 language=eng";
                subEncode = " -c:s mov_text";
            }
            else
                subInput = "";

            //Run FFmpeg
            StartConverting(Converter.EXE, "-y -safe 0 -f concat -i " + vidInput + hunInput + subInput + " -map 0:0 -map 0:1" + map + hunMeta + subMeta + " -c copy" + subEncode + " \"" + Path.Combine(Directory.GetCurrentDirectory(), episodes.Selected.FileMP4) + "\"");
            await Task.Run(WaitForFinish);
            if (generatedTxt)
                File.Delete(Path.Combine(Folder.Episodes, vidInput));
        }
    }
}
