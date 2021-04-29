using System;
using System.Diagnostics;

namespace SocNetC {
	class Program {
		static void Main(string[] args) {
			Console.Write("Podaj liczbę obiektów N: "); // np. N=100_000
			int N = int.Parse(Console.ReadLine());

			Console.Write("Podaj liczbę zapytań losowych M: "); // np. M=100_000
			int M = int.Parse(Console.ReadLine());

			// przygotowanie zbioru testowego, par `p`, `q`
			int[,] testData = new int[M, 2];
			var rnd = new Random();
			for (int i = 0; i < M; i++) {
				testData[i, 0] = rnd.Next(N); // p: 0..N-1
				testData[i, 1] = rnd.Next(N); // q: 0..N-1
			}

			Console.WriteLine("Dane testowe przygotowane");

			// rozwiązanie z DisjointSet1 naiwne
			Stopwatch t1 = Stopwatch.StartNew();
			var ds1 = new DisjointSet1(N);
			for (int i = 0; i < M; i++) {
				int p = testData[i, 0];
				int q = testData[i, 1];

				if (!ds1.Find(p, q)) // wywołanie Find
					ds1.Union(p, q); // wywołanie Union
			}

			t1.Stop();
			var t1ms = t1.Elapsed;
			Console.WriteLine("Czas dla rozwiązania naiwnego: " + t1.Elapsed);

			// rozwiązanie z DisjointSet z wagami i kompresją ścieżki
			Stopwatch t2 = Stopwatch.StartNew();
			var ds2 = new DisjointSet(N);
			for (int i = 0; i < M; i++) {
				int p = testData[i, 0];
				int q = testData[i, 1];

				if (!ds2.AreInSameSet(p, q)) // wywołanie Find
					ds2.Union(p, q); // wywołanie Union
			}

			t2.Stop();
			Console.WriteLine("Czas dla rozwiązania z wagami i kompresją ścieżki: " + t2.Elapsed);
		}
	}

	// implementacja tablicowa, wykorzystująca wagi i kompresję ścieżki
	public class DisjointSet {
		private int[] parent; //odwołanie do przodka
		private int[] size; //rozmiar drzewa reprezentującego zbiór

		public int Size => parent.Length;

		// konstruktor (nie ma konstruktora domyślnego)
		public DisjointSet(int N) {
			parent = new int[N];
			size = new int[N];
			for (int i = 0; i < N; i++) {
				parent[i] = i;
				size[i] = 1;
			}

			NumberOfSubsets = N;
		}

		// Zwraca indeks reprezentanta zbioru, do którego należy element o indeksie `index`
		public int Find(int index) => root(index);

		private int root(int i) {
			while (i != parent[i]) {
				parent[i] = parent[parent[i]];
				i = parent[i];
			}

			return i;
		}

		public bool AreInSameSet(int index1, int index2) => root(index1) == root(index2);

		public void Union(int index1, int index2) {
			int i = root(index1), j = root(index2);

			if (i == j) // należą do tego samego zbioru
				return;

			if (size[i] < size[j]) {
				parent[i] = j;
				size[j] += size[i];
			}
			else {
				parent[j] = i;
				size[i] += size[j];
			}

			NumberOfSubsets--;
		}

		// ---- metody dodatkowe, spoza interfejsu

		// Zwraca rozmiar zbioru, do którego należy element o indeksie `index`
		public int SizeOfSubset(int index) => size[root(index)];

		public int NumberOfSubsets { get; private set; }
	}

	class DisjointSet1 {
		private int[] id;

		public DisjointSet1(int N) {
			id = new int[N];
			for (int i = 0; i < N; i++)
				id[i] = i;
		}

		public bool Find(int p, int q) => id[p] == id[q];

		public void Union(int p, int q) {
			int temp = id[p];
			for (int i = 0; i < id.Length; i++)
				if (id[i] == temp)
					id[i] = id[q];
		}
	}
}