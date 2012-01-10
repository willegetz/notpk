using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ApprovalTests.Reporters;

namespace DdoItems
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class DenithReturningArrowTests
	{
		[TestMethod]
		public void TestDenithBolts()
		{
			var quantity = DenithBolts(1500);
			Approvals.Approve(quantity);
		}

		private string DenithBolts(double quantity)
		{
			var remainingBolts = new StringBuilder();
			var tmp = quantity;
			remainingBolts.AppendLine(quantity.ToString() + "\t\t" + tmp.ToString());

			var lastBolt = 1;

			do
			{
				quantity = Math.Floor(quantity * 0.75);
				tmp += quantity;
				remainingBolts.AppendLine(quantity.ToString() + "\t\t" + tmp.ToString());

			} while (quantity > lastBolt);

			return remainingBolts.ToString();
		}
	}
}
