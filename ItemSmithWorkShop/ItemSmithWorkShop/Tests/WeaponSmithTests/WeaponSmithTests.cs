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
			GenericWeapon simpleDagger = new GenericWeapon(new WeaponData(), null);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteel()
		{
			GenericWeapon simpleDagger = new GenericWeapon(new WeaponData(), null);
			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoSteelProperlyNamed()
		{
			GenericWeapon simpleDagger = new GenericWeapon(new WeaponData(), null);
			simpleDagger.WeaponName = "Slashy Blade of Happiness";

			new WeaponSteel(simpleDagger);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestMasterworkDagger()
		{
			GenericWeapon simpleDagger = new GenericWeapon(new WeaponData(), null);
			simpleDagger.IsMasterworkQualifier(true);

			Approvals.Approve(simpleDagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAdamantine()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponAdamantine(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoDarkwood()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponDarkwood(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoColdIron()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoColdIron()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			dagger.IsMasterworkQualifier(true);
			new WeaponColdIron(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoMithral()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoMithral()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			dagger.IsMasterworkQualifier(true);
			new WeaponMithral(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestDaggerDroppedIntoAlchemicalSilver()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMasterworkDaggerDroppedIntoAlchemicalSilver()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			dagger.IsMasterworkQualifier(true);
			new WeaponAlchemicalSilver(dagger);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestSmallSizeDagger()
		{
			GenericWeapon mediumDagger = new GenericWeapon(new WeaponData(), "Small");

			Approvals.Approve(mediumDagger);
		}

		[TestMethod]
		public void TestFineSizeDagger()
		{
			GenericWeapon fineDagger = new GenericWeapon(new WeaponData(), "Fine");

			Approvals.Approve(fineDagger);
		}

		[TestMethod]
		public void TestColossalSizeDagger()
		{
			GenericWeapon colossalDagger = new GenericWeapon(new WeaponData(), "Colossal");

			Approvals.Approve(colossalDagger);
		}

		[TestMethod]
		public void TestLargeDagger()
		{
			GenericWeapon largeDagger = new GenericWeapon(new WeaponData(), "Large");

			Approvals.Approve(largeDagger);
		}

		[TestMethod]
		public void TestProperNamedFineSizeDagger()
		{
			GenericWeapon faeDagger = new GenericWeapon(new WeaponData(), "Diminutive");
			new WeaponAdamantine(faeDagger);
			faeDagger.WeaponName = String.Format("Sera's Bite ({0})", faeDagger.WeaponName);
			faeDagger.AdditionalText = "Sera forged this dagger for revenge against those that ruined her home.";

			Approvals.Approve(faeDagger);
		}

		[TestMethod]
		public void TestMultipleDaggers()
		{
			GenericWeapon dagger;
			List<GenericWeapon> inventory = new List<GenericWeapon>();
			var displayInventory = new StringBuilder();

			int daggerQuantity = 5;

			for (int i = 0; i <= daggerQuantity; i++)
			{
				dagger = new GenericWeapon(new WeaponData(), null);
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
			List<GenericWeapon> inventory = new List<GenericWeapon>();
			var displayInventory = new StringBuilder();

			GenericWeapon faeDagger = new GenericWeapon(new WeaponData(), "Fine");
			new WeaponAlchemicalSilver(faeDagger);
			faeDagger.WeaponName = String.Format("Faerie's Dagger ({0}{3} ({1}){2})\n", faeDagger.WeaponName, faeDagger.WeaponSize, faeDagger.MasterWorkLabel, faeDagger.MaterialName);
			faeDagger.AdditionalText = "Dagger left by a faerie as a token of friendship.";

			GenericWeapon ogreDagger = new GenericWeapon(new WeaponData(), "Large");
			new WeaponColdIron(ogreDagger);
			ogreDagger.WeaponName = String.Format("Tooth ({0})", ogreDagger.WeaponName);
			ogreDagger.AdditionalText = "Dagger of an Ogre Mage chief taken from its body after a vicious fight.";

			GenericWeapon expensiveDagger = new GenericWeapon(new WeaponData(), "Medium");
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
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);
			magicDagger.IsGlowingWeapon(true);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestMagicalWeapons()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), "Medium");
			MagicWeapon magicDagger = new MagicWeapon(dagger, 1);

			GenericWeapon smallDagger = new GenericWeapon(new WeaponData(), "Small");
			MagicWeapon smallMagicDagger = new MagicWeapon(smallDagger, 2);

			GenericWeapon largeDagger = new GenericWeapon(new WeaponData(), "Large");
			MagicWeapon largeMagicDagger = new MagicWeapon(largeDagger, 3);

			GenericWeapon tinyDagger = new GenericWeapon(new WeaponData(), "Tiny");
			MagicWeapon tinyMagicDagger = new MagicWeapon(tinyDagger, 4);

			GenericWeapon hugeDagger = new GenericWeapon(new WeaponData(), "Huge");
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
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), null);
			new WeaponColdIron(dagger);
			new MagicWeapon(dagger, 1);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestNamedMagicWeapon()
		{
			GenericWeapon dagger = new GenericWeapon(new WeaponData(), "Huge");
			dagger.AdditionalText = "Brawn carried this boot knife whenever he went into the wilderness to work. While not fashioned for combat,\n\t\tBrawn has successfully defended himself many times with this blade.";
			new WeaponAdamantine(dagger);
			new MagicWeapon(dagger, 3);
			dagger.WeaponName = String.Format("Brawn's Insurance ({1})", dagger.PlusEnhancementBonus, dagger.WeaponName);

			Approvals.Approve(dagger);
		}

		[TestMethod]
		public void TestAddFlamingEnhancement()
		{
			GenericWeapon flameDagger = new GenericWeapon(new WeaponData(), "Medium");
			MagicWeapon magicWeapon = new MagicWeapon(flameDagger, 1);
			magicWeapon.EnchantWeaponWith("Flaming");

			Approvals.Approve(flameDagger);
		}
	}
}
