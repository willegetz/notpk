using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
	public class WeaponItem : AdventureItem
	{
		public WeaponItem(WeaponOrder weapon)
		{
			name = weapon.GetName();
			cost = weapon.GetCost();
		}

		public override string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'", name, cost);
		}
	}
}