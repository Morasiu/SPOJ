using System;
using System.Collections.Generic;
using System.Text;

namespace SmallestOnTheStack {
	class Program {

		static void Main(string[] args) {
			MinStack();
		}

		private static void MinStack() {
			var numberOfCases = int.Parse(Console.ReadLine());

			var stack = new Stack<int>();
			var minStack = new Stack<int>();
			var sb = new StringBuilder();

			for (int _ = 0; _ < numberOfCases; _++) {
				var input = Console.ReadLine();
				if (input == "MIN") {
					if (stack.Count == 0)
						sb.AppendLine("EMPTY");
					else {
						sb.AppendLine(minStack.Peek().ToString());
					}
				}
				else if (input == "POP") {
					if (stack.Count == 0)
						sb.AppendLine("EMPTY");
					else {
						if (stack.Pop() <= minStack.Peek()) {
							minStack.Pop();
						}
					}
				}
				else if (input.Length > 4) {
					var number = int.Parse(input.Substring(5));
					stack.Push(number);
					if (minStack.Count == 0 || number <= minStack.Peek()) {
						minStack.Push(number);
					}
				}
			}

			Console.WriteLine(sb.ToString());
		}
	}
}