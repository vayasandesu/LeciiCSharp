using System;
using System.Collections.Generic;

namespace Lecii {

	public struct RandomItem<TObject> {
		public TObject Obj;
		public float Chance;
	}

	public class RandomCollection<T> {

		private List<RandomItem<T>> _pools;
		private float _totalChance;

		public RandomCollection() {
			_pools = new List<RandomItem<T>>();
			_totalChance = 0.0f;
		}

		public RandomCollection(IEnumerable<RandomItem<T>> items) : base() {
			Add(items);
		}

		public void Add(IEnumerable<RandomItem<T>> items) {
			foreach(var item in items) {
				Add(item);
			}
		}

		public void Add(RandomItem<T> item) {
			_pools.Add(item);
			_totalChance += item.Chance;
		}

		private void Remove(RandomItem<T> item) {
			_pools.Remove(item);
			_totalChance -= item.Chance;
		}

		/// <summary>
		/// </summary>
		/// <returns>quantity of remove collection</returns>
		public int Remove(Predicate<RandomItem<T>> predicate) {
			int count = 0;

			foreach(var collection in _pools) {
				if (predicate.Invoke(collection)) {
					Remove(collection);
					count++;
				}
			}

			return count;
		}

		public T Random() {
			float totalRate = _totalChance;
			var weight = Randomizer.Range(0.0f, totalRate);

			if (_pools.Count <= 0)
				return default(T);

			T defualtItem = _pools[0].Obj;

			foreach (var item in _pools) {
				if (weight < item.Chance) {
					//Debug.Log($"Random {weight}/{totalRate} with {_pools.Count} and got {_pools.IndexOf(item)}");
					return item.Obj;
				}
				weight -= item.Chance;
			}
			//Debug.Log($"Random {weight}/{totalRate} with {_pools.Count} and got default");
			return defualtItem;

		}

	}
}
