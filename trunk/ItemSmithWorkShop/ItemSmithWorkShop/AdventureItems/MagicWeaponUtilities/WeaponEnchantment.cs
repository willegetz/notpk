using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.AdventureItems
{
	public class WeaponEnchantment : WeaponItemWeaver
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
			return name;
		}

		public override string GetDamage()
		{
			return damage;
		}

		public override int GetCasterLevelRequired()
		{
			return casterLevel;
		}

		public override int GetEnhancementCostModifier()
		{
			return enhancementBonus;
		}

		public override string GetDamageType()
		{
			return damageType;
		}

		public override string GetCreationRequirements()
		{
			return requirements;
		}

		public override string GetDescription()
		{
			return description;
		}
	}
}
