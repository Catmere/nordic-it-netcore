using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using L13_C01_abstract_source.Interface;

namespace L13_C01_abstract_source.Device
{ 
	public abstract class MusicPlayer: IMusicPlayer
	{
		protected readonly ConsoleWriter ConsoleWriter;

		public string MusicSource { get; set; }

		public MusicPlayer(ConsoleWriter consoleWriter)
		{
			ConsoleWriter = consoleWriter;
		}

		public  virtual void PlayMusic()
		{
			if (string.IsNullOrEmpty(MusicSource))
			{
				ConsoleWriter.WriteLineWithYellow("It is nothing to play. Set the music source and try again.");
				return;
			}

			ConsoleWriter.WriteLineWithYellow($"Playing music from {MusicSource}");
		}
	}
}
