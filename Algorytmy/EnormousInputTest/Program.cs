using System;
using System.IO;
using System.Text;

namespace EnormousInputTest {
	class Program {
		private static readonly Stream _in = Console.OpenStandardInput();
		private static readonly Stream _out = Console.OpenStandardOutput();

		private static readonly byte[] NewLine = Encoding.UTF8.GetBytes(Console.Out.NewLine);
		static void Main(string[] args) {
			var buffer = new Span<byte>();
			var config = _in.Read(buffer);
			WriteLine(buffer);
			// var numberOfCases = int.Parse(buffer);
			// var divisible  = int.Parse(config[1]);
			//
			// var count = 0;
			// for (int i = 0; i < numberOfCases; i++) {
			// 	var number = int.Parse(_in.ReadLine());
			// 	if (number % divisible == 0)
			// 		count++;
			// }
			//
			// _out.WriteLine(count);
		}

		private static void WriteLine(Span<byte> buffer) {
			var output = new byte[buffer.Length + NewLine.Length];
			Buffer.BlockCopy(buffer.ToArray(), 0, output, 0, buffer.Length);
			Buffer.BlockCopy(NewLine, 0, output, buffer.Length, NewLine.Length);
			_out.Write(output);
		}


	}
}