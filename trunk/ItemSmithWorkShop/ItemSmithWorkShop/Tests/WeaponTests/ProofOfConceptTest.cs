﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class ProofOfConceptTest
	{
		[TestMethod]
		public void TestWeaponOrder()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			Approvals.Approve(weapon.ToString());
		}

		[TestMethod]
		public void TestMasterworkOrder()
		{
			WeaponOrder weapon = WeaponItemSmith.OrderBlah("Dagger");
			MasterworkWeaponItem masterworkWeapon = WeaponItemSmith.OrderBlah(weapon, "Masterwork");
			Approvals.Approve(masterworkWeapon.ToString());
		}
	}
}