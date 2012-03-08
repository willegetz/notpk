using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Weapons;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Weapons.MagicEnchantments;

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
		public void TestBlah()
		{
			var dagger = new PhbWeapon();
			var mithral = new Mithral();
			var anarchic = new WeaponEnchantment();

			var name = new StringBuilder();

			if (anarchic.Affix == "Pre")
			{
				name.Append(string.Format("{0} {1} {2}", anarchic.EnchantmentName, mithral.MaterialName, dagger.WeaponName));
			}
			else
			{
				name.Append(string.Format("{0} {1} of {2}", dagger.WeaponName, mithral.MaterialName, anarchic.EnchantmentName));
			}

			var sb = new StringBuilder();

			sb.AppendLine(string.Format("Name: {1} {2} {0}", anarchic.EnchantmentName, mithral.MaterialName, dagger.WeaponName));
			sb.AppendLine();
			sb.AppendLine(name.ToString());

			Approvals.Verify(sb.ToString());
		}
	}
}
