using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecureQuickResponseLogin.Tests
{
	[TestClass]
	public class SiteKeyTests
	{
		[TestMethod]
		public void Generated_key_bytes_differ()
		{
			var master = new MasterKey(new byte[64]);
			var site = new SiteKey(master, "www.example.com");
			var key = site.Key;
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
		public void Site_key_is_512_bits()
		{
			var master = new MasterKey(new byte[64]);
			var site = new SiteKey(master, "www.example.com");
			var key = site.Key;
			Assert.AreEqual(512, key.Count * 8);
		}

		[TestMethod]
		public void Site_key_matches_precomputed()
		{
			var master = new MasterKey(new byte[64]);

			var sites = new Dictionary<string, string>
			{
				{"www.example.com", "B0F66137BE2CFAE80012253C32D5E79388AE2869BA1F8EE27D2D740634C173C72317EB856ED3F6E47118403E02EECB4C88022C00F096922177F788AEF2C2602F"},
				{"www.grc.com", "173FD7DD4DD67485EC1001C12B223D978A201F3374A74F94E2A15F7AA10225A72C677A6A2E9F10C1D324E8A5FE91FBB5230F75B79310BB50012EBB1FAE79AC0E"},
				{"bronleewe.net", "72F7F038C85C1D5F0886F7634734B97A54A2D230FBA7E92EA9EFD06BAA6382B4D788E38A7D4C4D86AA5724B5FB05415AA19276B1808D74BC11A44369025DBBC4"}
			};

			foreach (var s in sites)
			{
				var site = new SiteKey(master, s.Key);
				string printedKey = Utility.BytesToHex(site.Key);
				Assert.AreEqual(s.Value, printedKey);
			}
		}
	}
}