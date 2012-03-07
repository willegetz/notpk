using ApprovalTests;
using ItemSmithWorkShop.Weapons;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Weapons.MagicEnchantments;
using ItemSmithWorkShop.Weapons.Smith;

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

		[TestMethod]
		public void TestDisplayAnarchicEnchantment()
		{
			var anarchic = new WeaponEnchantment();
			Approvals.Verify(anarchic.ToString());
		}

		[TestMethod]
		public void TestCombineDaggerAndMithral()
		{
			var dagger = new PhbWeapon();
			var mithral = new Mithral();
			var smith = new WeaponSmith(dagger, mithral);
			smith.ForgeWeapon();
			Approvals.Verify(smith.Display());
		}
	}
}
