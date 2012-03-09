using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Weapons;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Weapons.MagicEnchantments;
using System;
using System.Collections.Generic;

namespace ItemSmithWorkShop.Tests.NewWeaponTests
{
	[TestClass]
	public class PhbWeaponTests
	{
		[TestMethod]
		public void TestDisplayDagger()
		{
			var dagger = new PhbWeapon("Dagger");
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
			var anarchic = new WeaponEnchantment("Anarchic");
			Approvals.Verify(anarchic.ToString());
		}

		[TestMethod]
		public void TestDisplayFlamingBurstEnchantment()
		{
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			Approvals.Verify(flameBurst.ToString());
		}
	}
}
