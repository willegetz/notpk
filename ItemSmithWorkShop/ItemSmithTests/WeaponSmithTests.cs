using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests.Reporters;
using ItemSmithWeaponSmith;
using ApprovalTests;
using ItemSmithWorkShop;
using System.Collections.Specialized;
using System.Collections;

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
			// Fine	Diminutive	Tiny	Small	Medium	Large	Huge	Gargantuan	Colossal
			// —	1	1d2	1d3	1d4	1d6	1d8	2d6	3d6
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
				//sb.Append(String.Format("Size: {0}\tDamage: {1}\n", item.Key, item.Value));
			}

			foreach (var item in weaponDamage)
			{
				sb.Append(String.Format("Index: {2}\tSize: {0}\tDamage: {1}\n", item.Key, item.Value, weaponDamage.IndexOf(item)));
			}

			Approvals.Approve(sb);
		}
	}
}
