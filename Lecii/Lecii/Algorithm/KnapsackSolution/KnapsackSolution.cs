using Lecii.Algorithm.Knapsack;

namespace Lecii.Algorithm {
	public class KnapsackSolution {

		private KnapsackResult best;

		public KnapsackSolution() { }

		public KnapsackResult Pick(decimal max, params IKnapsackItem[] items) {
			best = new KnapsackResult();
			Pick(max, items, 0, new KnapsackResult());
			return best;
		}


		private void Pick(decimal max, IKnapsackItem[] items, int index, KnapsackResult current) {

			if(current.Weight >= max)
				return;

			// picked weight > result and lower value than result.
			if(index >= items.Length && current.Weight <= max) {
				if(current.Value > best.Value) {
					best = current.Clone() as KnapsackResult;
				} else if(current.Value == best.Value
					&& current.Weight < best.Weight) {
					best = current.Clone() as KnapsackResult;
				}

				return;
			}

			//Pick
			current.Items.Add(items[index]);
			Pick(max, items, index + 1, current);

			//Not pick
			current.Items.Remove(items[index]);
			Pick(max, items, index + 1, current);
		}

	}
}
