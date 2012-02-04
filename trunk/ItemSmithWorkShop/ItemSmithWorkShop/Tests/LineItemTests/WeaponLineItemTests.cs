﻿using System;
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
			var weapon = ItemTicket.GetWeaponTicket("Dagger");
			Approvals.Approve(weapon);
		}
	}
}
