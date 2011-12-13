using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems
{
	public class WeaponEnchanter
	{

		private WeaponEnchantment RequestEnchantment(string enchantment)
		{
			return new WeaponEnchantment(new EnchantmentOrder(EnchantmentDictionary.GetEnchantmentData(enchantment));
		}
	}
}
