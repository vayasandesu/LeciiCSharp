using System;
using System.Security.Cryptography;
using System.Text;

namespace Slime.Standard {

	public static class EncryptExtension {

		public static string ToSHA256(this string value) {
			if (value.Equals(null)) {
				value = "";
			}

			StringBuilder Sb = new StringBuilder();

			using (SHA256 hash = SHA256Managed.Create()) {
				Encoding enc = Encoding.UTF8;
				Byte[] result = hash.ComputeHash(enc.GetBytes(value));

				foreach (Byte b in result)
					Sb.Append(b.ToString("x2"));
			}

			return Sb.ToString();
		}

	}

}