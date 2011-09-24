using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItemSmithWorkShop;
using System.Collections.Specialized;
using System.Collections;
using ApprovalTests.Reporters;
using ApprovalTests;

namespace ItemSmithWorkShop
{
	public static class DaggerHelper
	{
		public static DaggerHelper(string weapon)
		{
			Dictionary<string, WeaponData> genericWeapons = new Dictionary<string, WeaponData>();
			genericWeapons.Add("Dagger", new WeaponData { WeaponName = "Dagger", WeaponCategory = "Melee", WeaponProficiencyRequirement = "Light Weapon", WeaponDamage = "1d4", WeaponThreatRange = "19-20", WeaponCritical = "x2", WeaponDamageType = "Piercing or Slashing", WeaponHardness = 10, WeaponHitPoints = 2, BasePrice = 2, WeaponWeight = 1, WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body." });

			return genericWeapons[weapon];
		}

		public static WeaponData GetWeaponData()
		{
			WeaponData data = new WeaponData();

			data.WeaponName = "Dagger";
			data.WeaponCategory = "Melee";
			data.WeaponProficiencyRequirement = "Light Weapon";
			data.WeaponDamage = "1d4";
			data.WeaponThreatRange = "19-20";
			data.WeaponCritical = "x2";
			data.WeaponDamageType = "Piercing or Slashing";
			data.WeaponHardness = 10;
			data.WeaponHitPoints = 2;
			data.BasePrice = 2;
			data.WeaponWeight = 1;
			data.WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.";

			return data;
		}
	}

	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithTests
	{
		[TestMethod]
		public void TestSimpleDaggerObject()
		{
			var daggerhelper = DaggerHelper("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);

			Approvals.Approve(simpleDagger);
		}

		private object DaggerHelper(string p)
		{
			throw new NotImplementedException();
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			simpleDagger.IsMasterworkQualifier(true);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon mediumDagger = new GenericWeapon(daggerhelper, "Small");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon fineDagger = new GenericWeapon(daggerhelper, "Fine");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon colossalDagger = new GenericWeapon(daggerhelper, "Colossal");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon largeDagger = new GenericWeapon(daggerhelper, "Large");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon faeDagger = new GenericWeapon(daggerhelper, "Diminutive");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger;
			List<GenericWeapon> inventory = new List<GenericWeapon>();
			var displayInventory = new StringBuilder();

			int daggerQuantity = 5;

			for (int i = 0; i <= daggerQuantity; i++)
			{
				dagger = new GenericWeapon(daggerhelper, null);
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
			var daggerhelper = DaggerHelper.GetWeaponData();

			List<GenericWeapon> inventory = new List<GenericWeapon>();
			var displayInventory = new StringBuilder();

			GenericWeapon faeDagger = new GenericWeapon(daggerhelper, "Fine");
			new WeaponAlchemicalSilver(faeDagger);
			faeDagger.WeaponName = String.Format("Faerie's Dagger ({0}{3} ({1}){2})\n", faeDagger.WeaponName, faeDagger.WeaponSize, faeDagger.MasterWorkLabel, faeDagger.MaterialName);
			faeDagger.AdditionalText = "Dagger left by a faerie as a token of friendship.";

			GenericWeapon ogreDagger = new GenericWeapon(daggerhelper, "Large");
			new WeaponColdIron(ogreDagger);
			ogreDagger.WeaponName = String.Format("Tooth ({0})", ogreDagger.WeaponName);
			ogreDagger.AdditionalText = "Dagger of an Ogre Mage chief taken from its body after a vicious fight.";

			GenericWeapon expensiveDagger = new GenericWeapon(daggerhelper, "Medium");
			new WeaponMithral(expensiveDagger);
			expensiveDagger.WeaponName = String.Format("Oscar's Fine Blade ({0})", expensiveDagger.WeaponName);
			expensiveDagger.TotalWeaponCost = (expensiveDagger.TotalWeaponCost * 10);
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
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);

			GenericWeapon smallDagger = new GenericWeapon(daggerhelper, "Small");
			MagicWeapon smallMagicDagger = new MagicWeapon(smallDagger, 2);

			GenericWeapon largeDagger = new GenericWeapon(daggerhelper, "Large");
			MagicWeapon largeMagicDagger = new MagicWeapon(largeDagger, 3);

			GenericWeapon tinyDagger = new GenericWeapon(daggerhelper, "Tiny");
			MagicWeapon tinyMagicDagger = new MagicWeapon(tinyDagger, 4);

			GenericWeapon hugeDagger = new GenericWeapon(daggerhelper, "Huge");
			MagicWeapon hugeMagicDagger = new MagicWeapon(hugeDagger, 5);

			List<GenericWeapon> inventory = new List<GenericWeapon>();
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
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon dagger = new GenericWeapon(daggerhelper, "Huge");
			dagger.AdditionalText = "Brawn carried this boot knife whenever he went into the wilderness to work. While not fashioned for combat,\n\t\tBrawn has successfully defended himself many times with this blade.";
			new WeaponAdamantine(dagger);
			new MagicWeapon(dagger, 3);
			dagger.WeaponName = String.Format("Brawn's Insurance ({1})", dagger.PlusEnhancementBonus, dagger.WeaponName);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAddFlamingEnhancement()
		{
			var daggerhelper = DaggerHelper.GetWeaponData();

			GenericWeapon flameDagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicWeapon = new MagicWeapon(flameDagger, 1);
			magicWeapon.EnchantWeaponWith("Flaming");

			Approvals.Approve(flameDagger);
		}
	}
}
