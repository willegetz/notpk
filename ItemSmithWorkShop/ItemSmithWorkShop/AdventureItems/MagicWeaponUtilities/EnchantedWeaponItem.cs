using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;

namespace ItemSmithWorkShop.AdventureItems
{
	public class EnchantedWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;
		WeaponEnchantment enchantment;

		public EnchantedWeaponItem(WeaponItemWeaver magicWeapon, string enchantmentType)
		{
			weaponItem = magicWeapon;
			enchantment = new WeaponEnchantment(enchantmentType);
		}

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

		private double GetEnhancementCost()
		{
			double totalEnhancementBonus = weaponItem.GetEnhancementBonus() + enchantment.GetEnhancementCostModifier();
			return (Math.Pow(totalEnhancementBonus, 2) * 2000);
		}

		public override double GetCost()
		{
			return weaponItem.GetWeaponCost() + weaponItem.GetAdditionalMagicCostModifier() + GetEnhancementCost();
		}

		public override string GetDamage()
		{
			return string.Format("{0} +{1}", weaponItem.GetDamage(), enchantment.GetDamage());
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

		internal string DisplayFullText()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("{0}:\t'{1} gp'\r\nTo Hit: '+{2}'\r\nDamage: '{3}{4}' {5}\r\nHardness: '{6}'\r\nHit Points: '{7}'\r\nWeight: '{8} pound(s)'\r\n\t{9}",
				GetName(),
				GetCost(),
				GetEnhancementBonus(),
				GetDamage(),
				weaponItem.GetThreat(),
				weaponItem.GetDamageType() + ", " + enchantment.GetDamageType(),
				GetModifiedHardness(),
				GetModifiedHitPoints(),
				GetWeight(),
				weaponItem.GetDescription() + enchantment.GetDescription()));
			sb.AppendLine(string.Format("\r\nCreator Caster Level: '{0}'\r\nTime to Create: '{1} Days'\r\nCreation XP Cost: '{2}'\r\nCreation Raw Material Cost: '{3}'\r\n{4}",
				GetMinimumCasterLevel(),
				GetDaysToCreate(),
				GetCreationXpCost(),
				GetCreationRawMaterialCost(),
				enchantment.GetCreationRequirements()));

			return sb.ToString();
		}
	}
}
