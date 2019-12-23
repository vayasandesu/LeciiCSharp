using System;
using System.Collections.Generic;

namespace Slime.CSharp {

	public static class DictionaryExtension {

		/// <summary>
		/// get value from collection
		/// if key not exist, will add the initialize value to colllection and return that value
		/// </summary>
		public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> collection, TKey key, TValue initialValue) {
			if (!collection.ContainsKey(key)) {
				collection.Add(key, initialValue);
			}

			return collection[key];
		}

		/// <summary>
		/// Get value in collection.
		/// if key not exist will return default value without change the collection.
		/// </summary>
		/// <param name="defualtValue">return this value if key not exist</param>
		public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> collection, TKey key, TValue defualtValue) {
			TValue value;
			if(!collection.TryGetValue(key, out value)) {
				return defualtValue;
			} else {
				return value;
			}
		}

		/// <summary>
		/// add or replace new value.
		/// </summary>
		/// <param name="useNew">if is false and value are exist. not replace the value</param>
		public static void Replace<TKey, TValue>(this Dictionary<TKey, TValue> collection, TKey key, TValue value, bool useNew = true) {
			if (collection == null)
				return;

			if (!collection.ContainsKey(key)) {
				collection.Add(key, value);
			} else {
				if(useNew)
					collection[key] = value;
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
