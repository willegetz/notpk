using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponTicket;

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

			Approvals.Approve(ticket);
		}
	}
}
