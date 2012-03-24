using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.MaterialTypes;

namespace ItemSmithWorkShop.Items.Weapons
{
	public class PlusEnchantedWeapon : IWeapon
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

		// MagicAura
		// MinimumCasterLevel
		// RequiredFeats
		// Glows
		// TimeToCreate
		// Creation XP Cost
		// Creation Raw Material Cost

		public PlusEnchantedWeapon(IWeapon weapon, double plusEnhancement)
		{
			forgedWeapon = QualifyWeapon(weapon);
			PlusEnhancement = plusEnhancement;
			BaseEnhancementCost = plusEnhancement;

			GivenName = forgedWeapon.GivenName;
			WeaponName = BuildName();
			Proficiency = forgedWeapon.Proficiency;
			WeaponUse = forgedWeapon.WeaponUse;
			WeaponCategory = forgedWeapon.WeaponCategory;
			WeaponSubCategory = forgedWeapon.WeaponSubCategory;
			WeaponSize = forgedWeapon.WeaponSize;
			WeaponCost = CalculateWeaponCost();
			ToHitModifier = string.Format("+{0}", plusEnhancement);
			Damage = forgedWeapon.Damage;
			BonusDamage = forgedWeapon.DamageBonus;
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
		}

		private ForgedWeapon QualifyWeapon(IWeapon weapon)
		{
			if (!(weapon is ForgedWeapon))
			{
				return new ForgedWeapon(weapon, new Masterwork());
			}
			else if ((weapon is ForgedWeapon) && !weapon.IsMasterwork)
			{
				
				return MasterworkVersionOfComponent((weapon as ForgedWeapon));
			}
			else
			{
				return weapon as ForgedWeapon;
			}
		}

		private ForgedWeapon MasterworkVersionOfComponent(ForgedWeapon weapon)
		{
			if (weapon.ComponentName == "Cold Iron")
			{
				return new ForgedWeapon(weapon, new MasterworkColdIron());
			}
			else if (weapon.ComponentName == "Alchemical Silver")
			{
				return new ForgedWeapon(weapon, new MasterworkAlchemicalSilver());
			}
			else return weapon;
		}

		private string BuildName()
		{
			return string.Format("+{0}{1}", PlusEnhancement, TrimComponentName());
		}

		private string TrimComponentName()
		{
			string masterwork = "Masterwork ";
			if (forgedWeapon.ComponentName.Contains("Masterwork"))
			{
				return forgedWeapon.WeaponName.Remove(0, masterwork.Length - 1);
			}
			else
			{
				return forgedWeapon.WeaponName;
			}
		}
	
		private double CalculateWeaponCost()
		{
			return forgedWeapon.WeaponCost + forgedWeapon.AdditionalEnchantmentCost + BaseEnhancementCost;
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

		public void NameWeapon(string name)
		{
			GivenName = name;
		}
	}
}
