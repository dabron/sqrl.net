using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecureQuickResponseLogin.Tests
{
	[TestClass]
	public class MasterKeyTests
	{
		[TestMethod]
		public void Generated_key_bytes_differ()
		{
			var master = MasterKey.Generate();
			var key = master.Key;
			bool differ = false;

			for (int i = 0; i < key.Count; ++i)
			{
				for (int j = i + 1; j < key.Count; ++j)
				{
					if (key[i] != key[j])
					{
						differ = true;
						break;
					}
				}

				if (differ)
					break;
			}

			Assert.IsTrue(differ);
		}

		[TestMethod]
		public void Generated_key_is_512_bits()
		{
			var master = MasterKey.Generate();
			var key = master.Key;
			Assert.AreEqual(key.Count * 8, 512);
		}
	}
}