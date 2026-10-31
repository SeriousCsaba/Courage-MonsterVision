# MonsterVision
A Windows program for watching Courage the Cowardly Dog episodes. Episodes not included.

<img width="320" height="249" alt="MonsterVision" src="https://github.com/user-attachments/assets/3f08a5f3-0661-46eb-8938-3351a73e3447" />

## Main Features
**Menu** - Navigate a DVD-style menu using your mouse.<br>
**Search** - Easily look for an episode you want to watch using tags.<br>
**Video player** - Watch episodes within the application.<br>
**Logo** - Display a channel watermark in the corner when playing an episode.<br>

<img width="1920" height="360" alt="Screenshot1" src="https://github.com/user-attachments/assets/fc9a3206-c319-4d8d-b30f-bf809eac924e" />

<img width="1920" height="360" alt="Screenshot2" src="https://github.com/user-attachments/assets/b7699c10-60c7-4718-8b97-0239aa69ba04" />


### The Menu
Design inspired by the Hall of Fame DVD release of the first season.

### The Video Player
Uses a VLC library to play videos. Design inspired by the TV from the show.

## Setup
To add episodes you have 3 options:

- #### Option 1
  Put episodes into the Episodes folder. Each episode must contain both 10 minute long chapters in one file. File type can be anything that VLC can play but you must rename extension to MP4.

- #### Option 2
  Place FFmpeg into the Episodes folder, and place episode chapters into the English folder. Optionally, you can also place external SRT subtitles into the Subtitles folder, and Hungarian audio tracks in MP3 format into the Hungarian folder. The program will use FFmpeg to merge multiple video files into a single episode.<br>
Here's an example of what might be ran by the program:<br>
  ```ffmpeg.exe -y -safe 0 -f concat -i English\S01E01.txt -i Hungarian\S01E01.mp3 -i Subtitles\S01E01.srt -map 0:0 -map 0:1 -map 1:0 -map 2:0 -metadata:s:a:1 language=hun -metadata:s:s:0 language=eng -c copy -c:s mov_text S01E01.mp4```

- #### Option 3
  If the above FFmpeg command isn't optimal for you, place a CONVERT.bat file into the Episodes folder and write a script the way you prefer.<br>For example something like this:
  ```
  @echo off
  set season=%1
  set episode=0%2
  set episode=%episode:~-2%
  ffmpeg.exe -safe 0 -f concat -i English\S0%season%E%episode%.txt -map 0:0 -map 0:1 -c copy S0%season%E%episode%.mp4
  ```
> [!TIP]
> Personally I'm using option 2. I can't give you a link for the source, I can only say it's a release by **QxR**.<br><sub>Also worth mentioning that S01E06 needed remuxing because their resolutions differ.</sub>

## Build info
Project type: Windows Forms App (C#)<br>
Target framework: .NET Framework 4.5.2<br>
LibVLCSharp version: 3.10.2<br>
VideoLAN LibVLC version: 3.0.24
