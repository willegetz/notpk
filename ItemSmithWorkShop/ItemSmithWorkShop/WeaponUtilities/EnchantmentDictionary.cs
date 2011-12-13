using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class EnchantmentDictionary : AdventureItem
	{
		private static Dictionary<string, EnchantmentData> weaponEnchantments;

		static EnchantmentDictionary()
		{
			LoadWeaponEnchantments();
		}

		public static EnchantmentData GetEnchantmentData(string enchantment)
		{
			return weaponEnchantments[enchantment];
		}

		private static void LoadWeaponEnchantments()
		{
			weaponEnchantments = new Dictionary<string,EnchantmentData>(StringComparer.OrdinalIgnoreCase)
			{
				{"Flaming", new EnchantmentData { EnchantmentName = "Flaming", EnchantmentDamage = "1D6", MinimumCasterLevel = 10, EnhancementBonus = 1,
				DamageType = "Fire", CreationRequirements = "\tRequired Feats: Craft Magic Arms and Armor\n\tRequired Spells: flame blade, flame strike, or fireball",
				EnchantmentDescription = "\n\n\tUpon command, a flaming weapon is sheathed in fire.\n\tThe fire does not harm the wielder. The effect\n\tremains until another command is given."}
			}
		};
	}
}
