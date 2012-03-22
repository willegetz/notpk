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

		public string ComponentName { get; private set; }

		public string GivenName { get; private set; }

		public string Proficiency { get { throw new NotImplementedException(); } }

		public string WeaponUse { get { throw new NotImplementedException(); } }

		public string WeaponCategory { get { throw new NotImplementedException(); } }

		public string WeaponSubCategory { get { throw new NotImplementedException(); } }

		public string WeaponSize { get { throw new NotImplementedException(); } }

		public string WeaponName { get; private set; }

		public double WeaponCost { get { throw new NotImplementedException(); } }

		public string Damage { get { throw new NotImplementedException(); } }

		public double ThreatRangeLowerBound { get { throw new NotImplementedException(); } }

		public string ThreatRange { get { throw new NotImplementedException(); } }

		public string CriticalDamage { get { throw new NotImplementedException(); } }

		public double Weight { get { throw new NotImplementedException(); } }

		public string DamageType { get { throw new NotImplementedException(); } }

		public string SpecialInfo { get { throw new NotImplementedException(); } }

		public bool IsMasterwork { get { throw new NotImplementedException(); } }

		public double RangeIncrement { get { throw new NotImplementedException(); } }

		public double MaxRange { get { throw new NotImplementedException(); } }

		public PlusEnchantedWeapon(IWeapon weapon, int plusEnhancement)
		{
			forgedWeapon = QualifyWeapon(weapon);

			WeaponName = TrimComponentName(forgedWeapon);
		}


		private ForgedWeapon QualifyWeapon(IWeapon weapon)
		{
			if (!(weapon is ForgedWeapon))
			{
				return new ForgedWeapon(weapon, new Masterwork());
			}
			else if ((weapon is ForgedWeapon) && !weapon.IsMasterwork)
			{
				return MasterworkVersionOfComponent(weapon);
			}
			else
			{
				return weapon as ForgedWeapon;
			}
		}

		private ForgedWeapon MasterworkVersionOfComponent(ForgedWeapon weapon)
		{
			if (weapon.ComponentName = "Cold Iron")
			{
				return new ForgedWeapon(weapon, new MasterworkColdIron());
			}
			else
			{
				return new ForgedWeapon(weapon, new MasterworkAlchemicalSilver());
			}
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
	}
}
