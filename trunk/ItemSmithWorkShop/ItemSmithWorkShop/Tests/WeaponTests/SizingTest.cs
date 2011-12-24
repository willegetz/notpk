using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureItems;
using ApprovalTests;

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
	}
}
