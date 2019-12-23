using System;
using System.Collections.Generic;

namespace Slime.Standard {

    public static class ListExtension {
		
	    /// <summary>
	    /// Get Object from array provoid error exception by 
	    /// - null array (return null)
	    /// - index out of bound (return null)
	    /// </summary>
	    public static T GetIndex<T>(this List<T> array, int index) {
		    if( array == null ) {
			    return default(T);
		    }

		    if( index >= 0 && index <= array.Count - 1 ) {
			    return array[index];
		    }
		    return default(T);
	    }
		
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