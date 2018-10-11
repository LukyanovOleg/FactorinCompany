using System;
using System.IO;
using System.Linq;

namespace DirectoryObserver.Strategy
{
	public class CssProcess : IProcessStrategy
	{
		public void Process(string fullFileName)
		{
			string text = File.ReadAllText(fullFileName);

			var leftBracketCount = text.Count(l => l == '{');
			var rightBracketCount = text.Count(l => l == '}');

			var result = leftBracketCount == rightBracketCount;

			var resultString = result ? "Да" : "Нет";

			var fileInfo = new FileInfo(fullFileName);

			Console.WriteLine($"<{fileInfo.Name}>-<количество открывающих скобок “{{“ совпадает с количеством закрывающих скобок “}}”>-<{resultString}>");
		}
	}
}
