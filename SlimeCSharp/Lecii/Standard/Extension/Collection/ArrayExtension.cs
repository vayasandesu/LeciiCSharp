using System;

namespace Lecii.Standard {

	public static class ArrayExtension {

        /// <summary>
        /// Get Object from array provoid error exception by 
        /// - null array (return null)
        /// - index out of bound (return null)
        /// </summary>
        public static T GetIndex<T>(this T[] array, int index) {
            if (array == null) {
                return default(T);
            }

            if (index >= 0 && index <= array.Length - 1) {
                return array[index];
            }
            return default(T);
        }
		
        public static T Find<T>(this T[] array, Func<T,bool> predicate) {
            if(array.IsEmptyOrNull()) {
                return default(T);
            }
            int len = array.Length;
            for(int i = 0; i<len; i++) {
                var obj = array.GetIndex(i);
                if (predicate.Invoke(obj)) {
                    return obj;
                }
            }

            return default(T);
        }

        public static bool IsEmptyOrNull<T>(this T[] array) {
            return array == null || array.Length <= 0;
        }

		/// <summary>
		/// iterator by index not foreach
		/// </summary>
		public static void ForEach<T>(this T[] array, Action<T> action) {
			int len = array.Length;
			T obj;
			for (int i = 0; i < len; i++) {
				try {
					obj = array[i];
					action?.Invoke(obj);
				}catch(IndexOutOfRangeException e) {
					throw e;
				}
			}
		}

		/// <summary>
		/// return new concat array.
		/// </summary>
		public static T[] Concat<T>(this T[] first, params T[] second) {
			int aLen = first?.Length ?? 0;
			int bLen = second?.Length ?? 0;
			int len = aLen + bLen;

			int index = 0;
			var concat = new T[len];

			if (first != null) {
				for (int i = 0; i < aLen; i++) {
					concat[index] = first[i];
					index++;
				}
			}

			if(second != null) {
				for (int i = 0; i < bLen; i++) {
					concat[index] = second[i];
					index++;
				}
			}

			return concat;
		}

    }
}
