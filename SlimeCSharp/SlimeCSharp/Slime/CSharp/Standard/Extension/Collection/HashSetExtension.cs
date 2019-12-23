using System.Collections.Generic;
using System.Linq;

namespace Slime.Standard {
	public static class HashSetExtension {
		
		/// <summary>
		/// convert to hashset
		/// </summary>
		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> obj) {
			var set = new HashSet<T>();
			foreach (var e in obj) {
				if(!set.Contains(e))
					set.Add(e);
			}
			return set;
		}

		/// <summary>
		/// add or replace value to hash
		/// </summary>
		/// <returns>true if value exist and replaced, false if value are add only</returns>
		public static bool Replace<T>(this HashSet<T> hash, T value) {
			if (hash.Contains(value)) {
				hash.Remove(value);
				hash.Add(value);
				return true;
			}

			hash.Add(value);
			return false;
		}

		/// <summary>
		/// add unique value to data set.
		/// </summary>
		public static void Add<T>(this HashSet<T> data, IEnumerable<T> values) {
			foreach(var e  in values) {
				if(!data.Contains(e))
					data.Add(e);
			}
		}

		/// <summary>
		/// </summary>
		/// <param name="data">source data</param>
		/// <param name="values">object that want to check</param>
		/// <returns>true if has one of any value in data source</returns>
		public static bool HasAnyOf<T>(this HashSet<T> data, params T[] values) {
			return data.HasAnyOf(values.AsEnumerable());
		}

		/// <summary>
		/// </summary>
		/// <param name="data">source data</param>
		/// <param name="values">object that want to check</param>
		/// <returns>true if has one of any value in data source</returns>
		public static bool HasAnyOf<T>(this HashSet<T> data, IEnumerable<T> values) {
			if (data == null)
				return false;

			foreach (var v in values) {
				if (data.Contains(v))
					return true;
			}
			return false;
		}

		/// <summary>
		/// </summary>
		/// <param name="data">source data</param>
		/// <param name="values">object that want to check</param>
		/// <returns>true if has all of Value in Data source</returns>
		public static bool HasAllOf<T>(this HashSet<T> data, params T[] values) {
			return data.HasAllOf(values.AsEnumerable());
		}

		/// <summary>
		/// </summary>
		/// <param name="data">source data</param>
		/// <param name="values">object that want to check</param>
		/// <returns>true if has all of Value in Data source</returns>
		public static bool HasAllOf<T>(this HashSet<T> data, IEnumerable<T> values) {
			if (data == null)
				return false;

			foreach (var v in values) {
				if (!data.Contains(v))
					return false;
			}
			return true;
		}
		
	}
}
