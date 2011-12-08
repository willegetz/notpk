using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.WeaponSmith;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
	public class WeaponItemSmith : AdventureItemShop
	{
		protected override AdventureItem CreateItem(string itemName)
		{
			var weapon = new WeaponOrder(TempWeaponDictionary.GetWeaponData(itemName));
			return new WeaponItem(weapon);
		}
	}
}
