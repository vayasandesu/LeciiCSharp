using System;
using System.Collections.Generic;

namespace Slime.Standard {

	/// <summary>
	/// Create an instance of object which hasn't exist.
	/// like Lazy (C#).
	/// </summary>
	public class CacheTable<TKey, TValue> {
		
		private Dictionary<TKey, TValue> _cached;
		private CreationEventHandler<TKey, TValue> _createFunction;

		public CacheTable(CreationEventHandler<TKey, TValue> creational) {
			if (creational == null)
				throw new NullReferenceException("delegate get value cannot be null");

			_createFunction = creational;
			_cached = new Dictionary<TKey, TValue>();
		}

		public TValue Get(TKey key) {
			if (!_cached.ContainsKey(key)) {
				_cached.Add(key, _createFunction.Invoke(key));
			}

			return _cached[key];
		}

		public IEnumerable<TValue> AsEnumerable() {
			foreach(var obj in _cached) {
				yield return obj.Value;
			}
		}

	}

}
