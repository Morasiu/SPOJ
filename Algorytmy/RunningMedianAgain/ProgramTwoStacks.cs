using System;
using System.Collections.Generic;
using System.Text;

namespace RunningMedianAgain {
	// TLE
	class ProgramTwoStacks {
		private static void TwoStack() {
			var minStack = new Stack<int>();
			var maxStack = new Stack<int>();
			string input;
			var sb = new StringBuilder();
			var numberOfCases = int.Parse(Console.ReadLine());
			for (int _ = 0; _ < numberOfCases; _++) {
				do {
					input = Console.ReadLine();
					var num = int.Parse(input);
					if (num == -1) {
						sb.AppendLine(minStack.Pop().ToString());
						if (minStack.Count < maxStack.Count)
							minStack.Push(maxStack.Pop());
					} 
					else if (num == 0) {
						break;
					}
					else if (num > 0) {
						if (minStack.Count == 0) {
							minStack.Push(num);
						}
						else if (maxStack.Count == 0) {
							if (num <= minStack.Peek()) {
								maxStack.Push(minStack.Pop());
								minStack.Push(num);
							}
							else {
								maxStack.Push(num);
							}
						}
						else {
							if (num <= minStack.Peek()) {
								var minStackCount = minStack.Count;
								for (int i = 0; i < minStackCount; i++) {
									if (num >= minStack.Peek()) {
										break;
									}
									maxStack.Push(minStack.Pop());

								}
								minStack.Push(num);
							}
							else {
								var maxStackCount = maxStack.Count;
								for (int i = 0; i < maxStackCount; i++) {
									if (num < maxStack.Peek()) {
										break;
									}
									minStack.Push(maxStack.Pop());
								}
								maxStack.Push(num);
							}
							Divide(ref minStack, ref maxStack);
						}
					}
				} while (input != "0");
				
				sb.AppendLine();
				minStack.Clear();
				maxStack.Clear();

			}
			Console.Write(sb.ToString());
		}

		private static void Divide(ref Stack<int> min, ref Stack<int> max) {
			while (max.Count > min.Count) {
				min.Push(max.Pop());
			}

			if (min.Count + max.Count % 2 == 0) {

				while (min.Count  > max.Count) {
					max.Push(min.Pop());
				}
			}
			else {
				while (min.Count -1 > max.Count) {
					max.Push(min.Pop());
				}
			}
		}
	}
}