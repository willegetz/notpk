using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
	public class WeaponItem : AdventureItem
	{
		private string damage;

		public WeaponItem(WeaponOrder weapon)
		{
			name = weapon.GetName();
			cost = weapon.GetCost();
			weight = weapon.GetWeight();
			description = weapon.GetDescription();
			this.damage = weapon.Damage;
		}

		public override string GetItem()
		{
			return string.Format("{0}:\t'{1} gp\r\nWeight: '{2} pound(s)'\r\nDamage: '{4}'\r\n\t{3}", name, cost, weight, description, damage);
		}
	}
}