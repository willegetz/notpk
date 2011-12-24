using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class ExtraordinaryWeaponTest
	{
		[TestMethod]
		public void TestCreateMasterWorkWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon masterworkWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Masterwork");
			Approvals.Approve(masterworkWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			Approvals.Approve(adamantineWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			Approvals.Approve(silverWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			Approvals.Approve(ironWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			Approvals.Approve(darkwoodWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			Approvals.Approve(mithralWeapon.GetItem());
		}
	}
}
