using System;
using System.Diagnostics;
using System.Numerics;

namespace Euler {
	public class Euler15 {
		public static void Do() {
			/*
			 * 2x2 = 6
			 * 3x3 = 20
			 * d = down
			 * r = right
			 */
			var s = Stopwatch.StartNew();

			int grid = 20;
			int n = grid + grid;
			int k = grid;
			var factorialN = Factorial(n);
			var factorialK = Factorial(k);
			var factorialNk = Factorial(n - k);
			var routesCount = factorialN / (factorialK * factorialNk);

			
			s.Stop();
			Console.WriteLine("OLD");
			Console.WriteLine(routesCount);
			Console.WriteLine(s.Elapsed);
		}

		private static BigInteger Factorial(BigInteger f) {
			BigInteger result = 1;
			for (int i = 1; i <= f; i++) {
				result *= i;
			}

			return result;
		}


		public static void DoFast() {
			var s = Stopwatch.StartNew();
			int grid = 20;

			BigInteger factorial = 1;
			BigInteger factorialN = 0;
			BigInteger factorialK = 0;
			BigInteger factorialNk = 0;


			for (int i = 1; i <= grid + grid; i++) {
				factorial *= i;
				if (i == 20) {
					factorialNk = factorial;
					factorialK = factorial;
				}

				if (i == 40) {
					factorialN = factorial;
				}
			}

			var routesCount = factorialN / (factorialK * factorialNk);

			s.Stop();
			Console.WriteLine("FAST");
			Console.WriteLine(routesCount);
			Console.WriteLine(s.Elapsed);
		}
	}
}