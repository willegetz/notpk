using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Weapons.Interfaces;

namespace ItemSmithWorkShop.Weapons.MaterialTypes
{
	public class Mithral
	{
		// The mithral material type is interesting.
		// Mithral armor are one category lighter: Heavy => Medium, Medium => Light, Light => Light
		// Spell failure chances are reduced for armor and shields: 10% reduction
		// Max dex bonus is reduced by 2
		// Armor check penalties are reduced by 3, to a minumum of 0
		// Item weight is reduced by half
		// Weapons or armor fashioned are always masterwork
		// Cost modifiers include masterwork price:
		//		Light armor: +1000 gold
		//		Medium armor: +4000 gold
		//		Heavy armor: +9000 gold
		//		Shield: +1000 gold
		//		Other items: +500 gold per pound

		// There are three categories for this class
		//		1) Armor and shields
		//		2) Weapons
		//		3) Other items

		// I don't know how I am going to apply these values.

		private const string materialName = "Mithral";
		private const double lightArmorCostModifier = 1000;
		private const double mediumArmorCostModifier = 4000;
		private const double heavyArmorCostModifier = 9000;
		private const double shieldCostModifier = 1000;
		private const double weaponCostModifier = 500;
		private const double itemCostModifier = 500;
		private const double itemWeightModifier = 0.5;
		private const double spellFailureReduction = 0.1;
		private const double maxDexReduction = -2;
		private const double armorCheckPenaltyReduction = -3;

		public string MaterialName { get { return materialName; } }
		public double LightArmorCostModifier { get { return lightArmorCostModifier; } }
		public double MediumArmorCostModifier { get { return mediumArmorCostModifier; } }
		public double HeavyArmorCostModifier { get { return heavyArmorCostModifier; } }
		public double ShieldCostModifier { get { return shieldCostModifier; } }
		public double WeaponCostModifier { get { return weaponCostModifier; } }
		public double ItemCostModifier { get { return itemCostModifier; } }
		public double ItemWeightModifier { get { return itemWeightModifier; } }
		public double SpellFailureReduction { get { return spellFailureReduction; } }
		public double MaxDexReduction { get { return maxDexReduction; } }
		public double ArmorCheckPenaltyReduction { get { return armorCheckPenaltyReduction; } }

		internal double ApplyCostModifier(IWeapon weapon)
		{
			return weapon.WeaponCost + (weapon.Weight * WeaponCostModifier);
		}

		internal double ApplyWeightModifier(IWeapon weapon)
		{
			return weapon.Weight * ItemWeightModifier;
		}

		public override string ToString()
		{
			string currency = "gold pieces";
			return string.Format("Material:{1}'{3}'{0}Armor Cost Modifiers:{0}{1}Light:{1}'{4}' {2}{0}{1}Medium:{1}'{5}' {2}{0}{1}Heavy:{1}'{6}' {2}{0}Shield Cost Modifier:{1}'{7}' {2}{0}Weapon Cost Modifier:{1}'{8}' {2} per pound{0}Item Cost Modifier:{1}'{9}' {2} per pound{0}Spell Failure Reduction:{1}'{10}%'{0}Max Dex Reduction:{1}'{11}'{0}Armor Check Penalty Reduction:{1}'{12}'",
									Environment.NewLine, 
									"\t", 
									currency, 
									MaterialName, 
									LightArmorCostModifier, 
									MediumArmorCostModifier, 
									HeavyArmorCostModifier, 
									ShieldCostModifier,
									WeaponCostModifier,
									ItemCostModifier,
									(SpellFailureReduction * 100),
									MaxDexReduction,
									ArmorCheckPenaltyReduction
								);
		}


	}
}
