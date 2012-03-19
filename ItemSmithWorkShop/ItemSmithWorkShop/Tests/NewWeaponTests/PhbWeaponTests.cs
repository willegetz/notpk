using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Items.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Items.MagicEnchantments;
using System;
using System.Linq;
using System.Collections.Generic;
using ItemSmithWorkShop.Items.TheForge;
using ItemSmithWorkShop.Items.Weapons;

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
		public void TestDisplayDistanceEnchantment()
		{
			var distance = new WeaponEnchantment("Distance");
			Approvals.Verify(distance.ToString());
		}

		[TestMethod]
		public void TestDisplayKeenEnchantment()
		{
			var keen = new WeaponEnchantment("Keen");
			Approvals.Verify(keen.ToString());
		}

		[TestMethod]
		public void TestDisplayColdIron()
		{
			var coldIron = new ColdIron();
			Approvals.Verify(coldIron.ToString());
		}

		[TestMethod]
		public void TestForgeMithralWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var mithral = new Mithral();
			var forgedDagger = ItemForge.ForgeWeapon(dagger, mithral);
			forgedDagger.NameWeapon("Carlyle's Special Greeting");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgeColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var coldIron = new ColdIron();
			var forgedDagger = ItemForge.ForgeWeapon(dagger, coldIron);
			forgedDagger.NameWeapon("Krus Hakhar");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgedMasterworkColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var masterworkColdIron = new MasterworkColdIron();
			var masterworkForgedDagger = ItemForge.ForgeWeapon(dagger, masterworkColdIron);
			masterworkForgedDagger.NameWeapon("Holly Thorn");
			Approvals.Verify(masterworkForgedDagger.ToString());
		}

		// When a weapon is combined with a material component, what is produced is a new type of weapon.
		//		Should the material component be responsible for its changes to the original weapon?
		// A weapon needs 

		[Ignore]
		[TestMethod]
		public void TestBlah()
		{
			var dagger = new PhbWeapon("Dagger");
			var distance = new WeaponEnchantment("Distance");
			var anarchic1 = new WeaponEnchantment("Anarchic");
			var anarchic2 = new WeaponEnchantment("Anarchic");
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			var flameBurst1 = new WeaponEnchantment("Flaming Burst");
			var flameBurst2 = new WeaponEnchantment("Flaming Burst");
			var plusEnhancement = 5;
			List<WeaponEnchantment> enchantmentClump = new List<WeaponEnchantment>();
			enchantmentClump.Add(distance);
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

			var criticalDamage = from clump in enchantmentClump
								 where clump.CriticalDamageBonus == true
								 select clump;

			var critCount = criticalDamage.Count();

			var rangeMod = from clump in enchantmentClump
						   where clump.RangeIncrementModifier != 1
						   select clump.RangeIncrementModifier;
			double greatestRangeIncrease = rangeMod.Max();
									

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

			var critSb = new StringBuilder();

			foreach (var critDie in criticalDamage)
			{
				while (critCount > 0)
				{
					string critDice = string.Empty;
					if (dagger.CriticalDamage == "x2")
					{
						critDice = "1d10";
					}
					else if (dagger.CriticalDamage == "x3")
					{
						critDice = "2d10";
					}
					else
					{
						critDice = "3d10";
					}
					critSb.Append(string.Format(" '+{0} ({1})'", critDice, critDie.DamageType));
					
					critCount--;
				}
			}

			sb.Append(string.Format("{0}Total enchantment modifier: '{1}'", Environment.NewLine, enchantmentTotal));
			sb.Append(string.Format("{0}Required caster level: {1}", Environment.NewLine, highestCasterLevel.Max()));
			sb.Append(string.Format("{0}Critical damage dice:{1}", Environment.NewLine, critSb));
			sb.Append(string.Format("{0}Range increment: {1} feet for {2} (was {3} feet for {4} feet)", Environment.NewLine, (dagger.RangeIncrement * greatestRangeIncrease), (dagger.MaxRange * greatestRangeIncrease), dagger.RangeIncrement, dagger.MaxRange));

			Approvals.Verify(sb.ToString());
		}
	}
}
