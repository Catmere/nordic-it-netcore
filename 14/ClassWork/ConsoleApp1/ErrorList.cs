using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class ErrorList : IDisposable, IEnumerable<string>
	{
		public static string OutputPrefixFormat { get; set; }
		
		public string Category { get; }
		private List<string> _errors;
		static ErrorList()
		{
			OutputPrefixFormat = "dd MMMM yyyy (hh:mm)";
		}
		public ErrorList(string category)
		{
			Category = category;
			_errors = new List<string>();
		}
		public void Add(string adder)
		{
			_errors.Add(adder);
		}
		public void Dispose()
		{
			_errors?.Clear();
			_errors = null;
		}
		public void WriteToConsole()
		{
			foreach (string error in _errors)
			{
				Console.WriteLine($"{DateTimeOffset.Now.ToString(OutputPrefixFormat)}\t{error}");
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			return _errors.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _errors.GetEnumerator();
		}
	}
}
