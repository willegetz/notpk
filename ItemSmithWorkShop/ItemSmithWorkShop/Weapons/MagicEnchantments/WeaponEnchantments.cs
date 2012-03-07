using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.MagicEnchantments
{
	interface WeaponEnchantments
	{
		// Weapon enchantments cannot be added unless the weapon is already a Plus 1 value
		// Weapon enchantments can be either a prefix or a suffix.
		// Enchantments have a Plus value which affects the total value of the weapon
		// Enchantments are either for Ranged weapons, or melee weapons
		//		Thrown and Projectile and Ammunition included
		// Enchantments usually do additional damage on a standard hit.
		// Enchantments can do additional damage on a critical hit
		// The enchantments have other effects that appear in the description
		// At least one enchantment affects the threat range of a weapon
		// Enchantments have an aura
		// Enchantments have a minimum caster level
		// Enchantments have feat and spell requirements to create
		// Enchantments may have additional requirements as well

		string EnchantmentName { get; }
		string Affix { get; }
		int CostModifier { get; }
		string WeaponUse { get; }
		string StandardDamageBonus { get; }
		string CriticalDamageBonus { get; }
		string MagicAura { get; }
		int MinimumCasterLevel { get; }
		string RequiredFeats { get; }
		string RequiredSpells { get; }
		string AdditionalRequirements { get; }
	}
}
