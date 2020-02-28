using System;
using System.Collections.Generic;
using System.Linq;

namespace Slime.Standard {

    public static class RandomUtility {

		private static uint __counter;
		private static uint _seedCounter {
			get {
				try {
					__counter++;
				} catch {
					__counter = 0;
				}
				return __counter;
			}
		}

	    public static Random RANDOM {
			get {
				long seed = (DateTime.Now.GetHashCode() + _seedCounter);
				var random = new Random(seed.GetHashCode());
				return random;
			}
		}

		public static float Range(float from, float to) {
			float range = to - from;
			var value = (float)RANDOM.NextDouble() * range;

			return value + from;
		}

		public static float Range(int from, int to) {
			float range = to - from;
			var value = RANDOM.Next() * range;

			return (int)(value) + from;
		}

		public static string RandomString(int len = 1) {
		    string s = "";
		    for(int i = 0 ; i < len ; i++ ) {
			    s += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * RANDOM.NextDouble() + 65)));
		    }
		    return s;
	    }

	    public static string RandomString(int minLen, int maxlen) {
		    return RandomString(RANDOM.Next(minLen, maxlen));
	    }
	
	    private static DateTime _startDate = new DateTime(2000, 1, 1);

		public static bool RandomBool() {
			return Range(0.0f, 1.0f) < 0.5f;
		}

		public static DateTime RandomDateTime() {
		    return _startDate.AddDays( RANDOM.Next(0,(DateTime.Now - _startDate).Days))
			    .AddHours(RANDOM.Next(0, 24)).AddMinutes(RANDOM.Next(0, 60)).AddSeconds(RANDOM.Next(0,60));
	    }

	    public static DateTime RandomDateTime(DateTime startDate,int dayRange) {
		    return startDate.AddDays(RANDOM.Next(0, dayRange))
			    .AddHours(RANDOM.Next(0, 24)).AddMinutes(RANDOM.Next(0, 60)).AddSeconds(RANDOM.Next(0, 60));
	    }

        /// <summary>
        /// random one object in array
        /// </summary>
	    public static T Random<T>(this T[] array) {
		    if(array == null || array.Length <= 0 ) {
			    return default(T);
		    }
		    return array[RANDOM.Next(0, Math.Max(array.Length,0))];
	    }

		/// <summary>
		/// random one object in list
		/// </summary>
		public static T Random<T>(this List<T> array) {
			if (array == null || array.Count <= 0) {
				return default(T);
			}
			return array[RANDOM.Next(0, Math.Max(array.Count, 0))];
		}

		/// <summary>
		/// random one object
		/// </summary>
		public static T Random<T>(this IEnumerable<T> array) {
			return array.Random(1).ToArray().GetIndex(0);
		}

		/// <summary>
		/// get random object of List without order.
		/// </summary>
		/// <returns></returns>
		public static T[] Random<T>(int count, params T[] array) {
			return array.Random(count).ToArray();
	    }

		/// <summary>
		/// get random object without order.
		/// </summary>
		public static IEnumerable<T> Random<T>(this IEnumerable<T> array, int count) {
			return array.OrderBy(arr => RANDOM.Next(0, int.MaxValue)).Take(count);
		}

		/// <summary>
		/// get random object without order.
		/// </summary>
		public static T RandomEnumValue<T>() {
			var array = Enum.GetValues(typeof(T));
			return (T) array.GetValue(new Random().Next(array.Length));
		}
	}

}