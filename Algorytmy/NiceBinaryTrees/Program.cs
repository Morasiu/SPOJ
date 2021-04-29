using System;
using System.Linq;
using System.Text;

namespace NiceBinaryTrees {
	public class Program {
		public static void Main(string[] args) {
			var numberOfCases = int.Parse(Console.ReadLine());
			var sb = new StringBuilder();
			for (int _ = 0; _ < numberOfCases; _++) {
				
				var s = Console.ReadLine();
				var tree = new BinaryTree();
				foreach (var letter in s) {
					if (letter == 'l') {
						tree.AddLeaf();
					}
					else {
						tree.AddNode();
					}

				}
				sb.AppendLine(tree.MaxDepth(tree.Root).ToString());
			}

			Console.Write(sb.ToString());
		}
	}


	public class BinaryTree {
		public Node Root;
		private Node _freeNode;

		public int MaxDepth(Node node) {
			if (Root == null)
				return 0;

			if (node.Left == null) {
				return 0;
			}
			int leftDepth = MaxDepth(node.Left);
			int rightDepth = MaxDepth(node.Right);


			if (leftDepth > rightDepth) {
				return(leftDepth + 1);
			}
			else {
				return rightDepth + 1;
			}
		}

		public void AddLeaf() {
			if (Root == null) {
				Root = new Node(null, 0);
				return;
			}

			if (_freeNode.Left == null) {
				_freeNode.Left = new Node(_freeNode, _freeNode.Value + 1);
			}
			else {
				_freeNode.Right = new Node(_freeNode, _freeNode.Value + 1);
				Node nextFreeNode = _freeNode;
				do {
					nextFreeNode = nextFreeNode.Root;
					if (nextFreeNode == Root)
						break;
				} while (nextFreeNode.Right != null);

				_freeNode = nextFreeNode;
			}
		}

		public void AddNode() {
			if (Root == null) {
				Root = new Node(null, 0);
				_freeNode = Root;
				return;
			}

			if (_freeNode.Left == null) {
				_freeNode.Left = new Node(_freeNode, _freeNode.Value + 1);
				_freeNode = _freeNode.Left;
			}
			else {
				_freeNode.Right = new Node(_freeNode, _freeNode.Value + 1);
				_freeNode = _freeNode.Right;
			}
		}
	}
	
	public class Node {
		public Node(Node root, int value) {
			if (root == null)
				root = this;
			Value = value;
			Root = root;
		}

		public Node Root { get; set; }
		public int Value { get; private set; }
		public Node Right { get; set; }
		public Node Left { get; set; }
	}
}