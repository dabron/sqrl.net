using System;

namespace SecureQuickResponseLogin.Sample
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			var window = new MainWindow();
			window.ShowDialog();
		}
	}
}