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
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponSmithTests
	{
		[TestMethod]
		public void TestSimpleDaggerObject()
		{
			GenericDagger simpleDagger = new GenericDagger(new WeaponData(), null);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			GenericDagger simpleDagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			GenericDagger simpleDagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			GenericDagger simpleDagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			simpleDagger.IsMasterworkQualifier(true);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			dagger.IsMasterworkQualifier(true);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			dagger.IsMasterworkQualifier(true);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			GenericDagger mediumDagger = new GenericDagger("Dagger", "Small", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			GenericDagger fineDagger = new GenericDagger("Dagger", "Fine", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			GenericDagger colossalDagger = new GenericDagger("Dagger", "Colossal", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			GenericDagger largeDagger = new GenericDagger("Dagger", "Large", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			GenericDagger faeDagger = new GenericDagger("Dagger", "Diminutive", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			GenericDagger dagger;
			List<GenericDagger> inventory = new List<GenericDagger>();
			var displayInventory = new StringBuilder();

			int daggerQuantity = 5;

			for (int i = 0; i <= daggerQuantity; i++)
			{
				dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
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
			List<GenericDagger> inventory = new List<GenericDagger>();
			var displayInventory = new StringBuilder();

			GenericDagger faeDagger = new GenericDagger("Dagger", "Fine", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponAlchemicalSilver(faeDagger);
			faeDagger.WeaponName = String.Format("Faerie's Dagger ({0}{3} ({1}){2})\n", faeDagger.WeaponName, faeDagger.WeaponSize, faeDagger.MasterWorkLabel, faeDagger.MaterialName);
			faeDagger.AdditionalText = "Dagger left by a faerie as a token of friendship.";

			GenericDagger ogreDagger = new GenericDagger("Dagger", "Large", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponColdIron(ogreDagger);
			ogreDagger.WeaponName = String.Format("Tooth ({0})", ogreDagger.WeaponName);
			ogreDagger.AdditionalText = "Dagger of an Ogre Mage chief taken from its body after a vicious fight.";

			GenericDagger expensiveDagger = new GenericDagger("Dagger", "Medium", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
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
			GenericDagger dagger = new GenericDagger("Dagger", "Medium", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			GenericDagger dagger = new GenericDagger("Dagger", "Medium", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);

			GenericDagger smallDagger = new GenericDagger("Dagger", "Small", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon smallMagicDagger = new MagicWeapon(smallDagger, 2);

			GenericDagger largeDagger = new GenericDagger("Dagger", "Large", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon largeMagicDagger = new MagicWeapon(largeDagger, 3);

			GenericDagger tinyDagger = new GenericDagger("Dagger", "Tiny", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon tinyMagicDagger = new MagicWeapon(tinyDagger, 4);

			GenericDagger hugeDagger = new GenericDagger("Dagger", "Huge", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon hugeMagicDagger = new MagicWeapon(hugeDagger, 5);

			List<GenericDagger> inventory = new List<GenericDagger>();
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
			GenericDagger dagger = new GenericDagger("Dagger", null, "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			GenericDagger dagger = new GenericDagger("Dagger", "Huge", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			dagger.AdditionalText = "Brawn carried this boot knife whenever he went into the wilderness to work. While not fashioned for combat,\n\t\tBrawn has successfully defended himself many times with this blade.";
			new WeaponAdamantine(dagger);
			new MagicWeapon(dagger, 3);
			dagger.WeaponName = String.Format("Brawn's Insurance ({1})", dagger.PlusEnhancementBonus, dagger.WeaponName);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAddFlamingEnhancement()
		{
			GenericDagger flameDagger = new GenericDagger("Dagger", "Medium", "Melee", "Light Weapon", "1d4", "19-20", "x2", "Piercing or Slashing", 10, 2, 1, 2, "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.");
			MagicWeapon magicWeapon = new MagicWeapon(flameDagger, 1);
			magicWeapon.EnchantWeaponWith("Flaming");

			Approvals.Approve(flameDagger);
		}
	}
}
