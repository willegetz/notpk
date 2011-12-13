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
			if (string.IsNullOrEmpty(order))
			{
				throw new ArgumentNullException(string.Format("Weapon Name: '{0}'", order), "The name of the weapon must be specified");
			}
			return new WeaponItem(new WeaponOrder(TempWeaponDictionary.GetWeaponData(order)));
		}
	}
}
