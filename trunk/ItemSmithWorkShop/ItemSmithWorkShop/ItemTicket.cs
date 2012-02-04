using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop
{
	public class ItemTicket
	{
		internal static object GetWeaponTicket(string weaponName)
		{
			return DisplayUtilities.BasicDisplay(TempWeaponDictionary.GetWeaponData(weaponName));
		}

		public static object GetMaterialIngot(string ingotName)
		{
			return DisplayUtilities.BasicIngotDisplay(MaterialComponentDictionary.GetComponentData(ingotName));
		}

		public static object GetSpecialAbilityTicket(string specialAbilityName)
		{
			var specialAbilityInfo = EnchantmentDictionary.GetEnchantmentData(specialAbilityName);
			return DisplayUtilities.BasicSpecialAbilityDisplay(specialAbilityInfo);
		}
	}
}
