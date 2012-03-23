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
		public int PlusEnhancement { get; private set; }

		// Weapon
		public string GivenName { get; private set; }

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

		public string SpecialInfo { get; private set; }

		public bool IsMasterwork { get; private set; }

		public double RangeIncrement { get; private set; }

		public double MaxRange { get; private set; }

		public PlusEnchantedWeapon(IWeapon weapon, int plusEnhancement)
		{
			forgedWeapon = QualifyWeapon(weapon);
			PlusEnhancement = plusEnhancement;

			WeaponName = TrimComponentName(forgedWeapon);
			WeaponCost = CalculateWeaponCost(forgedWeapon, plusEnhancement);
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

		private string TrimComponentName(ForgedWeapon weapon)
		{
			string masterwork = "Masterwork ";
			if (weapon.ComponentName.Contains("Masterwork"))
			{
				return weapon.WeaponName.Remove(0, masterwork.Length);
			}
			else
			{
				return weapon.WeaponName;
			}
		}
	
		private double CalculateWeaponCost(ForgedWeapon forgedWeapon, int plusEnhancement)
		{
			throw new NotImplementedException();
		}
	}
}
