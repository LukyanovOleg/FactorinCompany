using System.IO;
using DirectoryObserver.Strategy;

namespace DirectoryObserver.FileProcessor
{
	public class CommonFileProcessor
	{
		protected IProcessStrategy _strategy;

		public static CommonFileProcessor CreateInstance(string filename)
		{
			FileInfo fi = new FileInfo(filename);
			switch (fi.Extension.ToUpper())
			{
				case ".HTML":
					return new HtmlFileProcessor();

				case ".CSS":
					return new CssFileProcessor();
					
					// add new subclass this 

				default:
					return new CommonFileProcessor();
			}

		}

		public void SetStrategy(IProcessStrategy strategy)
		{
			_strategy = strategy;
		}

		public void Process(string fullFileName)
		{
			_strategy.Process(fullFileName);
		}
	}
}
