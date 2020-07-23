using System;
using System.Collections.Generic;

namespace Lecii.Standard {

	public static class CollectionExtension {
		
		public static List<T> GenerateObjects<T>(int count, Func<T> creationFunction) {
			var list = new List<T>();
			while(list.Count < count) {
				var obj = creationFunction.Invoke();
				list.Add(obj);
			}
			return list;
		}
		
		public static Tout Map<Tin, Tout>(this Tin data, Func<Tin, Tout> convertFunction) {
			return convertFunction(data);
		}

		public static IEnumerable<Tout> Map<Tin,Tout>(
			this IEnumerable<Tin> data, 
			Func<Tin, Tout> mapFunction, bool excludeNull = false
		) {
			Tout result;
			foreach(var obj in data) {
				result = mapFunction(obj);
				if(excludeNull && result == null)
					continue;
				else
					yield return mapFunction(obj);
			}
		}

	}

}
