using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningMedian {
	class Program {
		static void Main(string[] args) {
			StackAndQueue();
		}

		private static void StackAndQueue() {
			var stack = new Stack<int>();
			var queue = new Queue<int>();
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
					queue.Clear();
					stack.Clear();
					continue;
				}

				var num = int.Parse(input);
				if (num == -1) {
					sb.AppendLine(stack.Pop().ToString());

					// POP
					if (stack.Count < queue.Count) {
						stack.Push(queue.Dequeue());
					}
				}
				else {
					if (queue.Count > 0) {
						if (queue.Count == stack.Count)
							stack.Push(queue.Dequeue());
						queue.Enqueue(num);
					}
					else if (stack.Count == 0) {
						stack.Push(num);
					} else if (stack.Count == 1) {
						queue.Enqueue(num);
					}
				}
			} while (true);

			Console.Write(sb.ToString());
		}
	}
}