using System;

namespace Slime.Standard {

	public abstract class UniqueBaseSystem<T> where T : new() {

		private static Lazy<T> lazy = new Lazy<T>(() => new T());

		public static T Instance {
			get {
				return lazy.Value;
			}
		}
		
	}

}