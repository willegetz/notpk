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
		private Dictionary<string, string> criticalDamages;

		private double enhancementCostMultiplier = 2000;
		private double creationDaysMultiplier = 0.001;
		private double creationCostMultiplier = 0.5;
		private double creationXpCost = 0.04;



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

		public double RangeIncrement { get; private set; }

		public double MaxRange { get; private set; }

		#endregion

		#region IForgedWeapon Members

		public double AdditionalEnchantmentCost { get; private set; }

		public string ToHitModifier { get; private set; }

		public double DamageBonus { get; private set; }

		public string ComponentName { get; private set; }

		#endregion

		#region IPlusEnhancedWeapon Members

		public double PlusEnhancement { get; private set; }

		public double MinimumCasterLevel { get; private set; }

		public string MagicAura { get; private set; }

		public string GeneratesLight { get; private set; }

		public string RequiredFeats { get; private set; }

		public double CreationTime
		{
			get { return BaseEnhancementCost * creationDaysMultiplier; }
		}

		public double RawMaterialCost
		{
			get { return WeaponCost + (BaseEnhancementCost * creationCostMultiplier); }
		}

		public double CreationXpCost
		{
			get { return BaseEnhancementCost * creationXpCost; }
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
			get 
			{
				var damageBonusList = new StringBuilder();
				
				var damageBonusGroup = (from enchantment in enchantments
										where !string.IsNullOrEmpty(enchantment.StandardDamageBonus)
										select enchantment).ToList();
				
				var count = damageBonusGroup.Count;
				
				while (count > 0)
				{
					foreach (var bonus in damageBonusGroup) 
					{
						damageBonusList.Append(string.Format(" +{0} ({1})", bonus.StandardDamageBonus, bonus.DamageType));
						count--;
					}
					
				}
				return damageBonusList.ToString();
			}
		}

		public bool DoesCriticalDamage
		{
			get { throw new NotImplementedException(); }
		}

		public double ThreatRangeModifier
		{
			get
			{
				return (from enchantment in enchantments
						select enchantment.ThreatRangeModifier).ToList().Max();
			}
		}

		public double RangeIncrementModifier
		{
			get
			{
				return (from enchantment in enchantments
						select enchantment.RangeIncrementModifier).ToList().Max();
			}
		}

		public string RequiredSpells { get; private set; }

		public string AdditionalRequirements { get; private set; }

		public string EnchantmentNotes
		{
			get { throw new NotImplementedException(); }
		}

		#endregion

		// Non interface implemented properties
		public List<IWeaponEnchantment> prefixes
		{
			get
			{
				return (from enchantment in enchantments
						where enchantment.Affix.Contains("Pre")
						select enchantment).ToList();
			}
		}

		public List<IWeaponEnchantment> suffixes
		{
			get
			{
				return (from enchantment in enchantments
						where enchantment.Affix.Contains("Suf")
						select enchantment).ToList();
			}
		}

		public string CriticalDamageBonus { get; private set; }

		public double ModifiedRangeIncrement { get; private set; }

		public double ModifiedMaxRange { get; private set; }

		public EnchantedMagicWeapon(IWeapon weapon, List<IWeaponEnchantment> weaponEnchantments)
		{
			enchantments = new List<IWeaponEnchantment>();
			LoadCriticalDamageDictionary();

			plusWeapon = QualifyWeapon(weapon);
			enchantments.AddRange(weaponEnchantments);

			// IWeapon
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
			RangeIncrement = plusWeapon.RangeIncrement;
			MaxRange = plusWeapon.MaxRange;
			
			//IForgedWeapon
			AdditionalEnchantmentCost = plusWeapon.AdditionalEnchantmentCost;
			ToHitModifier = plusWeapon.ToHitModifier;
			DamageBonus = plusWeapon.DamageBonus;
			ComponentName = plusWeapon.ComponentName;

			//IPlusEnhancedWeapon
			PlusEnhancement = plusWeapon.PlusEnhancement;
			GeneratesLight = plusWeapon.GeneratesLight;
			RequiredFeats = plusWeapon.RequiredFeats;

			//IWeaponEnhancement

			// Properties needing method assignments
			//		IWeapon
			CostModifier = TallyCostModifiers();
			ThreatRange = CalculateThreatRange();
			//		IPlusWeapon and IWeaponEnchantment
			MinimumCasterLevel = DetermineMinimumCasterLevel(plusWeapon.MinimumCasterLevel);
			MagicAura = AssembleAuras();
			//		IWeaponEnchantment
			RequiredSpells = AssembleRequiredSpells();
			AdditionalRequirements = AssembleAdditionalRequirements();
			//		Non interface implemented properties
			ModifiedRangeIncrement = CalculateRangeModifier(plusWeapon.RangeIncrement);
			ModifiedMaxRange = CalculateRangeModifier(plusWeapon.MaxRange);
			CriticalDamageBonus = AssembleCriticalDamages();

			SpecialInfo = AppendSpecialInfo();
		}

		private void LoadCriticalDamageDictionary()
		{
			criticalDamages = new Dictionary<string, string>()
			{
						 {"x2", "+1d10"},
						 {"x3", "+2d10"},
						 {"x4", "+3d10"},
			};
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
			return (from enchantment in enchantments 
					select enchantment.CostModifier).ToList().Sum() + PlusEnhancement;
		}

		private string CalculateThreatRange()
		{
			if (ThreatRangeModifier != 0)
			{
				var newLowerBound = 21 - (((20 - ThreatRangeLowerBound) + 1) * ThreatRangeModifier);
				return string.Format("{0}-20", newLowerBound);
			}
	
			return string.Format("{0}-20", ThreatRangeLowerBound);
		}

		private double CalculateRangeModifier(double range)
		{
			if (RangeIncrementModifier != 0)
			{
				return range * RangeIncrementModifier;
			}
			return range;
		}

		private double DetermineMinimumCasterLevel(double enhancementCasterLevel)
		{
			var minimumEnchantmentCasterLevel = (from enchantment in enchantments
												 select enchantment.MinimumCasterLevel).ToList();
			minimumEnchantmentCasterLevel.Add(enhancementCasterLevel);

			return minimumEnchantmentCasterLevel.Max();
		}

		private string AssembleAuras()
		{
			var auras = new StringBuilder();
			auras.AppendLine(string.Format("Enhancement: {0}", plusWeapon.MagicAura));
			foreach (var enchantment in enchantments)
			{
				auras.AppendLine(string.Format("{0}: {1}", enchantment.EnchantmentName, enchantment.MagicAura));
			}
			return auras.ToString();
		}

		private string AssembleRequiredSpells()
		{
			var enchantmentSpells = new StringBuilder();
			var requiredSpellsList = (from enchantment in enchantments
									 where !string.IsNullOrEmpty(enchantment.RequiredSpells)
									 select enchantment).ToList();
			
			enchantmentSpells.AppendLine("Required Spells");
			foreach (var requiredSpell in requiredSpellsList)
			{
				enchantmentSpells.AppendLine(string.Format("{0}{1}: {2}", "\t", requiredSpell.EnchantmentName, requiredSpell.RequiredSpells));
			}
			return enchantmentSpells.ToString();
		}

		private string AssembleCriticalDamages()
		{
			var critDamageList = new StringBuilder();

			var critDamages = (from enchantment in enchantments
							   where enchantment.DoesCriticalDamage == true
							   select enchantment).ToList();

			string critDamageBonus = criticalDamages[plusWeapon.CriticalDamage];
			foreach (var damgeBonus in critDamages)
			{
				critDamageList.Append(string.Format(" {0} ({1})", critDamageBonus, damgeBonus.DamageType));
			}
			return critDamageList.ToString();
		}

		private string AssembleAdditionalRequirements()
		{
			var additionalRequirementsCollection = new StringBuilder();
			var requirements = (from enchantment in enchantments
								where !string.IsNullOrEmpty(enchantment.AdditionalRequirements)
								select enchantment).ToList();

			additionalRequirementsCollection.AppendLine("Additional Creation Requirements");
			foreach (var requirement in requirements)
			{
				additionalRequirementsCollection.AppendLine(string.Format("{0}{1}: {2}", "\t", requirement.EnchantmentName, requirement.AdditionalRequirements));
			}
			return additionalRequirementsCollection.ToString();
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

		public override string ToString()
		{
			var displayWeapon = new StringBuilder();
			// Given Name; "Doom's Dagger!"
			// Weapon Name: +n Prefix Dagger Suffix
			// Total Plus: +n for enhancement, +n for Prefix, +n for Suffix
			// Weapon Cost: xk gold pieces
			// To Hit: +n
			// Damage: Base Damage +n enhancement +n damage type [Threat range/crit mod] +n crit bonus damage type, constant damage types
			return base.ToString();
		}
	}
}