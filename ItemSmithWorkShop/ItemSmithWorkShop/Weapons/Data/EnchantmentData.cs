using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.Data
{
	public class EnchantmentData
	{
		private static Dictionary<string, WeaponEnchantmentTemplate> weaponEnchantmentData;

		static EnchantmentData()
		{
			LoadWeaponEnchantmentData();
		}

		private static void LoadWeaponEnchantmentData()
		{
			weaponEnchantmentData = new Dictionary<string, WeaponEnchantmentTemplate>(StringComparer.OrdinalIgnoreCase)
								{
									{"Anarchic",
										 new WeaponEnchantmentTemplate{
											 enchantmentName = "Anarchic",
											 affix = "Pre",
											 costModifier = 2,
											 weaponUse = "Melee, Ranged",
											 standardDamageBonus = "2d6 vs. Lawful Alignment",
											 criticalDamageBonus = false,
											 damageType = "Chaotic",
											 magicAura = "Moderate evocation [chaotic]",
											 minimumCasterLevel = 7,
											 requiredFeats = "Craft Magic Arms and Armor",
											 requiredSpells = "chaos hammer",
											 additionalRequirements = "Creator must be chaotic",
											 enchantmentNotes = "-1 temporary level to any wielder of Lawful Alignment. Level loss cannot be overcome in any way while the weapon is wielded.",
										 }
									},
									{"Flaming Burst",
										new WeaponEnchantmentTemplate{
											enchantmentName = "Flaming Burst",
											affix = "Suf",
											costModifier = 2,
											weaponUse = "Melee, Ranged",
											standardDamageBonus = "1d6",
											criticalDamageBonus = true,
											damageType = "Fire",
											magicAura = "Strong evocation",
											minimumCasterLevel = 12,
											requiredFeats = "Craft Magic Arms and Armor",
											requiredSpells = "flame blade, flame strike, or fireball",
										}
									},
								};
		}

		public static WeaponEnchantmentTemplate RetrieveWeaponEnchantment(string enchantmentKey)
		{
			return weaponEnchantmentData[enchantmentKey];
		}
	}
}
