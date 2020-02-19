using System;
using L13_C01_abstract_source.Interface;

namespace L13_C01_abstract_source.Device
{
	public class MobilePhone: MusicPlayer, IPhone, IRestartable
	{
		public MobilePhone(ConsoleWriter consoleWriter): base(consoleWriter)
		{
			ConsoleWriter.WriteLineWithCyan("Starting work with Mobile Phone");
		}

		public void Call(string phoneNumber)
		{
			ConsoleWriter.WriteLine($"Calling {phoneNumber}...");
		}

		public void Restart()
		{
			ConsoleWriter.WriteLineWithCyan("Restarting Mobile Phone... Displaying splash screen while loading.");
		}
	}
}
