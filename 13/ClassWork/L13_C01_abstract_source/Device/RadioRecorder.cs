using System;
using L13_C01_abstract_source.Interface;

namespace L13_C01_abstract_source.Device
{
	public class RadioRecorder: MusicPlayer, IRestartable
	{
		public string RecordingDestination { get; set; }

		public RadioRecorder(ConsoleWriter consoleWriter): base(consoleWriter)
		{
			ConsoleWriter.WriteLineWithCyan("Starting work with Radio Recorder");
		}

		public void RecordMusic(TimeSpan duration)
		{
			if (string.IsNullOrEmpty(RecordingDestination))
			{
				ConsoleWriter.WriteLine(
					"The destination is empty. Set the recording destination and try again.");
				return;
			}

			if (string.IsNullOrEmpty(MusicSource))
			{
				ConsoleWriter.WriteLine(
					"It is nothing to play. Set the music source and try again.");
				return;
			}

			ConsoleWriter.WriteLine(
				$"Recording {duration.TotalSeconds} seconds from {MusicSource} to {RecordingDestination}");
		}

		public void Restart()
		{
			ConsoleWriter.WriteLineWithCyan("Restarting Radio Recorder... Power Off > Power On.");
		}
	}
}
