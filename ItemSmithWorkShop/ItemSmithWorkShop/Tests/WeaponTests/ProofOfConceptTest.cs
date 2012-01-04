using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
			Approvals.Approve(DisplayUtilities.BasicDisplay(weapon));
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
