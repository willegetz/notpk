using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;
using MagicWeaponUtilities;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class SizingTest
	{
		[TestMethod]
		public void TestSmallSizeWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Small");
			Approvals.Approve(sizedWeapon.DisplaySizedWeapon());
		}

		[TestMethod]
		public void TestLargeSizeWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			Approvals.Approve(sizedWeapon.DisplaySizedWeapon());
		}

		[TestMethod]
		public void TestSmallAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Small");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(sizedWeapon, "Adamantine");
			Approvals.Approve(adamantineWeapon.GetItem());
		}

		[TestMethod]
		public void TestLargePlus3Weapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			Approvals.Approve(magicWeapon.DisplayFullText());
		}
	}
}
