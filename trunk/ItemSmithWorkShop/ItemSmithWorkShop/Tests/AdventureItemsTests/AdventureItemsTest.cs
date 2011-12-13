using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItemsTests
{
	[TestClass]
	public class AdventureItemsTest
	{
		[TestMethod]
		public void TestCreateWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			Approvals.Approve(weapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMasterWorkWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MasterworkWeaponItem masterworkWeapon = new MasterworkWeaponItem(weapon);
			Approvals.Approve(masterworkWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			AdamantineWeaponItem adamantineWeapon = new AdamantineWeaponItem(weapon);
			Approvals.Approve(adamantineWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			AlchemicalSilverWeaponItem silverWeapon = new AlchemicalSilverWeaponItem(weapon);
			Approvals.Approve(silverWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ColdIronWeaponItem ironWeapon = new ColdIronWeaponItem(weapon);
			Approvals.Approve(ironWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			DarkwoodWeaponItem darkwoodWeapon = new DarkwoodWeaponItem(weapon);
			Approvals.Approve(darkwoodWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MithralWeaponItem mithralWeapon = new MithralWeaponItem(weapon);
			Approvals.Approve(mithralWeapon.GetItem());
		}

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
			AdamantineWeaponItem adamantineWeapon = new AdamantineWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			AlchemicalSilverWeaponItem silverWeapon = new AlchemicalSilverWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ColdIronWeaponItem ironWeapon = new ColdIronWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			DarkwoodWeaponItem darkwoodWeapon = new DarkwoodWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			Approvals.Approve(magicWeapon.GetItem());
		}

		[TestMethod]
		public void TestCreateMagicMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MithralWeaponItem mithralWeapon = new MithralWeaponItem(weapon);
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
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			AdamantineWeaponItem adamantineWeapon = new AdamantineWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(adamantineWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			AlchemicalSilverWeaponItem silverWeapon = new AlchemicalSilverWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(silverWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingColdIreonWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ColdIronWeaponItem ironWeapon = new ColdIronWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(ironWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingDarkwoodItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			DarkwoodWeaponItem darkwoodWeapon = new DarkwoodWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(darkwoodWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		[TestMethod]
		public void TestFlamingMithralItem()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			MithralWeaponItem mithralWeapon = new MithralWeaponItem(weapon);
			MagicWeaponItem magicWeapon = new MagicWeaponItem(mithralWeapon, 1);
			EnchantedWeaponItem enchantedWeapon = new EnchantedWeaponItem(magicWeapon, "Flaming");
			Approvals.Approve(enchantedWeapon.DisplayFullText());
		}

		// Re-factor this program first.
		// Renames must happen.
		// Flow must be examined.
		// The next tests will involve concatenating another magical effect onto the weapon.
		// There is also sizing that needs to occur.
	}
}
