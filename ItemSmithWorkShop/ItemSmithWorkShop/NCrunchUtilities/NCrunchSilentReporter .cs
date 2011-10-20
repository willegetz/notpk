using System;

namespace TestingUtilities
{
	public class NCrunchSilentReporter : ApprovalTests.Reporters.DiffReporter
	{
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