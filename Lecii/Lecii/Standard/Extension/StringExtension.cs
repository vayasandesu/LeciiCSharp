using System;
using System.IO;

namespace Lecii.Standard {

	public static class StringExtension {

        /// <summary>
        /// return empty string or string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeNull(this string value) {
            if (value == null) {
                return "";
            }
            return value;
        }

		/// <summary>
		/// Convert number to format
		/// 1..100
		/// 1.0K...99.9K
		/// 100K...999K
		/// 1M...X,XXX.XM
		/// </summary>
		public static string ShortNumber(this float value) {
			var absValue = Math.Abs(value);

			if (absValue < 1000) { //1-1000
				return ((int)value).ToString("##0");
			} else if (absValue < 100000) { //1K-99.9K
				value = (int)(value*10) / 1000;
				return (value / 10f).ToString("#0.0") + "K";

			} else if (absValue < 1000000) { //100K-999K
				value = (int)(value*10) / 10000;
				return (value).ToString("#0") + "K";
			} else if( absValue < 100000000) {//1.0M-99.9M
				value = (int)(value / 100000);
				return (value / 10f).ToString("#0.#") + "M";
			} else {//100M+
				return ((int)value/1000000).ToString("#,##0") + "M";
			}

		}

		/// <summary>
		/// Convert number to format
		/// 1..100
		/// 1.0K...99.9K
		/// 100K...999K
		/// 1M...
		/// </summary>
		public static string ShortNumber(this int value) {
			return (value * 1.0f).ShortNumber();
		}

		/// <summary>
		/// check file is extension
		/// eg .jpg , .txt , .mp4 or any with .
		/// </summary>
		/// <param name="text"></param>
		/// <param name="extensionName">.jpg</param>
		/// <returns></returns>
		public static bool IsExtensionName(this string text, string extensionName) {
			return Path.GetExtension(text).Equals(extensionName);
		}

    }

}

