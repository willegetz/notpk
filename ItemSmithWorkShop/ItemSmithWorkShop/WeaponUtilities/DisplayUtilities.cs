using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class DisplayUtilities : WeaponItemWeaver
	{
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

		internal static string BasicDisplay(string name, double cost, double weight, string toHit, string damage, string description)
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", name, cost, weight, toHit, damage, description);
		}

		internal static string BasicDisplay(string name, double cost, double weight, string toHit, string damage, int damageModifier, string description)
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4} {5}'\r\n\t{6}", name, cost, weight, toHit, damage, damageModifier, description);
		}

		internal static string BasicDisplay(WeaponOrder order)
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", order.Name, order.Cost, order.Weight, "+0", order.Damage, order.Description);
		}

		public static string BasicMagicalDisplay(WeaponItemWeaver weapon)
		{
			return string.Format("{0}:\t'{1} gp'\t('{2} value')\r\nWeight: '{3} pound(s)'\r\nTo Hit: '+{4}'\r\nDamage: '{5}'\r\nHardness: '{6}'\r\nHit Points: '{7}'\r\n\t{8}", 
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
