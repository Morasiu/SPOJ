using System;
using System.Text;

namespace SabbirAndGame {
	class Program {
		static void Main(string[] args) {
			var sb = new StringBuilder();
			var numberOfCases = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfCases; i++) {
				Console.ReadLine();
				var numbers = Array.ConvertAll(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
				long life = 0;
				long startLife = 0;
				for (int j = 0; j < numbers.Length; j++) {
					var number = numbers[j];
					life += number;
					if (life < 1) {
						var abs = Math.Abs(life) + 1;
						startLife += abs;
						life += abs;
					}
				}

				sb.AppendLine(startLife.ToString());
			}

			Console.WriteLine(sb.ToString());
		}
	}
}