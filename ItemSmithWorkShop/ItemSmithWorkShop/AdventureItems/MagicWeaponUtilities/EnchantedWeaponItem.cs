using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.AdventureItems;

namespace MagicWeaponUtilities
{
	public class EnchantedWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;
		WeaponEnchantment enchantment;

		public EnchantedWeaponItem(WeaponItemWeaver magicWeapon, WeaponEnchantment newEnchantment)
		{
			weaponItem = magicWeapon;
			enchantment = newEnchantment;
		}

		public override string GetName()
		{
			return string.Format("{0}, {1}", weaponItem.GetName(), enchantment.GetName());
		}

		public override int GetEnhancementBonus()
		{
			return weaponItem.GetEnhancementBonus();
		}

		public override int GetEnhancementCostModifier()
		{
			return weaponItem.GetEnhancementCostModifier() + enchantment.GetEnhancementBonus();
		}

		private double GetEnhancementCost()
		{
			return (Math.Pow(GetEnhancementCostModifier(), 2) * 2000);
		}

		public override double GetCost()
		{
			return GetWeaponCost() + GetAdditionalMagicCostModifier() + GetEnhancementCost();
		}

		public override double GetWeaponCost()
		{
			return weaponItem.GetWeaponCost();
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return weaponItem.GetAdditionalMagicCostModifier();
		}

		public override string GetDamage()
		{
			return string.Format("{0}{1}", weaponItem.GetDamage(), enchantment.GetDamage());
		}

		public override string GetThreat()
		{
			return weaponItem.GetThreat();
		}

		public override string GetCriticalMultiplier()
		{
			return enchantment.GetCriticalMultiplier();
		}

		public override string GetEnchantmentCriticalDamage()
		{
			if (string.IsNullOrEmpty(enchantment.GetEnchantmentCriticalDamage()))
			{
				return string.Empty;
			}
			return string.Format("{0}", enchantment.GetEnchantmentCriticalDamage());
		}

		public override string GetDamageType()
		{
			return weaponItem.GetDamageType() + ", " + enchantment.GetDamageType();
		}

		public override double GetModifiedHardness()
		{
			return weaponItem.GetModifiedHardness() + (enchantment.GetEnhancementCostModifier() * 2);
		}

		public override double GetModifiedHitPoints()
		{
			return weaponItem.GetModifiedHitPoints() + (enchantment.GetEnhancementCostModifier() * 10);
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override double GetMinimumCasterLevel()
		{
			if (enchantment.GetCasterLevelRequired() >= weaponItem.GetMinimumCasterLevel())
			{
				return enchantment.GetCasterLevelRequired();
			}
			return weaponItem.GetMinimumCasterLevel();
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + enchantment.GetDescription();
		}

		public override double GetDaysToCreate()
		{
			return GetEnhancementCost() / 1000;
		}

		public override double GetCreationXpCost()
		{
			return GetEnhancementCost() / 25;
		}

		public override double GetCreationRawMaterialCost()
		{
			return (GetEnhancementCost() / 2) + weaponItem.GetWeaponCost() + weaponItem.GetAdditionalMagicCostModifier();
		}

		public override string GetCreationRequirements()
		{
			return string.Format("{0}{1}", weaponItem.GetCreationRequirements(), enchantment.GetCreationRequirements());
		}

		internal string DisplayFullText()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("{0}:\t'{1} gp'\r\nTo Hit: '+{2}'\r\nDamage: '{3}{4}{5}' {6}\r\nHardness: '{7}'\r\nHit Points: '{8}'\r\nWeight: '{9} pound(s)'\r\n\t{10}",
				GetName(),
				GetCost(),
				GetEnhancementBonus(),
				GetDamage(),
				GetThreat(),
				GetEnchantmentCriticalDamage(),
				GetDamageType(),
				GetModifiedHardness(),
				GetModifiedHitPoints(),
				GetWeight(),
				GetDescription()));
			sb.AppendLine(string.Format("\r\nCreator Caster Level: '{0}'\r\nTime to Create: '{1} Days'\r\nCreation XP Cost: '{2}'\r\nCreation Raw Material Cost: '{3}'\r\n{4}",
				GetMinimumCasterLevel(),
				GetDaysToCreate(),
				GetCreationXpCost(),
				GetCreationRawMaterialCost(),
				GetCreationRequirements()));

			return sb.ToString();
		}
	}
}
