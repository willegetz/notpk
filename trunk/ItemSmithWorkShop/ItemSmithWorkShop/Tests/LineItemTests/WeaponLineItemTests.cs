using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class WeaponLineItemTests
	{
		[TestMethod]
		public void TestGetWeaponItem()
		{
			var weapon = ItemTicket.GetWeaponTicket("Dagger");
			Approvals.Approve(LineItemDisplayUtilites.BasicDisplay(weapon));
		}
	}
}
