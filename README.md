# MonsterVision
A Windows program for watching <b>Courage the Cowardly Dog</b> episodes. Episodes NOT included.

<img width="320" height="249" alt="MonsterVision" src="https://github.com/user-attachments/assets/3f08a5f3-0661-46eb-8938-3351a73e3447" />

## Main Features
**Menu** - Navigate a DVD-style menu using your mouse.<br>
**Search** - Easily look for an episode you want to watch.<br>
**Video player** - Watch episodes within the application.<br>
**Logo** - Display a channel watermark in the corner when playing an episode.<br>

<img width="1920" height="360" alt="Screenshot1" src="https://github.com/user-attachments/assets/fc9a3206-c319-4d8d-b30f-bf809eac924e" />

<img width="1920" height="360" alt="Screenshot2" src="https://github.com/user-attachments/assets/b7699c10-60c7-4718-8b97-0239aa69ba04" />


### The Menu
Design inspired by the Hall of Fame DVD release of the first season.

### The Video Player
Design inspired by the TV from the show. Uses a VLC library to play videos.

## Setup
This repository does not host or store any video content. User must provide their own content.<br>
To add episodes you have 3 options:

- #### Option 1
  Put episodes into the Episodes folder. Each episode must contain both 10 minute long chapters in one file. File type can be anything that VLC can play but you must rename extension to MP4.

  <img width="170" height="43" alt="opt1" src="https://github.com/user-attachments/assets/6f6269ba-47d4-43ba-bee3-a3f788292a43" />

- #### Option 2
  Place FFmpeg into the Episodes folder, and place episode chapters into the English folder.<br>Optionally, you can also place external SRT subtitles into the Subtitles folder, and Hungarian audio tracks in MP3 format into the Hungarian folder.<br>The program will use FFmpeg to merge multiple video files into a single episode. Here's an example of what this might look like:<br>
  ```ffmpeg.exe -y -safe 0 -f concat -i English\S01E01.txt -i Hungarian\S01E01.mp3 -i Subtitles\S01E01.srt -map 0:0 -map 0:1 -map 1:0 -map 2:0 -metadata:s:a:1 language=hun -metadata:s:s:0 language=eng -c copy -c:s mov_text S01E01.mp4```
  <br>TXT files tell FFmpeg which files to merge. If you don't have them, the program will generate them for you. Just make sure you have every chapter in order.
  
  <img width="170" height="254" alt="opt2" src="https://github.com/user-attachments/assets/41b52d6f-a298-4f49-9497-77f1486a42d1" />

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

Other than the episodes, there are 3 folders you can fill up with special features.<br>These folders are: Commercials, Pilots, Movies.<br>Just drop your videos in there and they will show up in the Special menu.

## More Features

