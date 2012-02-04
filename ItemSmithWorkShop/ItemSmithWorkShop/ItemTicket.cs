using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop
{
	public class ItemTicket
	{
		internal static object GetWeaponTicket(string weaponName)
		{
			var weaponInfo = TempWeaponDictionary.GetWeaponData(weaponName);
			return DisplayUtilities.BasicDisplay(weaponInfo);
		}

		public static object GetMaterialIngot(string ingotName)
		{
			var ingotInfo = MaterialComponentDictionary.GetComponentData(ingotName);
			return DisplayUtilities.BasicIngotDisplay(ingotInfo);
		}
	}
}
