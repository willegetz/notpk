using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.WeaponSmith;
using ItemSmithWorkShop.AdventureItems;
using ItemSmithWorkShop.AdventureItems.WeaponAdons;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;
using ItemSmithWorkShop.WeaponUtilities;

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

		public static MasterworkWeaponItem OrderSpecialComponent(WeaponItemWeaver weapon, string materialComponent)
		{
			var component = new MaterialComponentOrder(MaterialComponentDictionary.GetComponentData(materialComponent));
			return new MasterworkWeaponItem(weapon, component);
		}

		public static MasterworkWeaponItem OrderBlah(WeaponOrder weapon, string materialComponent)
		{
			var component = new MaterialComponentOrder(MaterialComponentDictionary.GetComponentData(materialComponent));
			return new MasterworkWeaponItem(weapon, component);
		}

		internal static WeaponOrder OrderBlah(string p)
		{
			return new WeaponOrder(TempWeaponDictionary.GetWeaponData(p));
		}
	}
}
