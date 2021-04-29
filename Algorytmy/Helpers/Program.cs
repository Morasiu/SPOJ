using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers {
	class Program {
		static void Main(string[] args) {
			int number = 0;
			int i = 1;
			int numberOfFactors;
			do {
				number += i;
				i++;
				numberOfFactors = GetNumberOfPrimeFactors(number);
			} while (numberOfFactors < 500);

			Console.WriteLine($"{number}: {numberOfFactors}");
		}

		private static int GetNumberOfPrimeFactors(int number) {
			int numberOfFactors = 1;
			var primeFactors = new List<int>();

			do {
				for (int i = 2; i <= number; i++) {
					if (number % i == 0) {
						primeFactors.Add(i);
						number = number / i;
						break;
					}
				}
			} while (number > 1);

			var grouped = primeFactors.GroupBy(i => i).Select(i => new { i.Key, Count = i.Count() + 1 });

			foreach (var g in grouped) {
				numberOfFactors *= g.Count;
			}

			return numberOfFactors;
		}
	}
}