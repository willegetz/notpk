using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponOrder;

namespace ItemSmithWorkShop.Tests.WeaponTicketTests
{
	[TestClass]
	public class WeaponTicketTests
	{
		[TestMethod]
		public void TestWeaponTicket()
		{
			var ticket = new WeaponTicket();

			ticket.AddLineItem(new WeaponHead("Dagger"));
			ticket.AddLineItem(new WeaponHead("Short Sword"));

			Approvals.Approve(ticket);
		}
	}
}
