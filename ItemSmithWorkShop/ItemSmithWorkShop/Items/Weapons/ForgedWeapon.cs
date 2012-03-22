using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.MaterialTypes;

namespace ItemSmithWorkShop.Items.Weapons
{
	// A forged weapon needs to keep track of its weapon attributes.
	// A forged weapon also needs to keep track of its material component parts.
	// 
	public class ForgedWeapon : IWeapon
	{
		public string GivenName
		{
			get;
			private set;
		}

		public string WeaponName
		{
			get;
			private set;
		}

		public string Proficiency 
		{ 
			get;
			private set;
		}

		public string WeaponUse 
		{
			get;
			private set;
		}

		public string WeaponCategory
		{
			get;
			private set;
		}

		public string WeaponSubCategory
		{
			get;
			private set;
		}

		public string WeaponSize
		{
			get;
			private set;
		}

		public double WeaponCost
		{
			get;
			private set;
		}

		public string ToHitModifier
		{
			get;
			private set;
		}

		public string Damage
		{
			get;
			private set;
		}

		public double ThreatRangeLowerBound
		{
			get;
			private set;
		}

		public string ThreatRange
		{
			get;
			private set;
		}

		public string CriticalDamage
		{
			get;
			private set;
		}

		public double RangeIncrement
		{
			get;
			private set;
		}

		public double MaxRange
		{
			get;
			private set;
		}

		public double Weight 
		{
			get;
			private set;
		}

		public string DamageType
		{
			get;
			private set;
		}

		public string SpecialInfo
		{
			get;
			private set;
		}

		public string ComponentName
		{
			get;
			private set;
		}

		public bool IsMasterwork
		{
			get;
			private set;
		}

		public double AdditionalEnchantmentCost 
		{
			get;
			private set;
		}

		public ForgedWeapon(IWeapon weapon, IMaterialComponent component)
		{
			//weapon = weaponPart;
			//component = componentPart;

			AdditionalEnchantmentCost = component.GetAdditionalEnchantmentCost();

			ComponentName = component.ComponentName;

			CriticalDamage = weapon.CriticalDamage;

			if (component is AlchemicalSilver || component is MasterworkAlchemicalSilver)
			{
				Damage = weapon.Damage + " -1";
			}
			else
			{
				Damage = weapon.Damage;
			}

			DamageType = weapon.DamageType;
			GivenName = weapon.GivenName;
			IsMasterwork = component.VerifyMasterwork(weapon);
			MaxRange = weapon.MaxRange;
			Proficiency = weapon.Proficiency;
			RangeIncrement = weapon.RangeIncrement;
			SpecialInfo = component.AppendSpecialInfo(weapon);
			ThreatRange = weapon.ThreatRange;
			WeaponCategory = weapon.WeaponCategory;
			WeaponCost = component.ApplyCostModifier(weapon);
			WeaponName = string.Format("{0} {1}", component.ComponentName, weapon.WeaponName);
			WeaponSize = weapon.WeaponSize;
			WeaponSubCategory = weapon.WeaponSubCategory;
			WeaponUse = weapon.WeaponUse;
			Weight = component.ApplyWeightModifer(weapon);
			ToHitModifier = component.ApplyToHitModifier();
		}

		public void NameWeapon(string name)
		{
			GivenName = name;
		}

		public override string ToString()
		{
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
									ToHitModifier,
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
