using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities;

namespace AdventureItemsTests
{
	[TestClass]
	public class AdventureItemsTest
	{


		

		[TestMethod]
		public void TestCreateMagicWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(mithralWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestDisplayFullMagicItemText()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			Approvals.Approve(magicWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestDisplayMaxEnhancedWeaponItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 5);
			Approvals.Approve(magicWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingEnchantment()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingColdIreonWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingDarkwoodItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingMithralItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(mithralWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestWeaponEnchanter()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestDoubleWeaponEnchanter()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem enchantedWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem doubleEnchantedWeapon = WeaponEnchanter.RequestEnchantment(enchantedWeapon, "Flaming");
			Approvals.Approve(doubleEnchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingIcyBurstDagger()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MagicWeaponItem magicWeapon = new MagicWeaponItem(weapon, 1);
			EnchantedWeaponItem flamingWeapon = WeaponEnchanter.RequestEnchantment(magicWeapon, "Flaming");
			EnchantedWeaponItem icyBurstWeapon = WeaponEnchanter.RequestEnchantment(flamingWeapon, "Icy Burst");
			Approvals.Approve(icyBurstWeapon.DisplayFullText());
		}

		/*
		 * Proofs of Concept
		 */

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

		// Include cs test files, not approvals.
		// Re-factor this program first.
		// Renames must happen.
		// Flow must be examined.
		// The next tests will involve concatenating another magical effect onto the weapon.
		// There is also sizing that needs to occur.
	}
}
