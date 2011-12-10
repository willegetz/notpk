﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;

namespace AdventureItemsTests
{
	[TestClass]
	public class AdventureItemsTest
	{
		[TestMethod]
		public void TestCreateWeapon()
		{
			AdventureItemShop weaponShop = new WeaponItemSmith();
			AdventureItem weapon = weaponShop.OrderItem("Dagger");
			var weapon = new DisplayItem(weapon);
			Approvals.Approve(weapon);
		}
	}
}
