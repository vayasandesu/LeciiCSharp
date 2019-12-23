using System;
using System.Collections.Generic;

namespace Slime.Standard {

	public static class EnumerableExtension {
		
		/// <summary>
		/// looping to find object at index
		/// </summary>
		public static T GetIndex<T>(this IEnumerable<T> data, int index) {
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
		public static int IndexOf<T>(this IEnumerable<T> dataset, Predicate<T> predicate) {
			
			if (predicate == null) {
				return -1;
			}

			int index = -1;
			foreach (var obj in dataset) {
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
		public static T Find<T>(this IEnumerable<T> dataset, Predicate<T> predicate) {
			if (predicate == null) {
				return default(T);
			}
			
			foreach (var obj in dataset) {
				if (predicate.Invoke(obj)) {
					return obj;
				}
			}

			return default(T);

		}

		/// <summary>
		/// get first object that equal predicate
		/// </summary>
		public static List<T> FindAll<T>(this IEnumerable<T> dataset, Predicate<T> predicate) {

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



	}

}