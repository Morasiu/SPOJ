using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace Euler {
	public class Euler16 {
		public static void Do() {
			var stopwatch = Stopwatch.StartNew();
			int result = BigInteger.Pow(2, 1000).ToString().Sum(a => int.Parse(a.ToString()));

			stopwatch.Stop();
			Console.WriteLine(result);
			Console.WriteLine(stopwatch.Elapsed);
		}
	}
}