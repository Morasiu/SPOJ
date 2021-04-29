using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningMedianAgain {
	class Program {
		static void Main(string[] args) {
			MinMaxHeap();
		}

		private static void MinMaxHeap() {

			var numberOfCases = int.Parse(Console.ReadLine());
			var sb = new StringBuilder();
			string input;
			for (int _ = 0; _ < numberOfCases; _++) {
				var minHeap = new MinHeap(1_000_000);
				var maxHeap = new MaxHeap(1_000_000);
				do {
					input = Console.ReadLine();
					var num = int.Parse(input);
					if (num == -1) {
						sb.AppendLine(maxHeap.Pop().ToString());
						if (maxHeap.Count < minHeap.Count)
							maxHeap.Add(minHeap.Pop());
					} 
					else if (num == 0) {
						break;
					}
					else if (num > 0) {
						if (maxHeap.Count == 0) {
							maxHeap.Add(num);
						}
						else if (minHeap.Count == 0) {
							if (num <= maxHeap.Peek()) {
								minHeap.Add(maxHeap.Pop());
								maxHeap.Add(num);
							}
							else {
								minHeap.Add(num);
							}
						}
						else {
							if (num <= maxHeap.Peek()) {
								maxHeap.Add(num);
								if (maxHeap.Count > minHeap.Count + 1)
									minHeap.Add(maxHeap.Pop());
							}
							else {
								minHeap.Add(num);
								if (minHeap.Count > maxHeap.Count)
									maxHeap.Add(minHeap.Pop());
							}
						}
					}
				} while (input != "0");
				
				sb.AppendLine();
			}

			Console.Write(sb.ToString());
		}
	}

	public class MinHeap {
		private readonly int[] _elements;
		public int Count;

		public MinHeap(int size) {
			_elements = new int[size];
		}

		private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
		private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
		private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

		private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < Count;
		private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < Count;
		private bool IsRoot(int elementIndex) => elementIndex == 0;

		private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
		private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
		private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

		private void Swap(int firstIndex, int secondIndex) {
			var temp = _elements[firstIndex];
			_elements[firstIndex] = _elements[secondIndex];
			_elements[secondIndex] = temp;
		}

		public bool IsEmpty() {
			return Count == 0;
		}

		public int Peek() {
			if (Count == 0)
				throw new IndexOutOfRangeException();

			return _elements[0];
		}

		public int Pop() {
			if (Count == 0)
				throw new IndexOutOfRangeException();

			var result = _elements[0];
			_elements[0] = _elements[Count - 1];
			Count--;

			ReCalculateDown();

			return result;
		}

		public void Add(int element) {
			if (Count == _elements.Length)
				throw new IndexOutOfRangeException();

			_elements[Count] = element;
			Count++;

			ReCalculateUp();
		}

		private void ReCalculateDown() {
			int index = 0;
			while (HasLeftChild(index)) {
				var smallerIndex = GetLeftChildIndex(index);
				if (HasRightChild(index) && GetRightChild(index) < GetLeftChild(index)) {
					smallerIndex = GetRightChildIndex(index);
				}

				if (_elements[smallerIndex] >= _elements[index]) {
					break;
				}

				Swap(smallerIndex, index);
				index = smallerIndex;
			}
		}

		private void ReCalculateUp() {
			var index = Count - 1;
			while (!IsRoot(index) && _elements[index] < GetParent(index)) {
				var parentIndex = GetParentIndex(index);
				Swap(parentIndex, index);
				index = parentIndex;
			}
		}
	}

	public class MaxHeap {
		private readonly int[] _elements;
		public int Count;

		public MaxHeap(int size) {
			_elements = new int[size];
		}

		private int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
		private int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;
		private int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

		private bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < Count;
		private bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < Count;
		private bool IsRoot(int elementIndex) => elementIndex == 0;

		private int GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];
		private int GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];
		private int GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

		private void Swap(int firstIndex, int secondIndex) {
			var temp = _elements[firstIndex];
			_elements[firstIndex] = _elements[secondIndex];
			_elements[secondIndex] = temp;
		}

		public bool IsEmpty() {
			return Count == 0;
		}

		public int Peek() {
			if (Count == 0)
				throw new IndexOutOfRangeException();

			return _elements[0];
		}

		public int Pop() {
			if (Count == 0)
				throw new IndexOutOfRangeException();

			var result = _elements[0];
			_elements[0] = _elements[Count - 1];
			Count--;

			ReCalculateDown();

			return result;
		}

		public void Add(int element) {
			if (Count == _elements.Length)
				throw new IndexOutOfRangeException();

			_elements[Count] = element;
			Count++;

			ReCalculateUp();
		}

		private void ReCalculateDown() {
			int index = 0;
			while (HasLeftChild(index)) {
				var biggerIndex = GetLeftChildIndex(index);
				if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index)) {
					biggerIndex = GetRightChildIndex(index);
				}

				if (_elements[biggerIndex] < _elements[index]) {
					break;
				}

				Swap(biggerIndex, index);
				index = biggerIndex;
			}
		}

		private void ReCalculateUp() {
			var index = Count - 1;
			while (!IsRoot(index) && _elements[index] > GetParent(index)) {
				var parentIndex = GetParentIndex(index);
				Swap(parentIndex, index);
				index = parentIndex;
			}
		}
	}
}