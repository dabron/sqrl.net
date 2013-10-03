using System.Collections.Generic;
using System.Text;

namespace SecureQuickResponseLogin
{
	public static class Utility
	{
		public static string BytesToHex(IEnumerable<byte> bytes)
		{
			var sb = new StringBuilder();

			if (bytes != null)
			{
				foreach (byte b in bytes)
					sb.Append(b.ToString("X2"));
			}

			return sb.ToString();
		}
	}
}