using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.WeaponSmith;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
	public class WeaponItemSmith
	{
		public static WeaponItem OrderItem(string order)
		{
			return new WeaponItem(new WeaponOrder(TempWeaponDictionary.GetWeaponData(order)));
		}
	}
}
