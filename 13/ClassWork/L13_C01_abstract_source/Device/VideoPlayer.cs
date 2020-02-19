using System;
using L13_C01_abstract_source.Interface;

namespace L13_C01_abstract_source.Device
{
	public class VideoPlayer: MusicPlayer, IRestartable
	{
		public string VideoSource { get; set; }

		public VideoPlayer(ConsoleWriter consoleWriter): base(consoleWriter)
		{
			ConsoleWriter.WriteLineWithCyan("Starting work with Video Player");
		}

		public void PlayVideo()
		{
			if (string.IsNullOrEmpty(VideoSource))
			{
				ConsoleWriter.WriteLine("It is nothing to play. Set the video source and try again.");
				return;
			}

			ConsoleWriter.WriteLine($"Playing video from {VideoSource}");
		}

		public void Restart()
		{
			ConsoleWriter.WriteLineWithCyan("Restarting Video Player... Please wait about 10 seconds.");
		}
	}
}
