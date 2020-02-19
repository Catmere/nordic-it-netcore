﻿using L13_C06_interface.Interface;
using System;

namespace L13_C06_interface.Device
{
	public class RadioRecorder : AbstractMusicPlayer, IMusicRecorder, IMusicPlayer, IRestartable
	{
		public RadioRecorder(ConsoleWriter writer) : base(writer)
		{
			_writer.WriteLineWithCyan("Starting work with Radio Recorder");
		}

		public string RecordingDestination { get; set; }

		public void RecordMusic(TimeSpan duration)
		{
			if (string.IsNullOrEmpty(RecordingDestination))
			{
				_writer.WriteLine(
					"The destination is empty. Set the recording destination and try again.");
				return;
			}

			if (string.IsNullOrEmpty(MusicSource))
			{
				_writer.WriteLine(
					"It is nothing to play. Set the music source and try again.");
				return;
			}

			_writer.WriteLine(
				$"Recording {duration.TotalSeconds} seconds from {MusicSource} to {RecordingDestination}");
		}

		public override void Restart()
		{
			_writer.WriteLineWithCyan("Restarting Radio Recorder... Power Off > Power On.");
		}
	}
}