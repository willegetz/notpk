using System;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.AdventureItems;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class DisplayUtilities : WeaponItemWeaver
	{
		public static string FullMagicalDisplay(WeaponItemWeaver magicWeapon)
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("{0}:\t'{1} gp'\t('+{2} value'){12}To Hit: '+{3}'{12}Damage: '{4}{5}{6}' {7}{12}Hardness: '{8}'{12}Hit Points: '{9}'{12}Weight: '{10} pound(s)'{12}{11}",
				magicWeapon.GetName(),
				magicWeapon.GetCost(),
				magicWeapon.GetEnhancementBonusForCost(),
				magicWeapon.GetEnhancementBonus(),
				magicWeapon.GetDamage(),
				magicWeapon.GetThreat(),
				magicWeapon.GetEnchantmentCriticalDamage(),
				magicWeapon.GetDamageType(),
				magicWeapon.GetModifiedHardness(),
				magicWeapon.GetModifiedHitPoints(),
				magicWeapon.GetWeight(),
				magicWeapon.GetDescription(),
				Environment.NewLine));
			sb.Append(string.Format("{5}Creator Caster Level: '{0}'{5}Time to Create: '{1} Days'{5}Creation XP Cost: '{2}'{5}Creation Raw Material Cost: '{3}'{5}{4}",
				magicWeapon.GetMinimumCasterLevel(),
				magicWeapon.GetDaysToCreate(),
				magicWeapon.GetCreationXpCost(),
				magicWeapon.GetCreationRawMaterialCost(),
				magicWeapon.GetCreationRequirements(),
				Environment.NewLine));

			return sb.ToString();
		}

		public static string BasicDisplay(WeaponItemWeaver weapon)
		{
			string damageMod;
			if (weapon.GetDamageModifier() == 0)
			{
				damageMod = "";
			}
			else
			{
				damageMod = string.Format(" {0}", weapon.GetDamageModifier());
			}

			return string.Format("{0}:\t'{1} gp'{9}Weight: '{2} pound(s)'{9}To Hit: '{3}'{9}Damage: '{4}{5}'{9}Hardness: '{6}'{9}Hit Points: '{7}'{9}{8}", 
				weapon.GetName(), 
				weapon.GetCost(), 
				weapon.GetWeight(),
				weapon.GetToHit(),
				weapon.GetDamage(), 
				damageMod,
				weapon.GetHardness(),
				weapon.GetHitPoints(),
				weapon.GetDescription(),
				Environment.NewLine);
		}

		public static string BasicMagicalDisplay(WeaponItemWeaver weapon)
		{
			return string.Format("{0}:\t'{1} gp'\t('+{2} value'){9}Weight: '{3} pound(s)'{9}To Hit: '+{4}'{9}Damage: '{5}'{9}Hardness: '{6}'{9}Hit Points: '{7}'{9}{8}", 
				weapon.GetName(), 
				weapon.GetCost(),
				weapon.GetEnhancementBonusForCost(),
				weapon.GetWeight(),
				weapon.GetEnhancementBonus(),
				weapon.GetDamage(), 
				weapon.GetModifiedHardness(),
				weapon.GetModifiedHitPoints(),
				weapon.GetDescription(),
				Environment.NewLine);
		}

		public static string BasicDisplay(WeaponData weapon)
		{
			return string.Format("{1}:\t'{2} gp'{0}Weight: '{3} pound(s)'{0}Damage: '{4} [{5}-20]' {6}{0}Hardness: '{7}'{0}Hit Points: '{8}'{0}{9}",
				Environment.NewLine,
				weapon.WeaponName,
				weapon.BasePrice,
				weapon.WeaponWeight,
				weapon.WeaponDamage,
				weapon.WeaponThreatRange,
				weapon.WeaponDamageType,
				weapon.WeaponHardness,
				weapon.WeaponHitPoints,
				weapon.WeaponText);
		}

		public static object BasicIngotDisplay(MaterialComponentData ingotInfo)
		{
			return string.Format("Name: {1}{0}Cost Modifier: '{2} gold pieces'{0}\tAdditional Cost: '{3}'{0}Weight Multiplier: '{4}'{0}Is Masterwork: '{5}'{0}Masterwork Cost: '{6}'{0}To Hit Bonus: '{7}'{0}Damage Modifier: '{8}'{0}Description:{0}\t{9}",
				Environment.NewLine,
				ingotInfo.Name,
				ingotInfo.ComponentCostModifier,
				ingotInfo.AdditionalCostModifier,
				ingotInfo.ComponentWeightModifier,
				ingotInfo.IsMasterwork,
				ingotInfo.MasterworkCostModifier,
				ingotInfo.ToHitBonus,
				ingotInfo.ComponentDamageModifier,
				ingotInfo.ComponentDescription);
		}

		public static object BasicSpecialAbilityDisplay(EnchantmentData specialAbilityInfo)
		{
			return string.Format("Name: {1}{0}Enhancement Bonus: '{2}'{0}Minimum Caster Level: '{3}'{0}Damage: '{4}'{0}Critical Damage: '{5}'{0}Damage Type: '{6}'{0}Creation Requirements:{0}{7}{0}Description:{0}\t{8}",
				Environment.NewLine,
				specialAbilityInfo.EnchantmentName,
				specialAbilityInfo.EnhancementBonus,
				specialAbilityInfo.MinimumCasterLevel,
				specialAbilityInfo.EnchantmentDamage,
				specialAbilityInfo.EnchantmentCriticalDamage,
				specialAbilityInfo.DamageType,
				specialAbilityInfo.CreationRequirements,
				specialAbilityInfo.EnchantmentDescription);
		}
	}
}
