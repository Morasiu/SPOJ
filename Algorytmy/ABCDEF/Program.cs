using System;

namespace ABCDEF {
	class Program {
		static void Main(string[] args) {
			var size = int.Parse(Console.ReadLine());
			
			var dataset = new int[size];
			for (int i = 0; i < size; i++) {
				dataset[i] = int.Parse(Console.ReadLine());
			}

			int result = 0;

			for (var index = 0; index < dataset.Length; index++) {
				var a = dataset[index];
				foreach (var b in dataset) {
					foreach (var c in dataset) {
						foreach (var d in dataset) {
							if (d == 0) {
								continue;
							}

							foreach (var e in dataset) {
								foreach (var f in dataset) {
									if (a * b + c == (f + e) * d) {
										result++;
									}
								}
							}
						}
					}
				}
			}

			Console.WriteLine(result.ToString());
		}
	}
}