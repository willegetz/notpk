﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Weapons.Interfaces;

namespace ItemSmithWorkShop.Weapons.MagicEnchantments
{
	public class WeaponEnchantment
	{
		// Weapon enchantments cannot be added unless the weapon is already a Plus 1 value
		// Weapon enchantments can be either a prefix or a suffix.
		// Enchantments have a Plus value which affects the total value of the weapon
		// Enchantments are either for Ranged weapons, or melee weapons
		//		Thrown and Projectile and Ammunition included
		// Enchantments usually do additional damage on a standard hit.
		// Enchantments can do additional damage on a critical hit
		// The enchantments have other effects that appear in the description
		// At least one enchantment affects the threat range of a weapon
		// Enchantments have an aura
		// Enchantments have a minimum caster level
		// Enchantments have feat and spell requirements to create
		// Enchantments may have additional requirements as well

		public string EnchantmentName { get; private set; }
		public string Affix { get; private set; }
		public int CostModifier { get; private set; }
		public string WeaponUse { get; private set; }
		public string StandardDamageBonus { get; private set; }
		public string CriticalDamageBonus { get; private set; }
		public string DamageType { get; private set; }
		public string MagicAura { get; private set; }
		public int MinimumCasterLevel { get; private set; }
		public string RequiredFeats { get; private set; }
		public string RequiredSpells { get; private set; }
		public string AdditionalRequirements { get; private set; }
		public string EnchantmentNotes { get; private set; }

		public WeaponEnchantment()
		{
			EnchantmentName = "Anarchic";
			Affix = "Pre";
			CostModifier = 2;
			WeaponUse = "Melee, Ranged";
			StandardDamageBonus = "2d6 vs. Lawful Alignment";
			CriticalDamageBonus = string.Empty;
			DamageType = "Chaotic";
			MagicAura = "Moderate evocation [chaotic]";
			MinimumCasterLevel = 7;
			RequiredFeats = "Craft Magic Arms and Armor";
			RequiredSpells = "chaos hammer";
			AdditionalRequirements = "Creator must be chaotic";
			EnchantmentNotes = "-1 temporary level to any wielder of Lawful Alignment. Level loss cannot be overcome in any way while the weapon is wielded.";
		}

		public override string ToString()
		{
			return string.Format(
								"Enchantment: '{1}'{0}Affix: '{2}'{0}Cost Modifier: '+{3}'{0}Weapon Usage: '{4}'{0}Standard Damage Bonus: '{5}'{0}Critical Damage Bonus: '{6}'{0}Damage Type: '{7}'{0}Magic Aura: '{8}'{0}Minimum Caster Level: '{9}'{0}Required Feats: '{10}'{0}Required Spells: '{11}'{0}Additional Requirements: '{12}'{0}Notes: '{13}'",
								Environment.NewLine,
								EnchantmentName,
								Affix,
								CostModifier,
								WeaponUse,
								StandardDamageBonus,
								CriticalDamageBonus,
								DamageType,
								MagicAura,
								MinimumCasterLevel,
								RequiredFeats,
								RequiredSpells,
								AdditionalRequirements,
								EnchantmentNotes
								);
		}
	}
}