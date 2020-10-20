using System;

namespace Lecii {
	
	public static class Generator {

		/// <summary>
		/// Generate array of value
		/// </summary>
		/// <param name="size">size</param>
		/// <param name="Creation">instantiate function</param>
		/// <returns></returns>
		public static TValue[] Generate<TValue>(int n, Func<TValue> Creation) {
			TValue[] array = new TValue[n];
			for(int i = 0; i < n; i++) {
				array[i] = Creation();
			}
			return array;
		}

		/// <summary>
		/// Generate array of value
		/// </summary>
		/// <param name="size">size</param>
		/// <param name="Creation">instantiate function with index</param>
		/// <returns></returns>
		public static TValue[] Generate<TValue>(int size, Func<int, TValue> Creation) {
			TValue[] array = new TValue[size];
			for(int i = 0; i < size; i++) {
				array[i] = Creation(i);
			}
			return array;
		}

	}

}