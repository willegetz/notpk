using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.Weapons
{
	public class EnchantedMagicWeapon : IEnchantedMagicWeapon
	{
		// EnhantedMagicWeapon is made from a PlusEnhancedWeapon
		//		A weapon that is passed in that is not a PlusEnhancedWeapon must be made such.
		//			Perhaps the implementation of a "Magic Weapon" Interface?

		// DamageBonus (IForgedWeapon) and StandardDamageBonus (IWeaponEnchantment) seem to be the same.
		//		Will have to see how it plays out

		#region IWeapon Members

		public string GivenName
		{
			get { throw new NotImplementedException(); }
		}

		public string Proficiency
		{
			get { throw new NotImplementedException(); }
		}

		public string WeaponUse
		{
			get { throw new NotImplementedException(); }
		}

		public string WeaponCategory
		{
			get { throw new NotImplementedException(); }
		}

		public string WeaponSubCategory
		{
			get { throw new NotImplementedException(); }
		}

		public string WeaponSize
		{
			get { throw new NotImplementedException(); }
		}

		public string WeaponName
		{
			get { throw new NotImplementedException(); }
		}

		public double WeaponCost
		{
			get { throw new NotImplementedException(); }
		}

		public string Damage
		{
			get { throw new NotImplementedException(); }
		}

		public double ThreatRangeLowerBound
		{
			get { throw new NotImplementedException(); }
		}

		public string ThreatRange
		{
			get { throw new NotImplementedException(); }
		}

		public string CriticalDamage
		{
			get { throw new NotImplementedException(); }
		}

		public string DamageType
		{
			get { throw new NotImplementedException(); }
		}

		public double Weight
		{
			get { throw new NotImplementedException(); }
		}

		public double Hardness
		{
			get { throw new NotImplementedException(); }
		}

		public double HitPoints
		{
			get { throw new NotImplementedException(); }
		}

		public string SpecialInfo
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsMasterwork
		{
			get { throw new NotImplementedException(); }
		}

		public double RangeIncrement
		{
			get { throw new NotImplementedException(); }
		}

		public double MaxRange
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IForgedWeapon Members

		public double AdditionalEnchantmentCost
		{
			get { throw new NotImplementedException(); }
		}

		public string ToHitModifier
		{
			get { throw new NotImplementedException(); }
		}

		public double DamageBonus
		{
			get { throw new NotImplementedException(); }
		}

		public string ComponentName
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IPlusEnhancedWeapon Members

		public double PlusEnhancement
		{
			get { throw new NotImplementedException(); }
		}

		public double MinimumCasterLevel
		{
			get { throw new NotImplementedException(); }
		}

		public string MagicAura
		{
			get { throw new NotImplementedException(); }
		}

		public string GeneratesLight
		{
			get { throw new NotImplementedException(); }
		}

		public string RequiredFeats
		{
			get { throw new NotImplementedException(); }
		}

		public double CreationTime
		{
			get { throw new NotImplementedException(); }
		}

		public double RawMaterialCost
		{
			get { throw new NotImplementedException(); }
		}

		public double CreationXpCost
		{
			get { throw new NotImplementedException(); }
		}

		public double BaseEnhancementCost
		{
			get { throw new NotImplementedException(); }
		}

		public double BaseItemCost
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		#region IWeaponEnchantment Members

		public string EnchantmentName
		{
			get { throw new NotImplementedException(); }
		}

		public string Affix
		{
			get { throw new NotImplementedException(); }
		}

		public int CostModifier
		{
			get { throw new NotImplementedException(); }
		}

		public string StandardDamageBonus
		{
			get { throw new NotImplementedException(); }
		}

		public bool CriticalDamageBonus
		{
			get { throw new NotImplementedException(); }
		}

		public double ThreatRangeModifier
		{
			get { throw new NotImplementedException(); }
		}

		public double RangeIncrementModifier
		{
			get { throw new NotImplementedException(); }
		}

		public string RequiredSpells
		{
			get { throw new NotImplementedException(); }
		}

		public string AdditionalRequirements
		{
			get { throw new NotImplementedException(); }
		}

		public string EnchantmentNotes
		{
			get { throw new NotImplementedException(); }
		}

		#endregion
	}
}
