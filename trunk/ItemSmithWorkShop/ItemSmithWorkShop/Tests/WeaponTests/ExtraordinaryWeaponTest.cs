using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
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
			Approvals.Approve(DisplayUtilities.BasicDisplay(masterworkWeapon));
		}

		[TestMethod]
		public void TestCreateAdamantineWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon adamantineWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Adamantine");
			Approvals.Approve(DisplayUtilities.BasicDisplay(adamantineWeapon));
		}

		[TestMethod]
		public void TestCreateAlchemicalSilverWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon silverWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Silver");
			Approvals.Approve(DisplayUtilities.BasicDisplay(silverWeapon));
		}

		[TestMethod]
		public void TestCreateColdIronWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Short Sword");
			ExtraordinaryQualityWeapon ironWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Cold Iron");
			Approvals.Approve(DisplayUtilities.BasicDisplay(ironWeapon));
		}

		[TestMethod]
		public void TestCreateDarkwoodWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon darkwoodWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Darkwood");
			Approvals.Approve(DisplayUtilities.BasicDisplay(darkwoodWeapon));
		}

		[TestMethod]
		public void TestCreateMithralWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			ExtraordinaryQualityWeapon mithralWeapon = WeaponItemSmith.OrderSpecialComponent(weapon, "Mithral");
			Approvals.Approve(DisplayUtilities.BasicDisplay(mithralWeapon));
		}
	}
}
