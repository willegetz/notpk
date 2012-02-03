using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;


namespace ItemSmithWorkShop.Tests.LineItemTests
{
	[TestClass]
	public class WeaponLineItemTests
	{
		[TestMethod]
		public void TestGetWeaponItem()
		{
			var weapon = ItemTicket.WeaponTicket("Dagger");
			Approvals.Approve(weapon);
		}
	}
}
