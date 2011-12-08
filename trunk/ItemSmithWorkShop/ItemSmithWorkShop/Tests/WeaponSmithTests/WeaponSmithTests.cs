using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	[TestClass]
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
			WeaponData daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon simpleDagger = new GenericWeapon(daggerhelper, null);
			MasterworkWeapon.MakeMasterwork(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			MasterworkWeapon.MakeMasterwork(dagger);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			MasterworkWeapon.MakeMasterwork(dagger);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			MasterworkWeapon.MakeMasterwork(dagger);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon mediumDagger = new GenericWeapon(daggerhelper, "Small");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon fineDagger = new GenericWeapon(daggerhelper, "Fine");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon colossalDagger = new GenericWeapon(daggerhelper, "Colossal");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon largeDagger = new GenericWeapon(daggerhelper, "Large");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon faeDagger = new GenericWeapon(daggerhelper, "Diminutive");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

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
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

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
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			var daggerHelper = TempWeaponDictionary.GetWeaponData("Dagger");

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
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon dagger = new GenericWeapon(daggerhelper, null);
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

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
			var daggerhelper = TempWeaponDictionary.GetWeaponData("Dagger");

			GenericWeapon flameDagger = new GenericWeapon(daggerhelper, "Medium");
			MagicWeapon magicWeapon = new MagicWeapon(flameDagger, 1);
			magicWeapon.EnchantWeaponWith("Flaming");

			Approvals.Approve(flameDagger);
		}

		[TestMethod]
		public void TestShortSword()
		{
			var daggerHelper = TempWeaponDictionary.GetWeaponData("Short Sword");

			GenericWeapon shortSword = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(shortSword);
		}

		[TestMethod]
		public void TestHeavyCrossbow()
		{
			var daggerHelper = TempWeaponDictionary.GetWeaponData("Heavy Crossbow");

			GenericWeapon heavyCrossbow = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(heavyCrossbow);
		}

		[TestMethod]
		public void TestQuarterstaff()
		{
			var daggerHelper = TempWeaponDictionary.GetWeaponData("Quarterstaff");

			GenericWeapon quarterstaff = new GenericWeapon(daggerHelper, null);

			Approvals.Approve(quarterstaff);
		}

		[TestMethod]
		public void TestSimpleDwarvenUrgrosh()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestMagicalDwarvenUrgrosh()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new MagicWeapon(doubleWeapon.FirstWeaponPart, 1);
			new MagicWeapon(doubleWeapon.SecondWeaponPart, 1);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoAdamantine()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponAdamantine(doubleWeapon.FirstWeaponPart);
			new WeaponAdamantine(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoAlchemicalSilver()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponAlchemicalSilver(doubleWeapon.FirstWeaponPart);
			new WeaponAlchemicalSilver(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoColdIron()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponColdIron(doubleWeapon.FirstWeaponPart);
			new WeaponColdIron(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoDarkwood()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponDarkwood(doubleWeapon.FirstWeaponPart);
			new WeaponDarkwood(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoMithral()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponMithral(doubleWeapon.FirstWeaponPart);
			new WeaponMithral(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestUrgroshDroppedIntoSteel()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			new WeaponSteel(doubleWeapon.FirstWeaponPart);
			new WeaponSteel(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestMasterworkClass()
		{
			var dagger = TempWeaponDictionary.GetWeaponData("Dagger");
			var testDagger = new GenericWeapon(dagger, null);

			MasterworkWeapon.MakeMasterwork(testDagger);

			Approvals.Approve(testDagger);
		}

		[TestMethod]
		public void TestMasterworkClassOnDoubleWeapon()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			MasterworkWeapon.MakeMasterwork(doubleWeapon);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestMasterworkClassOnOneHead()
		{
			var urgroshDataA = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh A");
			var urgroshDataB = TempWeaponDictionary.GetWeaponData("Dwarven Urgrosh B");

			var doubleWeapon = new GenericDoubleWeapon(urgroshDataA, urgroshDataB, null);

			MasterworkWeapon.MakeMasterwork(doubleWeapon.SecondWeaponPart);

			Approvals.Approve(doubleWeapon);
		}

		[TestMethod]
		public void TestCorrectCostWithCalculationCostsClass()
		{
			// Why am I calculating all the prices at once?
			// here should be a price check once the item is completed.
			// A second check once it is made masterwork
			// Again once a special material has been added
			// Again once an enhancement bonus has been added
			// Again when a magical ability is added.
			//
			// +1 Cold Iron Dagger
			//ItemCost = BasePrice + externalMasterworkCost + SpecialMaterialCost;
			//TotalWeaponCost = ItemCost + EnchantmentCost;
			
			var weaopn = new GenericWeapon(null, null);
			var coldIron = new WeaponColdIron(weaopn);
			var magical = new MagicWeapon(weaopn, 1);

			WeaponPriceCalculations.SetMasterworkCost(300);
			WeaponPriceCalculations.SetBasePrice(2);
			coldIron.CalculateColdIronCost(WeaponPriceCalculations.GetBasePriceCost());
			WeaponPriceCalculations.SetMagicalCost(magical.TotalEnhancementCost);

			weaopn.BasePrice = WeaponPriceCalculations.GetBasePriceCost();
			weaopn.externalMasterworkCost = WeaponPriceCalculations.GetMasterworkCost();
			weaopn.SpecialMaterialCost = WeaponPriceCalculations.GetSpecialMaterialCost();
			weaopn.EnchantmentCost = WeaponPriceCalculations.GetMagicalEnchantmentCost();

			weaopn.TotalWeaponCost = WeaponPriceCalculations.DetermineTotalWeaponCost();

			var failMessage = "This test is poorly written and does not express the calculation control flow needed adequately.";
			Approvals.Approve(failMessage);
		}
	}
}