using System;

namespace Slime.Standard {

	public static class ObjectExtension {

		/// <summary>
		/// Do action if object not null
		/// </summary>
		public static void NotNullThen<T>(this T obj, Action<T> doThis) {
			if(obj != null) {
				doThis?.Invoke(obj);
			}
		}

		/// <summary>
		/// do action if object is not null.
		/// will return defualt of Type if cannot do the action.
		/// </summary>
		public static Tout NotNullThen<T,Tout>(this T obj, Func<T,Tout> doThis) {
			if (obj != null) {
				doThis?.Invoke(obj);
			}
			return default(Tout);
		}



	}
}