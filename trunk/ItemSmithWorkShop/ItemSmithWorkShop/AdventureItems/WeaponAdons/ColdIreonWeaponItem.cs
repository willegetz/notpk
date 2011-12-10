using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class ColdIreonWeaponItem : WeaponItemWeaver
	{
		private const string ColdIronNamePrefix = "Cold Iron ";
		private const int ColdIronModifier = 2;
		WeaponItemWeaver weaponItem;

		public ColdIreonWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return ColdIronNamePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() * ColdIronModifier;
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + "\r\n\tCold Iron is effective against some Fey.\r\n\tMagic enhancements cost an additional 2000 gold pieces.";
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nDamage: '{3}'\r\n\t{4}", GetName(), GetCost(), weaponItem.GetWeight(), weaponItem.GetDamage(), GetDescription()); 
		}
	}
}
