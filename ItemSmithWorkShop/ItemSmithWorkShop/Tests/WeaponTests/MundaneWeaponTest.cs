using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class MundaneWeaponTest
	{
		[TestMethod]
		public void TestCreateWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			Approvals.Approve(DisplayUtilities.BasicDisplay(weapon));
		}
	}
}
