using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.AdventureItemUtilities;

namespace ItemSmithWorkShop.WeaponUtilities
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
			weaponEnchantments = new Dictionary<string, EnchantmentData>(StringComparer.OrdinalIgnoreCase)
			{
				{
					"Flaming", new EnchantmentData
					{
						EnchantmentName = "Flaming", EnchantmentDamage = " +1D6", MinimumCasterLevel = 10, EnhancementBonus = 1,
						DamageType = "Fire", CreationRequirements = string.Format("\r\n\tRequired Spells: flame blade, flame strike, or fireball"),
						EnchantmentDescription = "\n\n\tUpon command, a flaming weapon is sheathed in fire.\r\n\tThe fire does not harm the wielder. The effect\r\n\tremains until another command is given."
					}
				},
				{
					"Icy Burst", new EnchantmentData
					{
						EnchantmentName = "Icy Burst", EnchantmentCriticalDamage = " +1d10", MinimumCasterLevel = 10, EnhancementBonus = 2,
						DamageType = "Cold", CreationRequirements = string.Format("\r\n\tRequired Spells: chill metal or ice storm"),
						EnchantmentDescription = "\n\n\tAn icy burst weapon functions as a frost weapon that also\r\n\texplodes with frost upon striking a successful critical hit.\r\n\tThe frost does not harm the wielder. In addition to the extra\r\n\tdamage from the frost ability, an icy burst weapon deals an\r\n\textra 1d10 points of cold damage on a successful critical hit.\r\n\tIf the weapon’s critical multiplier is ×3, add an extra 2d10\r\n\tpoints of cold damage instead, and if the multiplier is ×4,\r\n\tadd an extra 3d10 points. Bows, crossbows, and slings so\r\n\tcrafted bestow the cold energy upon their ammunition.\r\n\tEven if the frost ability is not active, the weapon still\r\n\tdeals its extra cold damage on a successful critical hit."
					}
				},
				{
					"Vorpal", new EnchantmentData 
					{
						EnchantmentName = "Vorpal", MinimumCasterLevel = 18, EnhancementBonus = 5, CreationRequirements = string.Format("\r\n\tRequired Spells: circle of death, keen edge"),
						EnchantmentDescription = "\n\n\tThis potent and feared ability allows the weapon to sever the heads of\r\n\tthose it strikes. Upon a roll of natural 20 (followed by a successful\r\n\troll to confirm the critical hit), the weapon severs the opponent's\r\n\thead (if it has one) from its body. Some creatures, such as many\r\n\taberrations and all oozes, have no heads. Others, such as golems\r\n\tand undead creatures other than vampires, are not affected by the\r\n\tloss of their heads. Most other creatures, however, die when their\r\n\theads are cut off.\r\n\tA vorpal weapon must be a slashing weapon."
					}
				},
			};
		}
	}
}
