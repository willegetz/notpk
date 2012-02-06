using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class MaterialIngotTests
	{
		[TestMethod]
		public void TestGetMithralIngot()
		{
			var ingot = ItemTicket.GetMaterialIngot("Mithral");
			Approvals.Verify(LineItemDisplayUtilites.BasicIngotDisplay(ingot));
		}
	}
}
