﻿using System;
using ApprovalTests.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests.Reporters;
using Approvals = ApprovalTests.Approvals;

namespace ItemSmith
{

	public class MockWeapon : BaseWeapon
	{
		public MockWeapon()
		{
			GetWeaponStatistics(WeaponName, WeaponProficiency, WeaponCategory, WeaponAttackType, WeaponCost, CurrencyType, WeaponToHitModifier, WeaponBaseDamage, WeaponThreatRange, WeaponCriticalDamage, WeaponWeight, WeaponDamageType);
		}

		public new string WeaponName = "Dagger";
		public new string WeaponProficiency = "Simple";
		public new string WeaponCategory = "Light";
		public new string WeaponAttackType = "Melee";
		public new decimal WeaponCost = 2M;
		public new string CurrencyType = " gold pieces";
		public new int WeaponToHitModifier = 0;
		public new string WeaponBaseDamage = "1d4";
		public new string WeaponThreatRange = "19 - 20";
		public new string WeaponCriticalDamage = "x2";
		public new string WeaponWeight = "1 lb";
		public new string WeaponDamageType = "Piercing or Slashing";
	}

	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class WeaponTests
	{
		[TestMethod]
		public void TestItemName()
		{
			BaseWeapon baseWeapon = new MockWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;

			baseWeapon.GetWeaponStatistics(mockWeapon.WeaponName, "", "", "", 0, "", 0, "", "", "", "", "");
			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestDisplayWeaponStatistics()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestNotMasterworkWeapon()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;


			baseWeapon.IsMasterworkQualifier(false);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestMasterworkWeapon()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsMagicIsNotMasterworkWeapon()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(false);

			int combatEnhancement = 1;
			int totalEnhancementBonus = 1;
			baseWeapon.MagicWeapon(totalEnhancementBonus, combatEnhancement);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsGenericMagicWeapon()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 1;
			int totalEnhancementBonus = 1;
			baseWeapon.MagicWeapon(totalEnhancementBonus, combatEnhancement);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsMagicWeaponPlus2()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 2;
			int totalEnhancementBonus = 2;
			baseWeapon.MagicWeapon(totalEnhancementBonus, combatEnhancement);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsMagicWeaponPlus3()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 3;
			int totalEnhancementBonus = 3;
			baseWeapon.MagicWeapon(totalEnhancementBonus, combatEnhancement);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsMagicWeaponPlus5()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 5;
			int totalEnhancementBonus = 5;
			baseWeapon.MagicWeapon(totalEnhancementBonus, combatEnhancement);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestIsMagicWeaponPlus5TotalEnhancementIs10()
		{
			// New functionality is required:
			// Enhancement Bonus stops at +5
			// Effects can stack up to a +10 value
			//
			// Separate ToHit/Damage Modifier from enhancement bonus?
			//
			// Calculate value based on enhancement as before
			// Check to ensure that the ToHit/Damage Modifier does not exceed +5
			// Check to ensure that the ToHit/Damage Modifier does not exceed the enhancement bonus
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			// Magic weapon HAS to have a minimum of +1 before further enhancements can be added.
			int combatEnhancement = 5;
			int totalEnhancementBonus = 10;
			baseWeapon.MagicWeapon(combatEnhancement, totalEnhancementBonus);

			Approvals.Approve(baseWeapon);
		}

		// Magic Weapon Story:
		// A magic weapon must be masterwork
		// A magic weapon must have a minimum enhancement of +1
		// A magic weapon cannot exceed +5 bonus to hit/damage
		// A magic weapon cannot exceed +10 value of effects and bonus
		// A magic weapon may or may not glow
		// A magic weapon's cost is determined by the max enhancement:
		// 	(enhancement ^ 2) * 2000 = base cost
		// A magic weapon's caster level to create is the greater of the enhancement values of bonus to hit/damage and effects
		// 	enhancement Value * 3 = min caster level
		// A magic weapon takes one day per 1000 gp of base cost to create
		// 	base cost / 1000 = days to create

		[TestMethod]
		public void TestCasterLevelToCreatePlus3Item()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 3;
			int totalEnhancementBonus = 3;
			baseWeapon.MagicWeapon(combatEnhancement, totalEnhancementBonus);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestPlus3WeaponDaysToCreate()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 3;
			int totalEnhancementBonus = 3;
			baseWeapon.MagicWeapon(combatEnhancement, totalEnhancementBonus);

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestPlus1WeaponWithSpecialAbility()
		{
			BaseWeapon baseWeapon = new BaseWeapon();
			MockWeapon mockWeapon = new MockWeapon();
			baseWeapon = mockWeapon;
			baseWeapon.IsMasterworkQualifier(true);

			int combatEnhancement = 1;
			// Create the magic weapon special ability
			// special ability name
			string weaponSpecialAbilityName = "Flaming"; // Will go in front of the WeaponName, but after the +n.
			// Special ability base cost modifier
			int weaponSpecialAbilityCostModifier = 1; // Will be added to the combatEnhancement to determine base cost
			// Special ability combat modifier
			string specialAbilityDamageBonus = "+ 1d6"; // Will be amended to the WeaponDamage
			// Special ability damage type
			string specialAbilityDamageType = "Fire"; // Will be amended to DamageType
			// Special ability caster level
			int specialAbilityCasterLevel = 10; // Will be compared to the Enhancement Caster Level, higher will be used
			string specialAbilityCreationFeat = "Create Magic Arms and Armor"; // New field. Don't know where
			string specialAbilityCreationSpells = "Flame Blade, Flame Strike, or Fireball"; // New field. Don't know where
			string specialAbilitySchool = "Moderate Evocation"; //  New field. Don't know where
			// Special ability description
			string specialAbilityDescription = "Upon command, a flaming weapon is sheathed in fire. The fire does not harm the wielder. The effect remains until another command is given";
			// New field. Don't know where.

			Approvals.Approve(baseWeapon);
		}

		[TestMethod]
		public void TestDisplayPreRequisites()
		{	
			PreRequisites preRequisite = new PreRequisites("Simple", "Light", "Melee");

			Approvals.Approve(preRequisite);
		}

		[TestMethod]
		public void TestDisplayCost()
		{
			Cost cost = new Cost(2, "gold pieces");

			Approvals.Approve(cost);
		}

		[TestMethod]
		public void TestDisplayWeaponName()
		{
			Weapon weapon = new Weapon("Dagger");
			
			Approvals.Approve(weapon);
		}

		[TestMethod]
		public void TestDisplayPreRequisiteAndCost()
		{
			Weapon weapon = new Weapon("Dagger");
			PreRequisites preRequisites =  new PreRequisites("Simple", "Light", "Melee");
			Cost cost = new Cost(2, "gold pieces");

			DisplayWeapon displayWeapon = new DisplayWeapon(weapon, preRequisites, cost);

			Approvals.Approve(displayWeapon);
		}
	}

	public class DisplayWeapon
	{
		public string weaponName;
		public string weaponPreRequisites;
		public string weaponCost;

		public DisplayWeapon(Weapon weapon, PreRequisites preRequisites, Cost cost)
		{
			weaponName = weapon.DisplayWeaponName();
			weaponPreRequisites = preRequisites.DisplayPreRequisites();
			weaponCost = cost.DisplayWeaponCost();
		}

		public override string ToString()
		{
			return String.Format("{0}\r{1}\r{2}", weaponName, weaponPreRequisites, weaponCost);
		}


	}
}
