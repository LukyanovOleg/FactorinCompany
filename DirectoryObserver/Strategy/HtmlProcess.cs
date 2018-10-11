using System;
using System.IO;
using System.Linq;
using HtmlAgilityPack;

namespace DirectoryObserver.Strategy
{
	public class HtmlProcess : IProcessStrategy
	{
		public void Process(string fullFileName)
		{
			HtmlDocument doc = new HtmlDocument();
			doc.Load(fullFileName, false);

			int divCount = doc.DocumentNode.Descendants("div").Count();

			var fileInfo = new FileInfo(fullFileName);

			Console.WriteLine($"<{fileInfo.Name}>-<количество тегов div>-<{divCount}>");
		}	
	}
}
