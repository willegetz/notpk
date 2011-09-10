using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWeaponSmith;
using ItemSmithWorkShop;
using System.Collections.Specialized;
using System.Collections;
using ApprovalTests.Reporters;
using ApprovalTests;

namespace ItemSmithTests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithTests
	{
		[TestMethod]
		public void TestDisplayDagger()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestProperNameDagger()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("One-eyed Bart's Shiv");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDmChangesPrice()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Expensive Dagger");
			dagger.WeaponCost(10);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestWeaponIsMasterWork()
		{
			Dagger dagger = new Dagger();
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			dagger.IsMasterworkQualifier(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSteelProperty()
		{
			SteelMaterial steel = new SteelMaterial();

			Approvals.Approve(steel);
		}

		[TestMethod]
		public void TestAdamantineProperty()
		{
			ItemSmithWeaponSmith.AdamantineMaterial adamantine = new ItemSmithWeaponSmith.AdamantineMaterial();

			Approvals.Approve(adamantine);
		}

		[TestMethod]
		public void TestDagger()
		{
			Dagger dagger = new Dagger();

			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSteelPropertyOnDagger()
		{
			MaterialComponent steel = new SteelMaterial();
			Dagger dagger = new Dagger(steel);

			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAdamantinePropertyOnDagger()
		{
			MaterialComponent adamantine = new AdamantineMaterial();
			Dagger dagger = new Dagger(adamantine);

			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMaterialPassedIntoConstructor()
		{
			MaterialComponent steel = new SteelMaterial();
			Dagger dagger = new Dagger(steel);
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNullMaterialPassedIntoConstructor()
		{
			Dagger dagger = new Dagger(null);
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAdamantineMaterialPassedIntoConstructor()
		{
			MaterialComponent adamantine = new AdamantineMaterial();
			Dagger dagger = new Dagger(adamantine);
			dagger.WeaponName("Dagger");
			dagger.WeaponCost(2);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSimpleDaggerObject()
		{
			SimpleDagger simpleDagger = new SimpleDagger(null);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			SimpleDagger simpleDagger = new SimpleDagger(null);
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			SimpleDagger simpleDagger = new SimpleDagger(null);
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			SimpleDagger simpleDagger = new SimpleDagger(null);
			simpleDagger.IsMasterworkQualifier(true);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			dagger.IsMasterworkQualifier(true);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			dagger.IsMasterworkQualifier(true);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			SimpleDagger mediumDagger = new SimpleDagger("Small");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			SimpleDagger fineDagger = new SimpleDagger("Fine");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			SimpleDagger colossalDagger = new SimpleDagger("Colossal");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			SimpleDagger largeDagger = new SimpleDagger("Large");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			SimpleDagger faeDagger = new SimpleDagger("Diminutive");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			SimpleDagger dagger;
			List<SimpleDagger> inventory = new List<SimpleDagger>();
			var displayInventory = new StringBuilder();

			int daggerQuantity = 5;

			for (int i = 0; i <= daggerQuantity; i++)
			{
				dagger = new SimpleDagger(null);
				inventory.Add(dagger);
			}

			foreach (var item in inventory)
			{
				displayInventory.Append(item + "\n\n");
			}

			Approvals.Approve(displayInventory);
		}

		[TestMethod]
		public void TestMultipleDifferentDaggers()
		{
			List<SimpleDagger> inventory = new List<SimpleDagger>();
			var displayInventory = new StringBuilder();

			SimpleDagger faeDagger = new SimpleDagger("Fine");
			new WeaponAlchemicalSilver(faeDagger);
			faeDagger.WeaponName = String.Format("Faerie's Dagger ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Dagger left by a faerie as a token of friendship.";

			SimpleDagger ogreDagger = new SimpleDagger("Large");
			new WeaponColdIron(ogreDagger);
			ogreDagger.WeaponName = String.Format("Tooth ({0})", ogreDagger.WeaponName);
			ogreDagger.AdditionalText = "Dagger of an Ogre Mage chief taken from its body after a vicious fight.";

			SimpleDagger expensiveDagger = new SimpleDagger("Medium");
			new WeaponMithral(expensiveDagger);
			expensiveDagger.WeaponName = String.Format("Oscar's Fine Blade ({0})", expensiveDagger.WeaponName);
			expensiveDagger.WeaponCost = (expensiveDagger.WeaponCost * 10);
			expensiveDagger.AdditionalText = "Oscar's Fine Blade is ornately crafted. Fine jewels are tastefully set along the hilt.\n\tThe mithral is inlaid with gold to form a rich and flowing design that hints at the arcane.";

			inventory.Add(faeDagger);
			inventory.Add(ogreDagger);
			inventory.Add(expensiveDagger);

			foreach (var item in inventory)
			{
				displayInventory.Append(item + "\n\n\n");
			}

			Approvals.Approve(displayInventory);
		}

		[TestMethod]
		public void TestMagicalWeapon()
		{
			SimpleDagger dagger = new SimpleDagger("Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			SimpleDagger dagger = new SimpleDagger("Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);

			SimpleDagger smallDagger = new SimpleDagger("Small");
			MagicWeapon smallMagicDagger = new MagicWeapon(smallDagger, 2);

			SimpleDagger largeDagger = new SimpleDagger("Large");
			MagicWeapon largeMagicDagger = new MagicWeapon(largeDagger, 3);

			SimpleDagger tinyDagger = new SimpleDagger("Tiny");
			MagicWeapon tinyMagicDagger = new MagicWeapon(tinyDagger, 4);

			SimpleDagger hugeDagger = new SimpleDagger("Huge");
			MagicWeapon hugeMagicDagger = new MagicWeapon(hugeDagger, 5);

			List<SimpleDagger> inventory = new List<SimpleDagger>();
			var displayInventory = new StringBuilder();

			inventory.Add(dagger);
			inventory.Add(smallDagger);
			inventory.Add(largeDagger);
			inventory.Add(tinyDagger);
			inventory.Add(hugeDagger);

			foreach (var item in inventory)
			{
				displayInventory.Append(item + "\n\n\n");
			}

			Approvals.Approve(displayInventory);
		}

		[TestMethod]
		public void TestColdIronMagicWeapon()
		{
			SimpleDagger dagger = new SimpleDagger(null);
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			SimpleDagger dagger = new SimpleDagger("Huge");
			dagger.AdditionalText = "Brawn carried this boot knife whenever he went into the wilderness to work. While not fashioned for combat,\n\t\tBrawn has successfully defended himself many times with this blade.";
			new WeaponAdamantine(dagger);
			new MagicWeapon(dagger, 3);
			dagger.WeaponName = String.Format("Brawn's Insurance ({0})", dagger.WeaponName);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestWeaponHardnessHitPointsBySize()
		{
			Dictionary<string, double> hardnessHitPoints = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
			var sb = new StringBuilder();

			double hardness = 10;
			double hitPoints = 20;

			hardnessHitPoints.Add("Fine", 0.0625);
			hardnessHitPoints.Add("Diminutive", 0.125);
			hardnessHitPoints.Add("Tiny", 0.25);
			hardnessHitPoints.Add("Small", 0.5);
			hardnessHitPoints.Add("Medium", 1);
			hardnessHitPoints.Add("Large", 2);
			hardnessHitPoints.Add("Huge", 4);
			hardnessHitPoints.Add("Gargantuan", 8);
			hardnessHitPoints.Add("Colossal", 16);

			foreach (var item in hardnessHitPoints)
			{
				sb.Append(String.Format("Original Hardness: {0}\tOriginal Hit Points: {1}\nWeapon Size: {2}\nNew Hardness: {3}\tNew Hit Points: {4}\n\n", hardness, hitPoints, item.Key, (hardness * item.Value), (hitPoints * item.Value)));
			}

			Approvals.Approve(sb);
		}

		[TestMethod]
		public void TestWeaponDamageBySize()
		{
			Dictionary<string, string> damage = new Dictionary<string, string>();

			damage.Add("Fine", "No Meaningful Damage");
			damage.Add("Diminutive", "1");
			damage.Add("Tiny", "1d2");
			damage.Add("Small", "1d3");
			damage.Add("Medium", "1d4");
			damage.Add("Large", "1d6");
			damage.Add("Huge", "1d8");
			damage.Add("Gargantuan", "2d6");
			damage.Add("Colossal", "3d6");

			List<KeyValuePair<string, string>> weaponDamage = new List<KeyValuePair<string, string>>();

			var sb = new StringBuilder();

			foreach (var item in damage)
			{
				weaponDamage.Add(item);
			}

			foreach (var item in weaponDamage)
			{
				sb.Append(String.Format("Index: {2}\tSize: {0}\tDamage: {1}\n", item.Key, item.Value, weaponDamage.IndexOf(item)));
			}

			Approvals.Approve(sb);
		}

		[TestMethod]
		public void TestDictionaryQuery()
		{
			string[] baseDamage = new []{"1d2", "1d3", "1d4", "1d6", "2d4", "1d8", "1d10", "1d12", "2d6"};
			string[] sizeDesired = new[] { "Fine", "Diminutive", "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan", "Colossal" };

			ApprovalTests.Combinations.Approvals.ApproveAllCombinations(GetDamage, baseDamage, sizeDesired);
		}

		[TestMethod]
		public void TestWeightCalculationUsingHardnessHitPointModifiers()
		{
			//double[] weightModifiers = new[] { 0.0625, 0.125, 0.25, 0.5, 1, 2, 4, 8, 16 };

			double[] weaponWeights = new[] { 0.5, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15 };

			Dictionary<string, double> weightModifiers = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase);
			weightModifiers.Add("Fine", 0.0625);
			weightModifiers.Add("Diminutive", 0.125);
			weightModifiers.Add("Tiny", 0.25);
			weightModifiers.Add("Small", 0.5);
			weightModifiers.Add("Medium", 1);
			weightModifiers.Add("Large", 2);
			weightModifiers.Add("Huge", 4);
			weightModifiers.Add("Gargantuan", 8);
			weightModifiers.Add("Colossal", 16);

			var sb = new StringBuilder();

			foreach (var weight in weaponWeights)
			{
				foreach (var modifier in weightModifiers)
				{
					sb.Append(String.Format("Initial Weight for Medium Weapon: '{0}' pounds\t=>\t'<{1}>'\t'{2} pounds'\n", weight,  modifier.Key, (weight * modifier.Value)));
				}
			}

			Approvals.Approve(sb);
		}

		public string GetDamage(string damage, string size)
		{
			const string fine = "Fine";
			const string diminutive = "Diminutive";
			const string tiny = "Tiny";
			const string small = "Small";
			const string medium = "Medium";
			const string large = "Large";
			const string huge = "Huge";
			const string gargantuan = "Gargantuan";
			const string colossal = "Colossal";

			Dictionary<string, int> sizing = new Dictionary<string,int>{
			{fine, 0}, {diminutive, 1}, {tiny, 2}, {small, 3}, {medium, 4}, {large, 5}, {huge, 6}, {gargantuan, 7}, {colossal, 8}};

			int sizingIndex = sizing[size];

			string[] damage1D2 = new[]{ "No Meaningful Damage", "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8" };
			string[] damage1D3 = new[] { "No Meaningful Damage", "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6" };
			string[] damage1D4 = new[] { "No Meaningful Damage", "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6" };
			string[] damage1D6 = new[] { "1", "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6" };
			string[] damage2D4 = new[] { "1d2", "1d3", "1d4", "1d6", "2d4", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D8 = new[] { "1d2", "1d3", "1d4", "1d6", "1d8", "2d6", "3d6", "4d6", "6d6" };
			string[] damage1D10 = new[] { "1d3", "1d4", "1d6", "1d8", "1d10", "2d8", "3d8", "4d8", "6d8" };
			string[] damage1D12 = new[] { "1d4", "1d6", "1d8", "1d10", "1d12", "3d6", "4d6", "6d6", "8d6" };
			string[] damage2D6 = new[] { "1d4", "1d6", "1d8", "1d10", "2d6", "3d6", "4d6", "6d6", "8d6" };

			Dictionary<string, string[]> sizeModification = new Dictionary<string, string[]>{
						 {"1d2", damage1D2}, {"1d3", damage1D3}, {"1d4", damage1D4}, {"1d6", damage1D6},
						 {"2d4", damage2D4}, {"1d8", damage1D8}, {"1d10", damage1D10}, {"1d12", damage1D12},
						 {"2d6", damage2D6}
			};

			return sizeModification[damage][sizingIndex].ToString();
		}
	}
}
