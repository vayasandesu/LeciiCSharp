using System;
using System.Collections.Generic;

namespace Lecii.Standard {

	/// <summary>
	/// group of Island.
	/// collect the same type of value
	/// but need to seperate section(key)
	/// </summary>
	/// <typeparam name="TKey">Set of type data</typeparam>
	/// <typeparam name="TValue">pool type</typeparam>
	public class IslandGroup<TKey, TValue> {

		public delegate TValue CreationalDelegate(TKey key);

		private Dictionary<TKey, Island<TValue>> _pools;

		private CreationalDelegate _createBlueprint;

		public IslandGroup(CreationalDelegate creation) {
			_pools = new Dictionary<TKey, Island<TValue>>();
			_createBlueprint = creation;
		}

		private Island<TValue> GetPool(TKey key) {
			if(!_pools.ContainsKey(key)) {
				_pools.Add(key, new Island<TValue>(() => _createBlueprint(key)));
			}

			return _pools[key];
		}

		public TValue GetValue(TKey key) {
			return GetPool(key).GetObject();
		}

		public void Release(TKey key, TValue value, Action<TValue> onRelease = null) {
			GetPool(key).Retire(value, onRelease);
		}

		public void ReleaseAll(TKey key, Action<TValue> onRelease = null) {
			GetPool(key).RetireAll(onRelease);
		}

	}

}
