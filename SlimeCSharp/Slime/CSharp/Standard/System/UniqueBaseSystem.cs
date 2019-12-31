using System;

namespace Slime.Standard {

	/// <summary>
	/// For create singelton instance when need to use
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class UniqueBaseSystem<T> where T : new() {

		private static Lazy<T> lazy = new Lazy<T>(() => new T());

		public static T Instance {
			get {
				return lazy.Value;
			}
		}
		
	}

}