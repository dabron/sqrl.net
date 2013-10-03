using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace SecureQuickResponseLogin
{
	public class MasterKey
	{
		private const int BitLength = 512;
		private const int ByteLength = BitLength / 8;
		private readonly byte[] _key;

		public MasterKey(byte[] key)
		{
			if (key.Length != ByteLength)
				throw new ArgumentException(BitLength + " bits expected for master key.", "key");

			_key = key;
		}

		public ReadOnlyCollection<byte> Key { get { return new ReadOnlyCollection<byte>(_key); } }

		public static MasterKey Generate()
		{
			byte[] key = new byte[ByteLength];

			using (var rng = RandomNumberGenerator.Create())
				rng.GetBytes(key);

			return new MasterKey(key);
		}
	}
}