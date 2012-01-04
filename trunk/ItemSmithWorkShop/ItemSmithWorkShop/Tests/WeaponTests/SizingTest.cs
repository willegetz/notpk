using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;

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
			Approvals.Approve(DisplayUtilities.BasicDisplay(sizedWeapon));
			//Approvals.Approve(sizedWeapon.DisplaySizedWeapon());
		}

		[TestMethod]
		public void TestSmallAdamantineWeapon()
		{
			var weapon = WeaponItemSmith.OrderItem("Dagger");
			var sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Small");
			var adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(sizedWeapon, "Adamantine");
			Approvals.Approve(DisplayUtilities.BasicDisplay(adamantineWeapon));
		}

		[TestMethod]
		public void TestLargePlus3Weapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			Approvals.Approve(DisplayUtilities.FullMagicalDisplay(magicWeapon));
		}

		[TestMethod]
		public void TestLargePlus3FlamingWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(DisplayUtilities.FullMagicalDisplay(enchantedWeapon));
		}

		[TestMethod]
		public void TestLargePlus3FlamingIcyBurstWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			WeaponItem sizedWeapon = WeaponItemSmith.SizeWeapon(weapon, "Large");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(sizedWeapon, 3);
			EnchantedWeaponItem flamingWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem icyBurstWeapon = WeaponEnchanter.RequestEnchantment(flamingWeapon, "Icy Burst");
			Approvals.Approve(DisplayUtilities.FullMagicalDisplay(icyBurstWeapon));
		}
	}
}
