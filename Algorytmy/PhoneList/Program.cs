using System;

namespace PhoneList {
	class Program {
		static void Main(string[] args) {
			var numberOfTestCases = int.Parse(Console.ReadLine());

			for (int _ = 0; _ < numberOfTestCases; _++) {
				var cases = int.Parse(Console.ReadLine());
				var canRedirect = true;
				var trie = new Trie();

				for (int __ = 0; __ < cases; __++) {
					var number = Console.ReadLine();

					if (canRedirect) {
						if (trie.Search(number)) {
							canRedirect = false;
						}
						else {
							trie.Insert(number);
						}
					}
				}

				Console.WriteLine(canRedirect ? "YES" : "NO");
			}
		}
	}

	class Trie {
		private readonly Node _root;

		// Number 0-9
		private const int MaxSize = 10;


		public Trie() {
			_root = new Node();
		}

		public void Insert(string value) {
			InsertToTree(_root, value);
		}

		public bool Search(string value) {
			return Search(_root, value);
		}

		private bool Search(Node root, string value) {
			if (root.IsEnd) {
				return true;
			}

			if (value.Length == 0) {
				return true;
			}

			var index = value[0] -'0';

			if (root.Children[index] == null) {
				return false;
			}
			else {
				var child = root.Children[index];
				var remainedString = value.Substring(1);
				return Search(child, remainedString);
			}
		}

		private void InsertToTree(Node root, string value) {
			if (value.Length == 0) {
				root.IsEnd = true;
				return;
			}

			var index = value[0] -'0';

			var remainedString = value.Substring(1);
			if (root.Children[index] == null) {
				var child = new Node();
				root.Children[index] = child;
				InsertToTree(child, remainedString);
			}
			else {
				var child = root.Children[index];
				child.IsEnd = false;
				InsertToTree(child, remainedString);
			}
		}

		public class Node {
			public Node[] Children = new Node[MaxSize];

			public bool IsEnd { get; set; }
		}
	}
}