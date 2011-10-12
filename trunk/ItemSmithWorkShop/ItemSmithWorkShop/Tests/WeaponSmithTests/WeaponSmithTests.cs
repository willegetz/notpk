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
		private static Dictionary<string, WeaponData> genericWeapons;

		static DaggerHelper()
		{
			genericWeapons = new Dictionary<string, WeaponData>(StringComparer.OrdinalIgnoreCase)
			{
				{"Dagger", new WeaponData { WeaponName = "Dagger", WeaponCategory = "Light Melee", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d4", WeaponThreatRange = "19-20", WeaponCritical = "x2", WeaponDamageType = "Piercing or Slashing", WeaponHardness = 10, WeaponHitPoints = 2, BasePrice = 2, WeaponWeight = 1, WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body." }},
				{"Short Sword", new WeaponData { WeaponName = "Short Sword", WeaponCategory = "Light Melee", WeaponProficiencyRequirement = "Martial Weapon", WeaponDamage = "1d6", WeaponThreatRange = "19-20", WeaponCritical = "x2", WeaponDamageType = "Slashing", WeaponHardness = 10, WeaponHitPoints = 2, BasePrice = 10, WeaponWeight = 2, WeaponText = "This sword is popular as an off-hand weapon." }},
				{"Heavy Crossbow", new WeaponData { WeaponName = "Heavy Crossbow", WeaponCategory = "Ranged", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d10", WeaponThreatRange = "19-20", WeaponCritical = "x2", WeaponDamageType = "Piercing", RangeIncrement = "120 feet", WeaponHardness = 5, WeaponHitPoints = 5, BasePrice = 50, WeaponWeight = 8, WeaponText = "You  draw a heavy crossbow back by turning a small winch.\n\tLoading a heavy crossbow is a full-round action that provokes\n\tan attack of opportunity.\n\tNormally, operating a heavy crossbow requires two hands.\n\tHowever, you can shoot, but not load, a heavy crossbow with one\n\thand at a -4 penalty on attack rolls. You can shoot a heavy crossbow\n\twith each hand, but you take a penalty on attack rolls as if attacking\n\twith two one-handed weapons.\n\tThis penalty is cumulative with the penalty for one-handed firing." }},
				{"Quarterstaff", new WeaponData{ WeaponName = "Quarterstaff", WeaponCategory = "Two-Handed Melee", WeaponProficiencyRequirement = "Simple Weapon", WeaponDamage = "1d6/1d6", WeaponThreatRange = "20", WeaponCritical = "x2", WeaponDamageType = "Bludgeoning", WeaponHardness = 5, WeaponHitPoints = 10, BasePrice = 0, WeaponWeight = 4, WeaponText = "I am a quarterstaff"}},
				{"Dwarven Urgrosh A", new WeaponData{ WeaponName = "Dwarven Urgrosh", WeaponPart = "Axe Head", WeaponCategory = "Two-Handed Melee", WeaponProficiencyRequirement = "Exotic Weapon", WeaponDamage = "1d8", WeaponThreatRange = "20", WeaponCritical = "x2", WeaponDamageType = "Slashing", WeaponHardness = 5, WeaponHitPoints = 10, BasePrice = 50, WeaponWeight = 12, WeaponText = "A dwarven urgrosh is a double weapon.\r\tThis is the axe head."} },
				{"Dwarven Urgrosh B", new WeaponData{ WeaponName = "Dwarven Urgrosh", WeaponPart = "Spear Head", WeaponDamage = "1d6", WeaponThreatRange = "20", WeaponCritical = "x2", WeaponDamageType = "Piercing", WeaponHardness = 5, WeaponHitPoints = 10, WeaponWeight = 12, BasePrice = 50, WeaponText = "A dwarven urgrosh is a double weapon.\r\tThis is the spear head."} },
				{ "", new WeaponData { WeaponName = "", WeaponCategory = "", WeaponProficiencyRequirement = "", WeaponDamage = "", WeaponThreatRange = "", WeaponCritical = "", WeaponDamageType = "", WeaponHardness = 0, WeaponHitPoints = 0, BasePrice = 0, WeaponWeight = 0, WeaponText = "" }},
			};

			// A double weapon has two different heads
			// A double weapon has one damage per head
			//		Damage may or may not be the same
			//		Damage scales with size
			// Each head may be of a different material
			// Each head may have a different enhancement bonus
			//		Whole weapon must be masterwork
			//		Masterwork cost is doubled
			//		Each head's enhancement adds to the total value of weapon
		}

		public static WeaponData GetWeaponData(string weapon)
		{
			return genericWeapons[weapon];
		}
	}

	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithTests
	{
		[TestMethod]
		public void TestNullDagger()
		{
			GenericWeapon nullWeapon = new GenericWeapon(null, null);

			Approvals.Approve(nullWeapon);
		}

		[TestMethod]
		public void TestSimpleDaggerObject()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			simpleDagger.IsMasterworkQualifier(true);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			dagger.IsMasterworkQualifier(true);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon mediumDagger = new GenericWeapon(daggerhelper, "Small");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon fineDagger = new GenericWeapon(daggerhelper, "Fine");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon colossalDagger = new GenericWeapon(daggerhelper, "Colossal");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon largeDagger = new GenericWeapon(daggerhelper, "Large");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon faeDagger = new GenericWeapon(daggerhelper, "Diminutive");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

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
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

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
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			var daggerHelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerHelper, "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);

			GenericWeapon smallDagger = new GenericWeapon(daggerHelper, "Small");
			MagicWeapon smallMagicDagger = new MagicWeapon(smallDagger, 2);

			GenericWeapon largeDagger = new GenericWeapon(daggerHelper, "Large");
			MagicWeapon largeMagicDagger = new MagicWeapon(largeDagger, 3);

			GenericWeapon tinyDagger = new GenericWeapon(daggerHelper, "Tiny");
			MagicWeapon tinyMagicDagger = new MagicWeapon(tinyDagger, 4);

			GenericWeapon hugeDagger = new GenericWeapon(daggerHelper, "Huge");
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
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

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
			var daggerhelper = DaggerHelper.GetWeaponData("Dagger");

			GenericWeapon flameDagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicWeapon = new MagicWeapon(flameDagger, 1);
			magicWeapon.EnchantWeaponWith("Flaming");

			Approvals.Approve(flameDagger);
		}

		[TestMethod]
		public void TestShortSword()
		{
			var daggerHelper = DaggerHelper.GetWeaponData("Short Sword");

			GenericWeapon shortSword = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(shortSword);
		}

		[TestMethod]
		public void TestHeavyCrossbow()
		{
			var daggerHelper = DaggerHelper.GetWeaponData("Heavy Crossbow");

			GenericWeapon heavyCrossbow = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(heavyCrossbow);
		}

		[TestMethod]
		public void TestQuarterstaff()
		{
			var daggerHelper = DaggerHelper.GetWeaponData("Quarterstaff");

			GenericWeapon quarterstaff = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(quarterstaff);
		}

		[TestMethod]
		public void TestSimpleDwarvenUrgrosh()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestMagicalDwarvenUrgrosh()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new MagicWeapon(doubleWeapon.FirstWeaponPart, 1);
			new MagicWeapon(doubleWeapon.SecondWeaponPart, 1);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoAdamantine()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponAdamantine(doubleWeapon.FirstWeaponPart);
			new WeaponAdamantine(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoAlchemicalSilver()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponAlchemicalSilver(doubleWeapon.FirstWeaponPart);
			new WeaponAlchemicalSilver(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoColdIron()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponColdIron(doubleWeapon.FirstWeaponPart);
			new WeaponColdIron(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoDarkwood()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponDarkwood(doubleWeapon.FirstWeaponPart);
			new WeaponDarkwood(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoMithral()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponMithral(doubleWeapon.FirstWeaponPart);
			new WeaponMithral(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoSteel()
		{
			var urgroshDataA = DaggerHelper.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = DaggerHelper.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponSteel(doubleWeapon.FirstWeaponPart);
			new WeaponSteel(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}
	}
}
