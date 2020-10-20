using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecii.Pool {

	public class Pool<T> : IPool<T> {

		/// <summary>
		/// Free use entity
		/// </summary>
		public int Count => _collection.Count;

		/// <summary>
		/// Limit amount of free use entity
		/// </summary>
		public int Max { get; private set; }

		private HashSet<T> _collection;
		private Func<T> _onCreate;

		public Pool(Func<T> creation, int max = int.MaxValue) {
			_onCreate = creation;
			_collection = new HashSet<T>();
			Max = max;
		}

		public void Return(T entity) {
			if(_collection.Count < Max && !_collection.Contains(entity))
				_collection.Add(entity);
		}

		public T Get() {
			if(_collection.Count > 0) {
				var item = _collection.First();
				_collection.Remove(item);
				return item;
			} else {
				var item = _onCreate.Invoke();
				return item;
			}
		}

	}

}
