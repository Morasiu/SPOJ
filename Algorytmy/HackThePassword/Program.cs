using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HackThePassword {
	class Program {
		static void Main(string[] args) {
			// FileInfo sourceFile = new FileInfo("Data.txt");
			// TextReader sourceFileReader = new StreamReader(sourceFile.FullName);
			// Console.SetIn(sourceFileReader);
			
			CharSequenceSolution();
		}


		private static void CharSequenceSolution() {
			var numberOfCases = int.Parse(Console.ReadLine());

			for (int inputIndex = 0; inputIndex < numberOfCases; inputIndex++) {
				var testCase = Console.ReadLine();
				var sequence = new CharSequence(testCase.Length);

				for (int i = 0; i < testCase.Length; i++) {
					var key = testCase[i];
					if (key == '<') {
						sequence.MoveLeft();
					}
					else if (key == '>') {
						sequence.MoveRight();
					}
					else if (key == '-') {
						sequence.Remove();
					}
					else {
						sequence.Add(key);
					}
				}

				Console.WriteLine(sequence.ToString());
			}
		}

		class CharSequence {
			private char[] _leftPart;
			private int _leftSize;
			private char[] _rightPart;
			private int _rightSize;
			
			public CharSequence(int size) {
				_leftPart = new char[size];
				_rightPart = new char[size];
			}

			public void Add(char c) {
				_leftPart[_leftSize++] = c;
			}

			public void Remove() {
				if (_leftSize > 0) {
					_leftPart[_leftSize--] = default(char);
				}
			}

			public void MoveLeft() {
				if (_leftSize > 0) {
					_leftSize--;
					_rightPart[_rightSize] = _leftPart[_leftSize];
					_leftPart[_leftSize] = default(char);
					_rightSize++;
				}
			}

			public void MoveRight() {
				if (_rightSize > 0) {
					_rightSize--;
					_leftPart[_leftSize] = _rightPart[_rightSize];
					_rightPart[_rightSize] = default(char);
					_leftSize++;
				}
			}

			public override string ToString() {
				var sb = new StringBuilder();

				sb.Append(_leftPart, 0, _leftSize);

				for (int i = _rightSize - 1; i >= 0; i--) {
					sb.Append(_rightPart[i]);
				}

				return sb.ToString();
			}
		}
		
		
		private static void LinkedListSolution() {
			var numberOfCases = int.Parse(Console.ReadLine());
			var sb = new StringBuilder();
			for (int inputIndex = 0; inputIndex < numberOfCases; inputIndex++) {
				var testCase = Console.ReadLine();
				var linkedList = new LinkedList<char>();

				LinkedListNode<char> node = null;
				for (int i = 0; i < testCase.Length; i++) {
					var key = testCase[i];
					
					if (key == '<') {
						node = node?.Previous;
					}
					else if (key == '>') {
						if (node != null)
							node = node.Next ?? linkedList.Last;
						else {
							node = linkedList.First;
						}
					}
					else if (key == '-') {
						if (node != null) {
							var previous = node.Previous;
							linkedList.Remove(node);
							node = previous;
						}
					}
					else {
						if (node == null)
							node = linkedList.AddFirst(key);
						else
							node = linkedList.AddAfter(node, key);
					}
				}

				var format = new string(linkedList.ToArray());
				sb.AppendLine(format);
			}

			Console.WriteLine(sb);
		}

		private static void StackSolution() {
			var numberOfCases = int.Parse(Console.ReadLine());
			for (int inputIndex = 0; inputIndex < numberOfCases; inputIndex++) {
				var testCase = Console.ReadLine();
				var stack = new Stack<char>(testCase.Length);
				var movedLetters = new Stack<char>(testCase.Length);

				for (int i = 0; i < testCase.Length; i++) {
					var key = testCase[i];
					if (key == '<') {
						if (stack.Count > 0)
							movedLetters.Push(stack.Pop());
					}
					else if (key == '>') {
						if (movedLetters.Count > 0)
							stack.Push(movedLetters.Pop());
					}
					else if (key == '-') {
						if (stack.Count > 0)
							stack.Pop();
					}
					else {
						stack.Push(key);
					}
				}
				
				Console.WriteLine(new string(stack.Reverse().ToArray()) + new string(movedLetters.ToArray()));
			}
		}
	}
}