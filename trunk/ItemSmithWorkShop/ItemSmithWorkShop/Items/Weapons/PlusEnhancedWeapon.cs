﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.MaterialTypes;

namespace ItemSmithWorkShop.Items.Weapons
{
	public class PlusEnhancedWeapon : IWeapon
	{
		// In addition to the weapon and forged weapon properties A PlusEnchantedWeapon has
		//		A Plus to attack and damage
		//		A cost to create based on the plus of the enchantment
		//		The plus modifier goes at the beginning of the name
		//		A change to hardness and hit points
		//		A magic aura
		//		A chance that it glows

		//	For Creation purposes:
		//		A minimum caster level
		//		Time to create
		//		Gold and Xp cost to create in addition to the plus cost
		//		A raw material cost 
		//		Choice to make it glow
		//		Feats required
		
		ForgedWeapon forgedWeapon;

		private string lightgenerationInfo = string.Format("This weapon generates light as per the \"Light\" spell.{0}\tThis weapon's light can't be conealed when drawn,{0}\tnor can its light be shut off.", Environment.NewLine);
		private string noLightGeneration = "This weapon does not generate light.";
		private double creationDaysMultiplier = 0.001;
		private double creationCostMultiplier = 0.5;
		private double creationXpCost = 0.04;

		// Magic Properties
		private double enhancementCostMultiplier = 2000;
		private double enhancementHardmessMultiplier = 2;
		private double enhancementHitPointMultiplier = 10;

		public double PlusEnhancement { get; private set; }

		private double baseEnhancementCost;
		public double BaseEnhancementCost
		{
			get
			{
				return baseEnhancementCost;
			}
			set
			{
				baseEnhancementCost = (Math.Pow(value, 2) * enhancementCostMultiplier);
			}
		}

		public double BaseItemCost { get; private set; }

		public double AdditionalEnchantmentCost { get; private set; }

		public string ToHitModifier { get; private set; }

		// Weapon
		public string GivenName { get; private set; }

		public double BonusDamage { get; private set; }

		public string ComponentName { get; private set; }

		public string Proficiency { get; private set; }

		public string WeaponUse { get; private set; }

		public string WeaponCategory { get; private set; }

		public string WeaponSubCategory { get; private set; }

		public string WeaponSize { get; private set; }

		public string WeaponName { get; private set; }

		public double WeaponCost { get; private set; }

		public string Damage { get; private set; }

		public double ThreatRangeLowerBound { get; private set; }

		public string ThreatRange { get; private set; }

		public string CriticalDamage { get; private set; }

		public double Weight { get; private set; }

		public string DamageType { get; private set; }

		public double Hardness { get; private set; }

		public double HitPoints { get; private set; }

		public string SpecialInfo { get; private set; }

		public bool IsMasterwork { get; private set; }

		public double RangeIncrement { get; private set; }

		public double MaxRange { get; private set; }

		// Creation Properties

		private double minimumCasterLevel;
		public double MinimumCasterLevel
		{
			get { return minimumCasterLevel; }
			private set
			{ 
				minimumCasterLevel = (value * 3);
				if (minimumCasterLevel < 6)
				{
					MagicAura = "Faint";
				}
				else if (minimumCasterLevel < 12)
				{
					MagicAura = "Moderate";
				}
				else if (minimumCasterLevel < 20)
				{
					MagicAura = "Strong";
				}
				else
				{
					MagicAura = "Overwhelming";
				}
			}
		}

		public string MagicAura { get; private set; }

		private bool lightGeneraton;
		public string GeneratesLight
		{
			get
			{
				if (lightGeneraton)
				{
					return lightgenerationInfo;
				}
				return noLightGeneration;
			}
		}

		public string RequiredFeats { get { return "Craft Magic Arms and Armor"; } }

		public double CreationTime
		{
			get
			{
				return BaseEnhancementCost * creationDaysMultiplier;
			}
		}

		public double RawMaterialCost 
		{
			get
			{
				return BaseItemCost + (BaseEnhancementCost * creationCostMultiplier);
			}
		}

		public double CreationXpCost 
		{ 
			get 
			{ 
				return BaseEnhancementCost * creationXpCost; 
			} 
		}

