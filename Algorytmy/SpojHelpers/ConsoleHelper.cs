using System;
using System.IO;

namespace SpojHelpers {
	public static class ConsoleHelper {
		public static void RedirectInput() {
			FileInfo sourceFile = new FileInfo("Data.txt");
			TextReader sourceFileReader = new StreamReader(sourceFile.FullName);
			Console.SetIn(sourceFileReader);
		}

		public static void TestOutput() => Console.SetOut(new TestWriter());

		public static void ConfigForSpoj() {
			RedirectInput();
			TestOutput();
		}
	}
}