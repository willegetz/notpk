using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.Weapons
{
	// A forged weapon needs to keep track of its weapon attributes.
	// A forged weapon also needs to keep track of its material component parts.
	// 
	public class ForgedWeapon : IWeapon
	{
		public string givenName;
		public string GivenName
		{
			get
			{
				return givenName;
			}
			private set
			{
				givenName = value;
			}
		}

		public string weaponName;
		public string WeaponName
		{
			get
			{
				return weaponName;
			}
			private set
			{
				weaponName = value;
			}
		}

		public string proficiency;
		public string Proficiency 
		{ 
			get
			{
				return proficiency;
			}
			private set
			{
				proficiency = value;
			}
		}

		public string weaponUse;
		public string WeaponUse 
		{ 
			get
			{
				return weaponUse;
			}
			private set
			{
				weaponUse = value;
			}
		}

		public string weaponCategory;
		public string WeaponCategory
		{
			get
			{
				return weaponCategory;
			}
			private set
			{
				weaponCategory = value;
			}
		}

		public string weaponSubCategory;
		public string WeaponSubCategory
		{
			get
			{
				return weaponSubCategory;
			}
			private set
			{
				weaponSubCategory = value;
			}
		}

		public string weaponSize;
		public string WeaponSize
		{
			get
			{
				return weaponSize;
			}
			private set
			{
				weaponSize = value;
			}
		}

		public double weaponCost;
		public double WeaponCost
		{
			get
			{
				return weaponCost;
			}
			private set
			{
				weaponCost = value;
			}
		}

		public string toHitModifier;
		public string ToHitMidifier
		{
			get
			{
				return toHitModifier;
			}
			private set
			{
				toHitModifier = value;
			}
		}

		public string damage;
		public string Damage
		{
			get
			{
				return damage;
			}
			private set
			{
				damage = value;
			}
		}

		public double threatRangeLowerBound;
		public double ThreatRangeLowerBound
		{
			get
			{
				return threatRangeLowerBound;
			}
			private set
			{
				threatRangeLowerBound = value;
			}
		}

		public string threatRange;
		public string ThreatRange
		{
			get
			{
				return threatRange;
			}
			private set
			{
				threatRange = value;
			}
		}

		public string criticalDamage;
		public string CriticalDamage
		{
			get
			{
				return criticalDamage;
			}
			private set
			{
				criticalDamage = value;
			}
		}

		public double rangeIncrement;
		public double RangeIncrement
		{
			get
			{
				return rangeIncrement;
			}
			private set
			{
				rangeIncrement = value;
			}
		}

		public double maxRange;
		public double MaxRange
		{
			get
			{
				return maxRange;
			}
			private set
			{
				maxRange = value;
			}
		}

		public double weight;
		public double Weight 
		{
			get
			{
				return weight;
			}
			private set
			{
				weight = value;
			}
		}

		public string damageType;
		public string DamageType
		{
			get
			{
				return damageType;
			}
			private set
			{
				damageType = value;
			}
		}

		public string specialInfo;
		public string SpecialInfo
		{
			get
			{
				return specialInfo;
			}
			private set
			{
				specialInfo = value;
			}
		}

		public string componentName;
		public string ComponentName
		{ 
			get
			{
				return componentName;
			}
			private set
			{
				componentName = value;
			}
		}

		public bool isMasterwork;
		public bool IsMasterwork
		{ 
			get
			{
				return isMasterwork;
			}
			private set
			{
				isMasterwork = value;
			}
		}

		public double additionalEnchantmentCost;
		public double AdditionalEnchantmentCost 
		{ 
			get
			{
				return additionalEnchantmentCost;
			}
			private set
			{
				additionalEnchantmentCost = value;
			}
		}

		public ForgedWeapon()
		{

		}

		public void NameWeapon(string name)
		{
			GivenName = name;
		}

		public override string ToString()
		{
			//"
			return string.Format("Given Name: '{1}'{0}Special Components: '{2}'{0}Weapon Name: '{3}'{0}This Weapon is Masterwork Quality: '{4}'{0}Weaopn Proficiency: '{5}'{0}Weapon Category: '{6}, {7}'{0}Weapon Size: '{8}'{0}Weapon Cost: '{9}' gold pieces{0}Extra Cost When Made Magical: '{10}' gold pieces{0}To Hit Bonus: '{11}'{0}Damage: '{12}' [{13}/{14}] {15}{0}Range Increment: '{16} feet ['{17}' feet max]'{0}Weight: '{18} pounds'{0}Special: {19}",
									Environment.NewLine, 
									GivenName, 
									ComponentName, 
									WeaponName,
									IsMasterwork,
									Proficiency,
									WeaponCategory,
									WeaponSubCategory,
									WeaponSize,
									WeaponCost,
									AdditionalEnchantmentCost,
									ToHitMidifier,
									Damage, 
									ThreatRange, 
									CriticalDamage,
									DamageType,
									RangeIncrement,
									MaxRange,
									Weight,
									SpecialInfo
								);
		}
	}
}
