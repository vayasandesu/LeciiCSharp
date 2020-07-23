using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecii.Algorithm.Knapsack {

	public interface IKnapsackResult {
		decimal Value { get; }
		decimal Weight { get; }
		HashSet<IKnapsackItem> Items { get; }
	}

	public class KnapsackResult : ICloneable {
		/// <summary>
		/// Total value got
		/// </summary>
		public decimal Value => Items.Sum(o => o.Value);

		/// <summary>
		/// Total weight used
		/// </summary>
		public decimal Weight => Items.Sum(o => o.Weight);

		/// <summary>
		/// Best item picked
		/// </summary>
		public HashSet<IKnapsackItem> Items { get; private set; }

		public KnapsackResult() {
			Items = new HashSet<IKnapsackItem>();
		}

		public object Clone() {
			return new KnapsackResult {
				Items = new HashSet<IKnapsackItem>(Items)
			};
		}

	}

}
