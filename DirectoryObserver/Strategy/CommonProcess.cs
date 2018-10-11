using System;
using System.IO;
using System.Linq;

namespace DirectoryObserver.Strategy
{
	public class CommonProcess : IProcessStrategy
	{
		public void Process(string fullFileName)
		{
			string text = File.ReadAllText(fullFileName);

			var textWithoutPuntual = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

			var result = text.Length - textWithoutPuntual.Length;

			var fileInfo = new FileInfo(fullFileName);

			Console.WriteLine($"<{fileInfo.Name}>-<количество знаков препинания>-<{result}>");
		}
	}
}
