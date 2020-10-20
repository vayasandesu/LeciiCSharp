using NUnit.Framework;

namespace Lecii.Algorithm.Knapsack {

	public class KnapsackSolutionTest {

		[TestCaseSource("_cases")]
		public void Pick(KnapsackCase testcase) {
			var expect = testcase.Best;
			var solution = new KnapsackSolution();
			var best = solution.Pick(testcase.Capacity, testcase.Items);
			Assert.AreEqual(expect, best.Value);
		}

		private static KnapsackCase[] _cases = new KnapsackCase[] {
			_case1, _case2, _case3//, _case4, _case5
		};

		private static KnapsackCase _case1 => new KnapsackCase {
			Capacity = 4, Best = 3,
			//Pick one witch non max capacity
			Items = new KnapsackItem[] {
				new KnapsackItem(1, 4),
				new KnapsackItem(2, 5),
				new KnapsackItem(3, 1),
			}
		};

		private static KnapsackCase _case2 => new KnapsackCase {
			Capacity = 3, Best = 0,
			//Pick nothing
			Items = new KnapsackItem[] {
				new KnapsackItem(1, 4),
				new KnapsackItem(2, 5),
				new KnapsackItem(3, 6),
			}
		};

		private static KnapsackCase _case3 => new KnapsackCase {
			Capacity = 3, Best = 6,
			// pick all
			Items = new KnapsackItem[] {
				new KnapsackItem(2, 1),
				new KnapsackItem(2, 1),
				new KnapsackItem(2, 1),
			}
		};

		private static KnapsackCase _case4 => new KnapsackCase {
			Capacity = 3, Best = 4,
			Items = new KnapsackItem[] {
				new KnapsackItem(4, 3),
				new KnapsackItem(1, 1),
				new KnapsackItem(1, 1),
			}
		};

		private static KnapsackCase _case5 => new KnapsackCase {
			Capacity = 2, Best = 3,
			Items = new KnapsackItem[] {
				new KnapsackItem(2, 1),
				new KnapsackItem(1, 1),
				new KnapsackItem(1, 1),
			}
		};


		public class KnapsackCase {
			public decimal Capacity;
			public KnapsackItem[] Items;
			public decimal Best;
		}

		public class KnapsackItem: IKnapsackItem {
			public decimal Value { get; set; }
			public decimal Weight { get; set; }

			public KnapsackItem(decimal value, decimal weight) {
				Value = value;
				Weight = weight;
			}
		}

	}
}