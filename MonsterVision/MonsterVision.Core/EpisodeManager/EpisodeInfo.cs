using System;
using System.IO;

namespace MonsterVision.Core
{
    public class EpisodeInfo
    {
        public string FileID => "S" + Season.ToString("00") + "E" + Episode.ToString("00");
        public string FileMP4 => Path.Combine(Folder.Episodes, FileID + ".mp4");
        public string FileSUB => Path.Combine(Folder.Subtitles, FileID + ".srt");
        string FileJSON => Path.Combine(Folder.Info, FileID + ".json");

        public int Season { get; private set; }
        public int Episode { get; private set; }
        public int Chapter { get; private set; }
        public string Title { get; private set; }
        public TimeSpan Timestamp { get; private set; }
        public string Tags { get; private set; }

        public EpisodeInfo(int season, int episode, int chapter)
        {
            Season = season;
            Episode = episode;
            Chapter = chapter;
            Tags = "";
            string[] lines;
            if (File.Exists(FileJSON))
                lines = File.ReadAllLines(FileJSON);
            else
                lines = "{\n\"chapter1\": {\n\"title\": \"Unknown\",\n\"timestamp\": \"0:30\",\n\"chapter2\": {\n\"title\": \"Unknown\",\n\"timestamp\": \"10:00\",\n}\n}".Split('\n');
            int i = 0;
            while (!lines[i].Contains("chapter" + chapter))
                if (i < lines.Length - 1)
                    i++;
                else
                    return;
            i++;
            while (!lines[i].Contains("chapter") && i < lines.Length - 1)
            {
                if (lines[i].Contains("title"))
                    Title = lines[i].Split('\"')[3];
                if (lines[i].Contains("timestamp"))
                    Timestamp = TimeSpan.ParseExact(lines[i].Split('\"')[3], "m\\:ss", null);
                if (lines[i].Contains("tags"))
                    Tags = lines[i].Split(':')[1].Replace("[", "").Replace("]", "").Replace("\"", "").Replace(",", "").Trim();
                i++;
            }
        }
    }
}
