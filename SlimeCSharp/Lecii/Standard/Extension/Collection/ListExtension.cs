using System;
using System.Collections.Generic;

namespace Lecii.Collection {

    public static class ListExtension {
		
		/// <summary>
		/// add duplicate of value to list
		/// </summary>
		/// <param name="value">instance</param>
		/// <param name="copy">amount of instance</param>
		public static void Add<T>(this List<T> list, T value, int copy) where T : struct {
			for(int i = 0; i < copy; i++) {
				list.Add(value);
			}
		}

		/// <summary>
		/// remove first object in list
		/// </summary>
		/// <returns></returns>
		public static bool RemoveFirst<T>(this List<T> list, Predicate<T> predicate) {
			if (predicate == null) {
				return false;
			}

			foreach(var obj in list) {
				if(predicate.Invoke(obj)) {
					list.Remove(obj);
					return true;
				}
			}

			return false;
		}
		
	}
	
}