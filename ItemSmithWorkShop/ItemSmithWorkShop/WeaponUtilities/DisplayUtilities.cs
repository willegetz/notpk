using System;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class DisplayUtilities
	{
		public static object BasicDisplay(WeaponItem weapon)
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

			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}{5}'\r\n\t{6}", weapon.GetName(), weapon.GetCost(), weapon.GetWeight(), weapon.GetToHit(), weapon.GetDamage(), damageMod, weapon.GetDescription());
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
	}
}
