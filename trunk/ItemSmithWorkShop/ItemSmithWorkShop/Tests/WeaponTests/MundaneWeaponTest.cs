using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using AdventureItems;

namespace ItemSmithWorkShop.Tests.WeaponTests
{
	[TestClass]
	public class MundaneWeaponTest
	{
		[TestMethod]
		public void TestCreateWeapon()
		{
			WeaponItem weapon = WeaponItemSmith.OrderItem("Dagger");
			Approvals.Approve(weapon.GetItem());
		}
	}
}
