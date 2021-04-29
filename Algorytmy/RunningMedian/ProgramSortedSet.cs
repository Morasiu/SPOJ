using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningMedian {
	class ProgramSortedSet {
		// static void Main(string[] args) {
			// SortedSet();
		// }

		private static void SortedSet() {
			var numbers = new HashSet<int>();
			string input;
			var sb = new StringBuilder();
			do {
				input = Console.ReadLine();
				// END OF FILE
				if (input == null || input == "eof") break;
				// 0
				if (input == "0") {
					Console.ReadLine();
					sb.AppendLine();
					numbers.Clear();
					continue;
				}

				var num = int.Parse(input);
				if (num == -1) {
					var median = numbers.ElementAt((numbers.Count - 1) / 2);
					sb.AppendLine(median.ToString());
					numbers.Remove(median);
				}
				else {
					numbers.Add(num);
				}
			} while (true);

			Console.Write(sb.ToString());
		}
	}
}