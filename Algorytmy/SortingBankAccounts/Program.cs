using System;
using System.Linq;

namespace SortingBankAccounts {
	class Program {
		static void Main(string[] args) {
			var numberOfTestCases = int.Parse(Console.ReadLine());
			var testCases = new string[numberOfTestCases][];
			
			for (int i = 0; i < numberOfTestCases; i++) {
				var numberOfAccounts = int.Parse(Console.ReadLine());
				var testCase = new string[numberOfAccounts];
				for (int j = 0; j < numberOfAccounts; j++) {
					testCase[j] = Console.ReadLine();
				}
				testCases[i] = testCase;
				Console.ReadLine();
			}

			foreach (var testCase in testCases) {

				var result = testCase
					.GroupBy(s => s)
					.OrderBy(s => s.Key)
					.Select(grouping => $"{grouping.Key} {grouping.Count()}");


				foreach (var c in result) {
					Console.WriteLine(c);
				}
				Console.WriteLine();
			}
		}
	}
}
