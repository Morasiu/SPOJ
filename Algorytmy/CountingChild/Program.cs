using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountingChild {
	class Program {
		static void Main(string[] args) {
			var numberOfCases = int.Parse(Console.ReadLine());

			var sb = new StringBuilder();
			for (int i = 0; i < numberOfCases; i++) {
				var n = int.Parse(Console.ReadLine());
				var treeString = Console.ReadLine().Replace(" ", "");
				var tree = new BinaryTree();
				tree.CreateTree(treeString.Substring(1, treeString.Length - 1), tree.Root);

				sb.AppendLine($"Case {i + 1}:");

				foreach (var pair in tree.Counter) {
					sb.AppendLine($"{pair.Key} -> {pair.Value}");
				}

				sb.AppendLine();
			}

			Console.Write(sb.ToString());
		}
	}

	public class BinaryTree {
		public Dictionary<int, int> Counter = new Dictionary<int, int>();
		public Node Root = new Node(null, 1);

		public Node CreateTree(string treeString, Node root) {
			// 1 2 4 4 2 3 5 5 6 6 3 1

			if (treeString.Length == 0) {
				if (!Counter.ContainsKey(1)) {
					Counter.Add(1, 0);
				}
				return root;

			}

			if (treeString[0] == '1') {
				if (!Counter.ContainsKey(1)) {
					Counter.Add(1, 0);
				}
				Counter = Counter.OrderBy(k => k.Key)
					.ToDictionary(pair => pair.Key, pair => pair.Value);
				return root;
			}

			var value = int.Parse(treeString[0].ToString());

			if (value != root.Value) {
				var node = new Node(root, value);
				if (root.Left == null) {
					root.Left = node;
				}
				else {
					root.Right = node;
				}

				Counter[root.Value] = GetNodeChildNumber(root);
				return CreateTree(treeString.Substring(1, treeString.Length - 1), node).Root;
			}
			else {
				Counter[root.Value] = GetNodeChildNumber(root);
				return CreateTree(treeString.Substring(1, treeString.Length - 1), root.Root).Root;
			}
		}

		private static int GetNodeChildNumber(Node node) {
			var nodeChildNumber = 0;
			if (node.Left != null)
				nodeChildNumber++;

			if (node.Right != null)
				nodeChildNumber++;
			return nodeChildNumber;
		}

	}

	public class Node {
		public Node(Node root, int value) {
			if (root == null)
				root = this;
			Value = value;
			Root = root;
		}

		public Node Root { get; private set; }
		public int Value { get; private set; }
		public Node Right { get; set; }
		public Node Left { get; set; }
	}
}