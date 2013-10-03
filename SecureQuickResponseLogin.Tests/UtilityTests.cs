using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecureQuickResponseLogin.Tests
{
	[TestClass]
	public class UtilityTests
	{
		[TestMethod]
		public void BytesToHex_handles_null()
		{
			string hex = Utility.BytesToHex(null);
			Assert.AreEqual(string.Empty, hex);
		}

		[TestMethod]
		public void BytesToHex_handles_empty()
		{
			string hex = Utility.BytesToHex(new byte[0]);
			Assert.AreEqual(string.Empty, hex);
		}

		[TestMethod]
		public void BytesToHex_propery_converts_bytes()
		{
			string hex = Utility.BytesToHex(new byte[] {0x00, 0x01, 0x80, 0xff});
			Assert.AreEqual("000180FF", hex);
		}
	}
}