//namespace Slime.Algorithm {
//	public class Item: ICloneable {
//		public string ID;
//		public decimal Weight;
//		public decimal Value;

//		public object Clone() {
//			return new Item {
//				ID = this.ID,
//				Weight = this.Weight,
//				Value = this.Value
//			};
//		}
//	}

//	public class KnacpsackResult: ICloneable {
//		public decimal Weight {
//			get {
//				decimal final = 0;
//				foreach(var w in Items) {
//					final += w.Weight;
//				}
//				return final;
//			}
//		}

//		public decimal Value {
//			get {
//				decimal final = 0;
//				foreach(var w in Items) {
//					final += w.Value;
//				}
//				return final;
//			}
//		}

//		public HashSet<Item> Items;

//		public KnacpsackResult() {
//			Items = new HashSet<Item>();
//		}

//		public object Clone() {
//			return new KnacpsackResult {
//				Items = new HashSet<Item>(Items)
//			};
//		}
//	}

//	public class KnapsackSolution {

//		private KnacpsackResult best;

//		public Knapsack() {}

//		public KnacpsackResult GetBest(decimal max, Item[] items) {
//			best = new KnacpsackResult();
//			Pick(max, items, 0, new KnacpsackResult {
//				Items = new HashSet<Item>()
//			});
//			return best;
//		}


//		private void Pick(decimal max, Item[] items, int index, KnacpsackResult current) {

//			if(current.Weight >= max)
//				return;

//			// picked weight > result and lower value than result.
//			if(index >= items.Length && current.Weight <= max) {
//				if(current.Value > best.Value) {
//					best = current.Clone() as KnacpsackResult;
//				} else if(current.Value == best.Value
//					&& current.Weight < best.Weight) {
//					best = current.Clone() as KnacpsackResult;
//				}

//				return;
//			}

//			//Pick
//			current.Items.Add(items[index]);
//			Pick(max, items, index + 1, current);

//			//Not pick
//			current.Items.Remove(items[index]);
//			Pick(max, items, index + 1, current);
//		}

//	}
//}
