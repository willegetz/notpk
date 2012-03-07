using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.Interfaces
{
	interface IWeaponEnchantment
	{
		string EnchantmentName { get; }
		string Affix { get; }
		int CostModifier { get; }
		string WeaponUse { get; }
		string StandardDamageBonus { get; }
		string CriticalDamageBonus { get; }
		string DamageType { get; }
		string MagicAura { get; }
		int MinimumCasterLevel { get; }
		string RequiredFeats { get; }
		string RequiredSpells { get; }
		string AdditionalRequirements { get; }
		string EnchantmentNotes { get; }
	}
}
