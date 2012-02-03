using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop
{
	public class ItemTicket
	{
		internal static object WeaponTicket(string weaponName)
		{
			var weaponInfo = TempWeaponDictionary.GetWeaponData(weaponName);
			return DisplayUtilities.BasicDisplay(weaponInfo);
		}
	}
}
