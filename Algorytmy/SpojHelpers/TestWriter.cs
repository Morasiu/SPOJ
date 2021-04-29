using System;
using System.IO;
using System.Text;

namespace SpojHelpers {
	public class TestWriter : TextWriter {
		private readonly TextReader _testReader;
		private readonly TextWriter _consoleWriter;
		private StringBuilder _sb = new StringBuilder();
		public TestWriter() {
			FileInfo sourceFile = new FileInfo("Output.txt");
			_testReader = new StreamReader(sourceFile.FullName);
			_consoleWriter = Console.Out;
			
		}
		
		public override Encoding Encoding => Encoding.UTF8;
		private void WriteTestResult(string value) {
			Console.SetOut(this);
			string valueWithTest;
			var testData = _testReader.ReadLine();

			if (testData == value.TrimEnd()) valueWithTest = $"==OK== {value}";
			else valueWithTest = $"==!!== {value}";

			_consoleWriter.Write(valueWithTest);
		}

		public override void Write(char[] buffer, int index, int count) {
			_sb.Append(buffer, index, count);
			bool isNewLine = true;

			for (int i = 0; i < CoreNewLine.Length; i++) {
				var newLinePosition = _sb.Length - (CoreNewLine.Length - i);
				
				if (newLinePosition < 0 || newLinePosition > _sb.Length || _sb[newLinePosition] != CoreNewLine[i]) {
					isNewLine = false;
					break;
				}
			}

			if (isNewLine) {
				WriteTestResult(_sb.ToString());
				_sb.Clear();
			}
		}

		protected override void Dispose(bool disposing) {
			Console.SetOut(_consoleWriter);
			_testReader.Dispose();
		}
	}
}