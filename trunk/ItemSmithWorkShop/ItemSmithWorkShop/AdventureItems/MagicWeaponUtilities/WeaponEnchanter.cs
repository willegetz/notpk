using System;
using System.Collections.Generic;
using System.Linq;
using MagicWeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems
{
	public class WeaponEnchanter
	{
		public static EnchantedWeaponItem RequestEnchantment(WeaponItemWeaver magicWeapon, string enchantment)
		{
			var newEnchantment = new WeaponEnchantment(new EnchantmentOrder(EnchantmentDictionary.GetEnchantmentData(enchantment)));
			return new EnchantedWeaponItem(magicWeapon, newEnchantment);
		}
	}
}
