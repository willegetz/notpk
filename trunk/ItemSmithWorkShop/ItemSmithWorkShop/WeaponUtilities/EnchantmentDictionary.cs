using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.AdventureItems;

namespace MagicWeaponUtilities
{
	public class EnchantmentDictionary : AdventureItem
	{
		private const string requiredFeats = "Craft Magic Arms and Armor";
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
			weaponEnchantments = new Dictionary<string, EnchantmentData>(StringComparer.OrdinalIgnoreCase)
			{
				{"Flaming", new EnchantmentData { EnchantmentName = "Flaming", EnchantmentDamage = " +1D6", MinimumCasterLevel = 10, EnhancementBonus = 1,
				DamageType = "Fire", CreationRequirements = string.Format("\r\n\tRequired Feats: {0}\r\n\tRequired Spells: flame blade, flame strike, or fireball", requiredFeats),
				EnchantmentDescription = "\n\n\tUpon command, a flaming weapon is sheathed in fire.\r\n\tThe fire does not harm the wielder. The effect\r\n\tremains until another command is given." }
				},
				{"Icy Burst", new EnchantmentData { EnchantmentName = "Icy Burst", EnchantmentCriticalDamage = " +1d10", MinimumCasterLevel = 10, EnhancementBonus = 2,
				DamageType = "Cold", CreationRequirements = string.Format("\r\n\tRequired Feats: {0}\r\n\tRequired Spells: chill metal or ice storm", requiredFeats),
				EnchantmentDescription = "\n\n\tAn icy burst weapon functions as a frost weapon that also\r\n\texplodes with frost upon striking a successful critical hit.\r\n\tThe frost does not harm the wielder. In addition to the extra\r\n\tdamage from the frost ability, an icy burst weapon deals an\r\n\textra 1d10 points of cold damage on a successful critical hit.\r\n\tIf the weapon’s critical multiplier is ×3, add an extra 2d10\r\n\tpoints of cold damage instead, and if the multiplier is ×4,\r\n\tadd an extra 3d10 points. Bows, crossbows, and slings so\r\n\tcrafted bestow the cold energy upon their ammunition.\r\n\tEven if the frost ability is not active, the weapon still\r\n\tdeals its extra cold damage on a successful critical hit."}
				},
			};
		}
	}
}
