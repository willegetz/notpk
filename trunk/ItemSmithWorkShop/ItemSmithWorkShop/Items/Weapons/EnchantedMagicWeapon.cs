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

		private PlusEnhancedWeapon plusWeapon;

		private List<IWeaponEnchantment> enchantments;

		private double enhancementCostMultiplier = 2000;


		#region IWeapon Members

		public string WeaponName { get; private set; }

		public string GivenName { get; private set; }

		public string Proficiency { get; private set; }

		public string WeaponUse { get; private set; }

		public string WeaponCategory { get; private set; }

		public string WeaponSubCategory { get; private set; }

		public string WeaponSize { get; private set; }

		public double WeaponCost { get; private set; }

		public string Damage { get; private set; }

		public double ThreatRangeLowerBound { get; private set; }

		public string ThreatRange { get; private set; }

		public string CriticalDamage { get; private set; }

		public string DamageType { get; private set; }

		public double Weight { get; private set; }

		public double Hardness { get; private set; }

		public double HitPoints { get; private set; }

		public string SpecialInfo { get; private set; }

		public bool IsMasterwork { get { return true; } }

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

		public double PlusEnhancement { get; private set; }

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

		private double baseEnhancementCost;
		public double BaseEnhancementCost 
		{
			get { return baseEnhancementCost; }
			private set
			{
				baseEnhancementCost = Math.Pow(costModifier, 2) * enhancementCostMultiplier;
			}
		}

		public double BaseItemCost
		{
			get { throw new NotImplementedException(); }
		}

		public bool IsMagical { get { return true; } }

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

		private double costModifier;
		public double CostModifier
		{
			get { return costModifier; } 
			private set
			{
				costModifier = value;
				BaseEnhancementCost = value;
			}
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
	
		public EnchantedMagicWeapon(IWeapon weapon, List<IWeaponEnchantment> weaponEnchantments)
		{
			enchantments = new List<IWeaponEnchantment>();

			plusWeapon = QualifyWeapon(weapon);
			enchantments.AddRange(weaponEnchantments);

			WeaponName = plusWeapon.WeaponName;
			GivenName = plusWeapon.GivenName;
			Proficiency = plusWeapon.Proficiency;
			WeaponUse = plusWeapon.WeaponUse;
			WeaponCategory = plusWeapon.WeaponCategory;
			WeaponSubCategory = plusWeapon.WeaponSubCategory;
			WeaponSize = plusWeapon.WeaponSize;
			WeaponCost = plusWeapon.WeaponCost;
			Damage = plusWeapon.Damage;
			ThreatRangeLowerBound = plusWeapon.ThreatRangeLowerBound;
			CriticalDamage = plusWeapon.CriticalDamage;
			DamageType = plusWeapon.DamageType;
			Weight = plusWeapon.Weight;
			Hardness = plusWeapon.Hardness;
			HitPoints = plusWeapon.HitPoints;
			
			PlusEnhancement = plusWeapon.PlusEnhancement;
			CostModifier = TallyCostModifiers();
			ThreatRange = CalculateThreatRange();
			SpecialInfo = AppendSpecialInfo();
		}

		private PlusEnhancedWeapon QualifyWeapon(IWeapon weapon)
		{
			if (!weapon.IsMagical)
			{
				return new PlusEnhancedWeapon(weapon, 1);
			}
			return weapon as PlusEnhancedWeapon;
		}

		private double TallyCostModifiers()
		{
			return (from enchantment in enchantments select enchantment.CostModifier).ToList().Sum() + PlusEnhancement;
		}

		private string CalculateThreatRange()
		{
			var threatModifer = (from enchantment in enchantments
								 where enchantment.ThreatRangeModifier > 1
								 select enchantment.ThreatRangeModifier).ToList().Max();

			var newLowerBound = 21 - (((20 - ThreatRangeLowerBound) + 1) * threatModifer);
	
			return string.Format("{0}-20", newLowerBound);
		}

		private string AppendSpecialInfo()
		{
			var notesCollection = new StringBuilder();
			foreach (var enchantment in enchantments)
			{
				notesCollection.AppendLine(string.Format("{0}: {1}", enchantment.EnchantmentName, enchantment.EnchantmentNotes));
			}
			return string.Format("{1}{0}{2}", Environment.NewLine, plusWeapon.SpecialInfo, notesCollection);
		}
	}
}
