using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.AdventureItems
{
	public class EnchantmentData
	{
		public string EnchantmentName = "Flaming";
		public string EnchantmentDamage = "1D6";
		public int MinimumCasterLevel = 10;
		public int EnhancementBonus = 1;
		public string DamageType = "Fire";
		public string CreationRequirements = "\tRequired Feats: Craft Magic Arms and Armor\n\tRequired Spells: flame blade, flame strike, or fireball";
		public string EnchantmentDescription = "\n\n\tUpon command, a flaming weapon is sheathed in fire.\n\tThe fire does not harm the wielder. The effect\n\tremains until another command is given.";
	}
}
