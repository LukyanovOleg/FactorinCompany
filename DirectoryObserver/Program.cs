using System;
using System.IO;
using System.Threading;
using DirectoryObserver.Extensions;
using DirectoryObserver.FileProcessor;
using DirectoryObserver.Strategy;

namespace DirectoryObserver
{
	class Program
	{
		static void Main(string[] args)
		{
			FileSystemWatcher watcher = new FileSystemWatcher();

			string fullPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

			string theDirectory = Path.GetDirectoryName(fullPath);


			watcher.Path = theDirectory + "\\ObsevableDirectory";

			watcher.Created += new FileSystemEventHandler(OnCreated);

			watcher.EnableRaisingEvents = true;

			Console.WriteLine("Press \'q\' to quit the sample.");
			while (Console.Read() != 'q') ;
		}

		private static void OnCreated(object source, FileSystemEventArgs e)
		{
			var fi = new FileInfo(e.FullPath);

			while (fi.IsFileLocked())
				Thread.Sleep(100);

			var processor = CommonFileProcessor.CreateInstance(e.FullPath);

			// если хотим влиять на поведение из клиента, то здесь, иначе в статический метод, возвращающий конструктор Processor
			if (processor is CssFileProcessor)
				processor.SetStrategy(new CssProcess());
			else if (processor is HtmlFileProcessor)
				processor.SetStrategy(new HtmlProcess());
			else
				processor.SetStrategy(new CommonProcess());

			processor.Process(e.FullPath);
		}
	}
}
