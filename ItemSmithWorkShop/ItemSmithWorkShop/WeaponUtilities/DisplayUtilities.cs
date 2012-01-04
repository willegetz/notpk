using System;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class DisplayUtilities : WeaponItemWeaver
	{
		public static string FullMagicalDisplay(WeaponItemWeaver magicWeapon)
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("{0}:\t'{1} gp'\t('+{11} value')\r\nTo Hit: '+{2}'\r\nDamage: '{3}{4}{5}' {6}\r\nHardness: '{7}'\r\nHit Points: '{8}'\r\nWeight: '{9} pound(s)'\r\n\t{10}",
				magicWeapon.GetName(),
				magicWeapon.GetCost(),
				magicWeapon.GetEnhancementBonus(),
				magicWeapon.GetDamage(),
				magicWeapon.GetThreat(),
				magicWeapon.GetEnchantmentCriticalDamage(),
				magicWeapon.GetDamageType(),
				magicWeapon.GetModifiedHardness(),
				magicWeapon.GetModifiedHitPoints(),
				magicWeapon.GetWeight(),
				magicWeapon.GetDescription(),
				magicWeapon.GetEnhancementBonusForCost()));
			sb.AppendLine(string.Format("\r\nCreator Caster Level: '{0}'\r\nTime to Create: '{1} Days'\r\nCreation XP Cost: '{2}'\r\nCreation Raw Material Cost: '{3}'\r\n{4}",
				magicWeapon.GetMinimumCasterLevel(),
				magicWeapon.GetDaysToCreate(),
				magicWeapon.GetCreationXpCost(),
				magicWeapon.GetCreationRawMaterialCost(),
				magicWeapon.GetCreationRequirements()));

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

			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}{5}'\r\nHardness: '{6}'\r\nHit Points: '{7}'\r\n\t{8}", 
				weapon.GetName(), 
				weapon.GetCost(), 
				weapon.GetWeight(),
				weapon.GetToHit(),
				weapon.GetDamage(), 
				damageMod,
				weapon.GetHardness(),
				weapon.GetHitPoints(),
				weapon.GetDescription());
		}

		public static string BasicMagicalDisplay(WeaponItemWeaver weapon)
		{
			return string.Format("{0}:\t'{1} gp'\t('+{2} value')\r\nWeight: '{3} pound(s)'\r\nTo Hit: '+{4}'\r\nDamage: '{5}'\r\nHardness: '{6}'\r\nHit Points: '{7}'\r\n\t{8}", 
				weapon.GetName(), 
				weapon.GetCost(),
				weapon.GetEnhancementBonusForCost(),
				weapon.GetWeight(),
				weapon.GetEnhancementBonus(),
				weapon.GetDamage(), 
				weapon.GetModifiedHardness(),
				weapon.GetModifiedHitPoints(),
				weapon.GetDescription());
		}
	}
}
