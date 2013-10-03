﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SecureQuickResponseLogin
{
	public class SiteKey
	{
		private readonly byte[] _key;

		public SiteKey(MasterKey master, string site)
		{
			var encoding = new UTF8Encoding();
			byte[] buffer = encoding.GetBytes(site);

			using (var hmac = new HMACSHA512(master.Key.ToArray()))
				_key = hmac.ComputeHash(buffer);
		}

		public ReadOnlyCollection<byte> Key { get { return new ReadOnlyCollection<byte>(_key); } }
	}
}