using System;

namespace Slime.CSharp {

	public static class MathExtension {

		public static bool NearlyEqual(float a, float b, float epsilon = 0.0001f) {
			return NearlyEqual((double)a, (double)b, (double)epsilon);
		}

		public static bool NearlyEqual(double a, double b, double epsilon = 0.000001d) {
			double absA = Math.Abs(a);
			double absB = Math.Abs(b);
			double diff = Math.Abs(a - b);

			if (a == b) { // shortcut, handles infinities
				return true;
			} else if (a == 0 || b == 0 || absA + absB < epsilon) {
				// a or b is zero or both are extremely close to 0.00...1
				// relative error is less meaningful here
				return diff < epsilon;
			} else { // use relative error
				return diff < epsilon;
			}
		}
		
		/// <summary>
		/// number that % 2 == 0
		/// </summary>
		public static bool IsEven(this int value) {
			return value % 2 == 0;
		}

		/// <summary>
		/// number that % 2 == 0
		/// </summary>
		public static bool IsOdd(this int value) {
			return value % 2 != 0;
		}

	}

}
