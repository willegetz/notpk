using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.AdventureItems
{
	class WeaponEnchantment : WeaponItemWeaver
	{
		private string enchantment;
		private string name;
		private string damage;
		private string damageType;
		private int casterLevel;
		private int enhancementBonus;
		private string requirements;
		private string description;

		public WeaponEnchantment(EnchantmentOrder enchantment)
		{
			name = enchantment.Name;
			damage = enchantment.Damage;
			damageType = enchantment.DamageType;
			casterLevel = enchantment.CasterLevel;
			enhancementBonus = enchantment.EnhancementBonus;
			requirements = enchantment.Requirements;
			description = enchantment.Description;
		}

		public WeaponEnchantment(string enchantmentType)
		{
			enchantment = enchantmentType;
		}

		public override string GetName()
		{
			return enchantment;
		}

		public override string GetDamage()
		{
			return "1D6";
		}

		public override int GetCasterLevelRequired()
		{
			return 10;
		}

		public override int GetEnhancementCostModifier()
		{
			return 1;
		}

		public override string GetDamageType()
		{
			return "Fire";
		}

		public override string GetCreationRequirements()
		{
			return "\tRequired Feats: Craft Magic Arms and Armor\n\tRequired Spells: flame blade, flame strike, or fireball";
		}

		public override string GetDescription()
		{
			return "\n\n\tUpon command, a flaming weapon is sheathed in fire.\n\tThe fire does not harm the wielder. The effect\n\tremains until another command is given.";
		}
	}
}
