﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Weapons.Data;
using ItemSmithWorkShop.Weapons.Interfaces;

namespace ItemSmithWorkShop.Weapons
{
	public class PhbWeapon : IWeapon
	{
		// A weapon has several properties
		//		Proficiency category: simple, martial, and exotic
		//		Use: melee or ranged (can be grouped with designation?)
		//		Designation: light, one-handed, and two-handed
		//			subcategory: reach, double, thrown, projectile, ammunition
		//		Weapon size category: Which size creature can use it; small, medium, large
		// In addition to these properties, a weapon has "qualities"
		//		Cost: the weapon's value
		//		Damage: How many dice damage it does
		//		Threat range: The critical threat range
		//		Critical damage: The damage multiplier for a critical hit.
		//		Range increment: The distance a projectile can travel with no penalty.
		//			Max range: the maximum distance a projectile can travel
		//		Weight: The item's weight
		//		Damage Type: bludgeoning, piercing, slashing
		//		Special: A special feature of the weapon

		// Where the data comes from is out of scope for the time being.

		private WeaponTemplate weaponTemplate;

		private double _maximumRange;
		private double _rangeIncrement;

		public string Proficiency { get; private set; }
		public string WeaponUse { get; private set; }
		public string WeaponCategory { get; private set; }
		public string WeaponSubCategory { get; private set; }
		public string WeaponSize { get; private set; }

		public string WeaponName { get; private set; }
		public double WeaponCost { get; private set; }
		public string Damage { get; private set; }
		public string ThreatRange { get; private set; }
		public string CriticalDamage { get; private set; }

		public double RangeIncrement
		{ get { return _rangeIncrement; }
			private set 
			{ 
				_rangeIncrement = value;
				if (WeaponUse == "Ranged" || WeaponSubCategory.Contains("Projectile"))
				{
					_maximumRange = _rangeIncrement * 10;
				}
				else if (WeaponSubCategory.Contains("Thrown"))
				{
					_maximumRange = _rangeIncrement * 5;
				}
				else
				{
					_maximumRange = 0;
				}
			}
		}
		
		public double MaxRange { get { return _maximumRange; } }
		public double Weight { get; private set; }
		public string DamageType { get; private set; }
		public string SpecialInfo { get; private set; }

		public string GivenName { get; private set; }

		public PhbWeapon(string weaponKey)
		{
			weaponTemplate = ItemData.RetrieveWeaponTemplate(weaponKey);

			WeaponName = weaponTemplate.weaponName;
			Proficiency = weaponTemplate.Proficiency;
			WeaponUse = weaponTemplate.WeaponUse;
			WeaponCategory = weaponTemplate.WeaponCategory;
			WeaponSubCategory = weaponTemplate.WeaponSubCategory;
			WeaponSize = weaponTemplate.WeaponSize;
			WeaponCost = weaponTemplate.WeaponCost;
			Damage = weaponTemplate.Damage;
			ThreatRange = weaponTemplate.ThreatRange;
			CriticalDamage = weaponTemplate.CriticalDamage;
			RangeIncrement = weaponTemplate.RangeIncrement;
			Weight = weaponTemplate.Weight;
			DamageType = weaponTemplate.DamageType;
			SpecialInfo = weaponTemplate.specialInfo;
		}

		public void NameWeapon(string name)
		{
			GivenName = name;
		}

		public override string ToString()
		{
			return string.Format
				("Given Name: '{15}'{0}Weapon: '{1}'{0}Weapon Proficiency: '{2}'{0}Weapon Category: '{3}, {4}'{0}Weapon Size: '{5}'{0}Weapon Cost: '{6}' gp{0}Damage: '{7}' [{8}/{9}] {10}{0}Range Increment: '{11} feet ['{12}' feet max]'{0}Weight: '{13} pounds'{0}Special: {14}",
				Environment.NewLine, 
				WeaponName, 
				Proficiency, 
				WeaponCategory, 
				WeaponSubCategory, 
				WeaponSize, 
				WeaponCost, 
				Damage, 
				ThreatRange, 
				CriticalDamage, 
				DamageType, 
				RangeIncrement, 
				MaxRange, 
				Weight,
				SpecialInfo,
				GivenName
				);
		}
	}
}
