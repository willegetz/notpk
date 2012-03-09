using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Weapons;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Weapons.MagicEnchantments;
using System;
using System.Linq;
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

		[TestMethod]
		public void TestBlah()
		{
			var dagger = new PhbWeapon("Dagger");
			var anarchic = new WeaponEnchantment("Anarchic");
			var anarchic1 = new WeaponEnchantment("Anarchic");
			var anarchic2 = new WeaponEnchantment("Anarchic");
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			var flameBurst1 = new WeaponEnchantment("Flaming Burst");
			var flameBurst2 = new WeaponEnchantment("Flaming Burst");
			var plusEnhancement = 5;
			List<WeaponEnchantment> enchantmentClump = new List<WeaponEnchantment>();
			enchantmentClump.Add(anarchic);
			enchantmentClump.Add(anarchic1);
			enchantmentClump.Add(anarchic2);
			enchantmentClump.Add(flameBurst);
			enchantmentClump.Add(flameBurst1);
			enchantmentClump.Add(flameBurst2);

			var enchantmentTotals = from clump in enchantmentClump
								   select clump.CostModifier;

			var totalEnchantmentModifier = enchantmentTotals.ToList();
			totalEnchantmentModifier.Add(plusEnhancement);

			var enchantmentTotal = totalEnchantmentModifier.Sum();
								   

			var prefixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Pre")
						   select clump.EnchantmentName;

			var prefixCount = prefixes.Count();

			var suffixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Suf")
						   select clump.EnchantmentName;

			var suffixCount = suffixes.Count();

			var casterLevels = from clump in enchantmentClump
							   select clump.MinimumCasterLevel;

			var highestCasterLevel = casterLevels.ToList();
			highestCasterLevel.Add((plusEnhancement * 3));
			

			var sb = new StringBuilder();

			sb.Append(string.Format("+{0} ", plusEnhancement));

			foreach (var prefix in prefixes)
			{
				if (prefixCount > 1)
				{
					sb.Append(string.Format("{0}", prefix));
					sb.Append(", ");
					prefixCount--;
				}
				else
				{
					sb.Append(string.Format("{0}", prefix));
				}
				
			}

			sb.Append(string.Format(" {0}", dagger.WeaponName));

			foreach (var suffix in suffixes)
			{
				
				while (suffixCount > 0)
				{
					sb.Append(" of ");
					sb.Append(string.Format("{0}", suffix));
					suffixCount--;
				}
				
			}

			sb.Append(string.Format("{0}Total enchantment modifier: '{1}'", Environment.NewLine, enchantmentTotal));
			sb.Append(string.Format("{0}Required caster level: {1}", Environment.NewLine, highestCasterLevel.Max()));

			Approvals.Verify(sb.ToString());
		}
	}
}
