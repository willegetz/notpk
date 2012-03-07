using ApprovalTests;
using ItemSmithWorkShop.Weapons;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemSmithWorkShop.Tests.NewWeaponTests
{
	[TestClass]
	public class PhbWeaponTests
	{
		[TestMethod]
		public void TestDisplayDagger()
		{
			var dagger = new PhbWeapon();
			Approvals.Verify(dagger.ToString());
		}

		[TestMethod]
		public void TestDisplayMithral()
		{
			var mithral = new Mithral();
			Approvals.Verify(mithral.ToString());
		}
	}
}
