using System;
using ApprovalTests.Reporters;

namespace ItemSmithWorkShop.NCrunchUtilities
{
	public class NCrunchSilentReporter : DiffReporter
	{
		public NCrunchSilentReporter()
		{
			
		}
		public NCrunchSilentReporter(LaunchArgs defaultLauncher)
			: base(defaultLauncher)
		{
			
		}
		public override void Report(string approved, string received)
		{
			if (Environment.GetEnvironmentVariable("NCrunch") == "1")
			{
				return;
			}
			base.Report(approved, received);
		}
	}
}