using System;
using System.Collections.Generic;

namespace Lecii.Collection {

	public static class EnumerableExtension {
		
		/// <summary>
		/// looping to find object at index
		/// </summary>
		public static T At<T>(this IEnumerable<T> data, int index) {
			if (data == null)
				return default(T);

			int i = 0;
			foreach (var e in data) {
				if (i == index)
					return e;
				i++;
			}

			return default(T);
		}

		/// <summary>
		/// get first index of object that equal predicate
		/// </summary>
		public static int IndexOf<T>(this IEnumerable<T> data, Predicate<T> predicate) {
			
			if (predicate == null) {
				return -1;
			}

			int index = -1;
			foreach (var obj in data) {
				index++;
				if (predicate.Invoke(obj)) {
					return index;
				}
			}

			return -1;
		}

		/// <summary>
		/// get first object that equal predicate
		/// </summary>
		public static IEnumerable<T> FindAll<T>(this IEnumerable<T> dataset, Predicate<T> predicate) {

			var list = new List<T>();

			if (predicate == null || dataset == null) {
				return list;
			}

			foreach (var obj in dataset) {
				if (predicate.Invoke(obj)) {
					list.Add(obj);
				}
			}

			return list;

		}
		
		public static void ForEach<T>(this IEnumerable<T> data, Action<T> action) {
			foreach(T d in data) {
				action.Invoke(d);
			}
		}

	}

}