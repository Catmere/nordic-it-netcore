using System;
using System.Collections.Generic;
using System.Text;

namespace L13_C01_abstract_source.Interface
{
	interface IMusicPlayer
	{
		string MusicSource { get; set; }

		void PlayMusic();
	}
}