		public PlusEnhancedWeapon(IWeapon weapon, double plusEnhancement)
		{
			forgedWeapon = QualifyWeapon(weapon);
			PlusEnhancement = ValidatePlusEnhancement(plusEnhancement);
			BaseEnhancementCost = PlusEnhancement;

			BaseItemCost = forgedWeapon.WeaponCost;

			GivenName = forgedWeapon.GivenName;
			WeaponName = BuildName();
			ComponentName = forgedWeapon.ComponentName;
			Proficiency = forgedWeapon.Proficiency;
			WeaponUse = forgedWeapon.WeaponUse;
			WeaponCategory = forgedWeapon.WeaponCategory;
			WeaponSubCategory = forgedWeapon.WeaponSubCategory;
			WeaponSize = forgedWeapon.WeaponSize;
			AdditionalEnchantmentCost = forgedWeapon.AdditionalEnchantmentCost;
			WeaponCost = CalculateWeaponCost();
			ToHitModifier = string.Format("+{0}", PlusEnhancement);
			Damage = forgedWeapon.Damage;
			BonusDamage = (forgedWeapon.DamageBonus + PlusEnhancement);
			ThreatRangeLowerBound = forgedWeapon.ThreatRangeLowerBound;
			ThreatRange = forgedWeapon.ThreatRange;
			CriticalDamage = forgedWeapon.CriticalDamage;
			RangeIncrement = forgedWeapon.RangeIncrement;
			MaxRange = forgedWeapon.MaxRange;
			DamageType = forgedWeapon.DamageType;
			Weight = forgedWeapon.Weight;
			Hardness = CalculateHardness();
			HitPoints = CalculateHitPoints();
			SpecialInfo = forgedWeapon.SpecialInfo;
			IsMasterwork = forgedWeapon.IsMasterwork;

			// Creation
			MinimumCasterLevel = PlusEnhancement;
		}

		private ForgedWeapon QualifyWeapon(IWeapon weapon)
		{
			if (!weapon.IsMasterwork && (weapon is ForgedWeapon))
			{
				return new ForgedWeapon(weapon as ForgedWeapon, new Masterwork());
			}
			else if (!weapon.IsMasterwork)
			{
				return new ForgedWeapon(weapon, new Masterwork());
			}
			return weapon as ForgedWeapon;
		}

		private double ValidatePlusEnhancement(double plusEnhancement)
		{
			// There may be a need to notify the user that values out of bounds are placed to the nearest in bound value; 1 or 5, respectively
			if (plusEnhancement < 1)
			{
				return 1;
			}
			else if (plusEnhancement > 5)
			{
				return 5;
			}
			return plusEnhancement;
		}

		private string BuildName()
		{
			return string.Format("+{0} {1}", PlusEnhancement, TrimComponentName());
		}

		private string TrimComponentName()
		{
			string masterwork = "Masterwork ";
			if (forgedWeapon.WeaponName.Contains(masterwork))
			{
				return forgedWeapon.WeaponName.Remove(0, masterwork.Length);
			}
			else
			{
				return forgedWeapon.WeaponName;
			}
		}
	
		private double CalculateWeaponCost()
		{
			return BaseItemCost + AdditionalEnchantmentCost + BaseEnhancementCost;
		}

		private double CalculateHardness()
		{
			// Per the errata:
			//		"Each +1 of enhancement bonus adds 2 to a weapon's or shield's hardness"
			// The enhancement bonus of a weapon is the +1 to +5 added to the to hit and damage of a weapon only.

			return forgedWeapon.Hardness + (PlusEnhancement * enhancementHardmessMultiplier);
		}

		private double CalculateHitPoints()
		{
			// Per the errata:
			//		"Each +1 of enhancement bonus adds 10 to a weapon's or shield's hit points"
			// The enhancement bonus of a weapon is the +1 to +5 added to the to hit and damage of a weapon only.

			return forgedWeapon.HitPoints + (PlusEnhancement * enhancementHitPointMultiplier);
		}

		private string DisplayDamage()
		{
			if (BonusDamage < 0)
			{
				return string.Format("{0} {1}", Damage, BonusDamage);
			}
			else if (BonusDamage > 0)
			{
				return string.Format("{0} +{1}", Damage, BonusDamage);
			}
			return Damage;
		}

		public void NameWeapon(string name)
		{
			GivenName = name;
		}

		public void EnableLightGeneration()
		{
			lightGeneraton = true;
		}

		public override string ToString()
		{
			return string.Format("Given Name: '{1}'{0}Special Components: '{2}'{0}Weapon Name: '{3}'{0}This Weapon is Masterwork Quality: '{4}'{0}Weaopn Proficiency: '{5}'{0}Weapon Category: '{6}, {7}'{0}Weapon Size: '{8}'{0}Weapon Cost: '{9} gold pieces'{0}Extra Cost When Made Magical: '{10} gold pieces'{0}To Hit Bonus: '{11}'{0}Damage: '{12} [{13}/{14}] {15}'{0}Range Increment: '{16} feet [{17} feet max]'{0}Weight: '{18} pounds'{0}Hardness: '{19}'{0}Hit Points: '{20}'{0}Special: {21}{0}{0}Creation Requirements{0}Required Feats: '{22}'{0}Minimum Caster Level: '{23}'{0}Creation Time: '{24} days'{0}Raw Material Cost: '{25} gold pieces'{0}Experience Point Cost: '{26} xp'{0}Magic Aura: '{27}'{0}Light Generation: {28}",
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
								DisplayDamage(),
								ThreatRange,
								CriticalDamage,
								DamageType,
								RangeIncrement,
								MaxRange,
								Weight,
								Hardness,
								HitPoints,
								SpecialInfo,
								RequiredFeats,
								MinimumCasterLevel,
								CreationTime,
								RawMaterialCost,
								CreationXpCost,
								MagicAura,
								GeneratesLight
								);
								
		}
	}
}
