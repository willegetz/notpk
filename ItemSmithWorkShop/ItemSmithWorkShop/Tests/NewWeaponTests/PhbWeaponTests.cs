using System.Text;
using ApprovalTests;
using ItemSmithWorkShop.Items.MaterialTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop.Items.MagicEnchantments;
using System;
using System.Linq;
using System.Collections.Generic;
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
			var forgedDagger = new ForgedWeapon(dagger, mithral);
			forgedDagger.NameWeapon("Carlyle's Special Greeting");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgeColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var coldIron = new ColdIron();
			var forgedDagger = new ForgedWeapon(dagger, coldIron);
			forgedDagger.NameWeapon("Krus Hakhar");
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgedMasterworkColdIronWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var masterworkColdIron = new MasterworkColdIron();
			var masterworkForgedDagger = new ForgedWeapon(dagger, masterworkColdIron);
			masterworkForgedDagger.NameWeapon("Holly Thorn");
			Approvals.Verify(masterworkForgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgedAlchemicalSilverWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var silver = new AlchemicalSilver();
			var forgedDagger = new ForgedWeapon(dagger, silver);
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestForgedMasterworkAlchemicalSilverWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var masterworkSilver = new MasterworkAlchemicalSilver();
			var forgedDagger = new ForgedWeapon(dagger, masterworkSilver);
			Approvals.Verify(forgedDagger.ToString());
		}

		[TestMethod]
		public void TestMasterworkAlchemicalSilverWeapon()
		{
			var dagger = new PhbWeapon("Dagger");
			var silver = new AlchemicalSilver();
			var forgedDagger = new ForgedWeapon(dagger, silver);
			var masterwork = new Masterwork();
			var masterworkSilverDagger = new ForgedWeapon(forgedDagger, masterwork);
			Approvals.Verify(masterworkSilverDagger.ToString());
		}

		[Ignore] // Not quite ready yet
		[TestMethod]
		public void TestPlusEnhancementWeapon()
		{
			// A weapon must be masterwork before it can be magical.
			// A magic weapon:
			//		Has a plus enhancement from 1 to 5
			//		Adds the plus enhancement to attack and damage
			//		Has a cost that is: Square the plus enhancement and then multiply by 2
			//		Adjusts the hardness and hit points based on plus modifier
			//		Must be a plus 1 before any special qualities can be added
			//		... more here to add
			//		PhbWeapon => ForgedWeapon => PlusWeapon => EnchantedWeapon
			var weaopn = new PhbWeapon("Dagger");
			var masterwork = new Masterwork();
			var forgedWeapon = new ForgedWeapon(weaopn, masterwork);
			var plusWeapon = new PlusEnchantedWeapon(forgedWeapon, 1);
			Assert.Fail();
		}

		// When a weapon is combined with a material component, what is produced is a new type of weapon.
		//		Should the material component be responsible for its changes to the original weapon?
		// A weapon needs 

		[Ignore]
		[TestMethod]
		public void TestBlah()
		{
			var dagger = new PhbWeapon("Dagger");
			var forgedDagger = new ForgedWeapon(dagger, new MasterworkColdIron());
			var distance = new WeaponEnchantment("Distance");
			var anarchic = new WeaponEnchantment("Anarchic");
			var keen = new WeaponEnchantment("Keen");
			var flameBurst = new WeaponEnchantment("Flaming Burst");
			//var flameBurst1 = new WeaponEnchantment("Flaming Burst");
			//var flameBurst2 = new WeaponEnchantment("Flaming Burst");
			var plusEnhancement = 4;
			List<WeaponEnchantment> enchantmentClump = new List<WeaponEnchantment>();
			enchantmentClump.Add(distance);
			enchantmentClump.Add(anarchic);
			enchantmentClump.Add(keen);
			enchantmentClump.Add(flameBurst);
			//enchantmentClump.Add(flameBurst1);
			//enchantmentClump.Add(flameBurst2);

			var enchantmentTotals = from clump in enchantmentClump
								   select clump.CostModifier;

			var totalEnchantmentModifier = enchantmentTotals.ToList();
			totalEnchantmentModifier.Add(plusEnhancement);

			var enchantmentTotal = totalEnchantmentModifier.Sum();
								   

			var prefixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Pre")
						   select clump;

			var prefixCount = prefixes.Count();

			var suffixes = from clump in enchantmentClump
						   where clump.Affix.Contains("Suf")
						   select clump;

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
					sb.Append(string.Format("{0} (+{1} bonus)", prefix.EnchantmentName, prefix.CostModifier));
					sb.Append(", ");
					prefixCount--;
				}
				else
				{
					sb.Append(string.Format("{0} (+{1} bonus)", prefix.EnchantmentName, prefix.CostModifier));
				}
				
			}

			sb.Append(string.Format(" {0}", forgedDagger.WeaponName));

			foreach (var suffix in suffixes)
			{
				
				while (suffixCount > 0)
				{
					sb.Append(" of ");
					sb.Append(string.Format("{0} (+{1} bonus)", suffix.EnchantmentName, suffix.CostModifier));
					suffixCount--;
				}
				
			}

			var critSb = new StringBuilder();

			foreach (var critDie in criticalDamage)
			{
				while (critCount > 0)
				{
					string critDice = string.Empty;
					if (forgedDagger.CriticalDamage == "x2")
					{
						critDice = "1d10";
					}
					else if (forgedDagger.CriticalDamage == "x3")
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
			sb.Append(string.Format("{0}Total enhancement cost: '{1}'", Environment.NewLine, ((Math.Pow(enchantmentTotal, 2) * 2000) + forgedDagger.WeaponCost + forgedDagger.AdditionalEnchantmentCost)));
			sb.Append(string.Format("{0}Required caster level: {1}", Environment.NewLine, highestCasterLevel.Max()));
			sb.Append(string.Format("{0}Critical damage dice:{1}", Environment.NewLine, critSb));
			sb.Append(string.Format("{0}Range increment: {1} feet for {2} (was {3} feet for {4} feet)", Environment.NewLine, (forgedDagger.RangeIncrement * greatestRangeIncrease), (dagger.MaxRange * greatestRangeIncrease), dagger.RangeIncrement, dagger.MaxRange));

			Approvals.Verify(sb.ToString());
		}
	}
}
