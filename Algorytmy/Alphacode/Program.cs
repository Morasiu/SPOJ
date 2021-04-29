using System;
using SpojHelpers;

namespace Alphacode {
	/// <summary>
	/// https://www.spoj.com/problems/ACODE/
	/// </summary>
	class Program {
		static void Main(string[] args) {
#if DEBUG
			ConsoleHelper.ConfigForSpoj();
#endif
			Solution();
		}

		private static void Solution() {
			string line;
			do {
				line = Console.ReadLine();
				long numberOfPossibleDecodings = 1;
				int increaseCounter = 0;
				foreach (var number in line) {
					numberOfPossibleDecodings += increaseCounter;

					if (number == '1' || number == '2') {
						increaseCounter++;
					}
					else {
						increaseCounter = 0;
					}
				}

				Console.WriteLine(numberOfPossibleDecodings);
			} while (line != "0");
		}
	}
}