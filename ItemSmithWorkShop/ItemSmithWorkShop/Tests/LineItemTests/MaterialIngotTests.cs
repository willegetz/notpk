using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class MaterialIngotTests
	{
		[TestMethod]
		public void TestGetMithralIngot()
		{
			var ingot = ItemTicket.GetMaterialIngot("Mithral");
			Approvals.Approve(ingot);
		}
	}
}
