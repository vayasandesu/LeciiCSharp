using System;
using System.Collections.Generic;

namespace Lecii.Collection {

	public static class DictionaryExtension {

		/// <summary>
		/// Get value if value exist, otherwise return defult value of type
		/// </summary>
		/// <returns></returns>
		public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> data, TKey key) {
			if(data.ContainsKey(key))
				return data[key];
			else
				return default(TValue);
		}

		/// <summary>
		/// If Key doesn't exist then add data to collection.
		/// otherwise do nothing.
		/// </summary>
		/// <returns>true when data have added</returns>
		public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> data, TKey key, TValue value) {
			if(!data.ContainsKey(key)) {
				data.Add(key, value);
				return true;
			}

			return false;
		}
		
		/// <summary>
		/// Write data to collection either data exist or not
		/// </summary>
		/// <param name="useNew">if is false and value are exist. not replace the value</param>
		/// <returns>true if it overwrite value</returns>
		public static bool Overwrite<TKey, TValue>(this Dictionary<TKey, TValue> collection, TKey key, TValue value) {

			if (!collection.ContainsKey(key)) {
				collection.Add(key, value);
				return false;
			} else {
				collection[key] = value;
				return true;
			}

		}

		public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> source) {
			var dic = new Dictionary<TKey, TValue>();
			foreach(var data in source) {
				dic.Add(data.Key, data.Value);
			}

			return dic;
		}

		public static Dictionary<TKey, TValue> DeepClone<TKey, TValue>(this Dictionary<TKey, TValue> source) where TValue : ICloneable {
			var dic = new Dictionary<TKey, TValue>();
			foreach (var data in source) {
				var value = (TValue)((ICloneable)data.Value).Clone();
				dic.Add(data.Key, value);
			}

			return dic;
		}

	}
}
