using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;

namespace HotelsAlongtheCroatianCoast {
	class Program {
		static void Main(string[] args) {
			// var config = Console.ReadLine();
			// var m = int.Parse(config.Split()[1]);
			// var numbers = Array.ConvertAll(Console.ReadLine().Split(), input => int.Parse(input));
			// var m = 12;
			// var numbers = new[] { 2, 1, 3, 4, 5 };
			var m = 9;
			var numbers = new[] { 7, 3, 5, 6 };
			Array.Sort(numbers);
			int sum = 0;
			for (int max = m; max > 0; max--) {
				for (int i = numbers.Length - 1; i >= 0; i--) {
					if (sum + numbers[i] == max) {
						Console.WriteLine(sum + numbers[i]);
						return;
					}
					else if (sum + numbers[i] < max) {
						sum += numbers[i];
					}
				}
			}
		}
	}

}