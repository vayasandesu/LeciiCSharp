using System;
using System.Collections.Generic;

namespace Lecii {

	public static class CollectionExtension {
		
		[Obsolete("Use Generator.Generate() instead")]
		public static T[] GenerateObjects<T>(int count, Func<T> creationFunction) {
			var list = new T[count];

			for(int i = 0; i < count; i++) {
				var obj = creationFunction.Invoke();
				list[i] = obj;
			}

			return list;
		}
		
		public static Tout Map<Tin, Tout>(this Tin data, Func<Tin, Tout> convertFunction) {
			return convertFunction(data);
		}

		/// <summary>
		/// Convert object from type Tin to Tout type
		/// </summary>
		/// <param name="data">original data</param>
		/// <param name="mapFunction"></param>
		/// <param name="excludeNull">if it true, null object not appear in result data</param>
		/// <returns></returns>
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