Double click an empty area to make the application fullscreen.<br>
<details>
<summary>Menu</summary>
<ul><li>Play menu<br><ul><li>Season menu<br>Contains all 13 episodes of a season, on two pages.<br>Hover your mouse on an a chapter title to change the thumbnail to that specific chapter. Hover your mouse on a thumbnail to start a timer that cycles through thumbnails. Play an episode from the start by clicking on the thumbnail. Play a specific chapter by clicking on the title of it.<br>Keep in mind that S02E13 and S04E07 are two parters. Meaning they're treated as a single chapter.</li><li>Special menu<br><ul><li>Episodes tab<br>Lists every episode in order. If the TitleCards folder is present in the Episodes folder, the list will contain images instead of text. The Random button will randomly highlight an episode from the list. To play the episode, press the Play button or double click the selected episode. Right click an episode to show basic information about it.</li><li>Commercials tab<br>It will attempt to list every video in the Commercials folder, if it exists. User can place their own collection of Courage ads in here. Similarly to the Episodes tab, there are buttons here too to play a random one.</li><li>Pilots tab<br>It will attempt to list every video in the Pilots folder, if it exists. User can place the pilot episodes in here. If a TXT file with the same name as the video is provided, right clicking the pilot will show the content of it. Make sure the file is named in a "(YEAR) TITLE" format, so the info box can show those too.</li><li>Movies tab<br>It will attempt to list every video in the Movies folder, if it exists. User can place the Scooby crossover movie here.</li></ul></li></ul></li><li>Search menu<br><ul><li>Search using Tags, Titles, Subtitles<br>Tags and Titles will be loaded from the JSON files in the Info folder of the Episodes folder. Subtitles will be loaded from the SRT files in the Subtitles folder. You can select the most common Tags by pressing the + icon. You can also type them manually, separating them with spaces. Subtitle search must be all lowercase.</li><li>Play a found episode by double clicking it, or by selecting it and pressing the Play button. Right clicking a selection shows basic information about the episode. If you looked for a specific sentence in the subtitles, then the episode will play at the first occurrence of that sentence.</li></ul></li><li>Settings menu<br>The Settings menu shows the global settings of the application. Values will be stored in a MonsterVision.settings file. These options can be changed locally when playing the episode, using VLC shortcuts.</li></ul>
</details>
<details>
<summary>Video player side buttons</summary>
<ul><li><ul><li>Power - Go back to menu.</li><li>Play - Play/Pause video.</li></ul></li><li><ul><li>Chapter - Jump to the start of a chapter.</li><li>Reset - Reset player if video is stuck.</li><li>Audio - Cycle audio track.</li><li>Subtitles - Cycle subtitle track.</li></ul></li><li>Speaker - Mute.</li><li>Volume bar - Change audio volume.</li><li>Seek bar - Jump around in the video.</li></ul>
</details>
<details>
<summary>VLC shortcuts</summary>
<table><tr><td><b>Keyboard</b></td><td><b>Command</b></td></tr><tr><td>Space</td><td>Play/Pause video.</td></tr><tr><td>Left/Right</td><td>Jump 10 seconds in the video. 5 seconds when holding Shift. 1 minute when holding Ctrl.</td></tr><tr><td>Up/Down</td><td>Change audio volume.</td></tr><tr><td>+/-</td><td>Change video speed.</td></tr><tr><td>F</td><td>Toggle fullscreen.</td></tr><tr><td>M</td><td>Mute.</td></tr><tr><td>B</td><td>Cycle audio track.</td></tr><tr><td>V</td><td>Cycle subtitle track.</td></tr><tr><td>E</td><td>Next frame.</td></tr><tr><td>R</td><td>Reset player.</td></tr><tr><td>Shift+S</td><td>Take snapshot.</td></tr><tr><td>F1</td><td>Show basic episode information.</td></tr><tr><td>Tab</td><td>Change logo.</td></tr><tr><td>Esc</td><td>Go back to menu.</td></tr></table>
</details>
<details>
<summary>Logo</summary>
Select a PNG to be displayed in the video as a watermark. You can find some examples in the Logo folder. File name must contain specific parameters to position the logo. These parameters include x,y,opacity,animate,pause,pingpong. For example x484-y338-opacity128-animate21-pause60000-pingpong will display a half-visible logo around the bottom right corner, the image will be split into 21 frames that will be played at 25 FPS after 1 minute of delay, and when the animation ends it plays backwards.
</details>
<details>
<summary>Old TV mode</summary>
Running the application with "oldtv" or "oldtvmode" or "tvmode" argument will enable this mode. Only difference will be that the player plays videos in black and white.
</details>

## Build info
Project type: Windows Forms App (C#)<br>
Target framework: .NET Framework 4.5.2<br>
LibVLCSharp version: 3.10.2<br>
VideoLAN LibVLC version: 3.0.24

## Donate
<a href='https://ko-fi.com/K3K81YHJE3' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://storage.ko-fi.com/cdn/kofi5.png?v=6' border='0' alt='Donate at my ko-fi page' /></a>
