// using System;
// using System.IO;
// using System.Text;
//
// namespace EnormousInputTest {
// 	class Program {
// 		private static readonly TextReader _in = Console.In;
// 		private static readonly TextWriter _out = Console.Out;
//
// 		static void Main(string[] args) {
// 			var config = _in.ReadLine().Split();
// 			var numberOfCases = int.Parse(config[0]);
// 			var divisible  = int.Parse(config[1]);
//
// 			var count = 0;
// 			for (int i = 0; i < numberOfCases; i++) {
// 				var number = int.Parse(_in.ReadLine());
// 				if (number % divisible == 0)
// 					count++;
// 			}
//
// 			_out.WriteLine(count);
// 		}
// 	}
// }