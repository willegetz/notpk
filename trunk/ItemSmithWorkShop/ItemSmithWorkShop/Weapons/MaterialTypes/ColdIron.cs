using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.MaterialTypes
{
	public class ColdIron
	{
		// Cold iron is not for armor.
		// Cold iron weapons cost twice as much to make.
		//		A weapon that costs 2 gold pieces to make cost 4 if they are made of cold iron.
		// Magic enchantments cost and additional 2,000 gold pieces.
		//		This additional cost is applied after the standard cost is deduced.
		// A double weapon that only has one head made of cold iron increases its price by 50%.
		// Cold iron has 30 points per inch of thickness and hardness of 10

		private const string materialName = "Cold Iron";
		private const double weaponBaseCostMultiplier = 2;
		private const double magicEnchantmentCostModification = 2000;

		public string MaterialName { get { return materialName; } }
		public double WeaponBaseCostMultiplier { get { return weaponBaseCostMultiplier; } }
		public double MagicEnchantmentCostModification { get { return magicEnchantmentCostModification; } }

		public override string ToString()
		{
			return string.Format("Material:{1}'{2}'{0}Cost Multiplier:{1}'x{3} to base cost'{0}Additional Cost to Enchant:{1}'{4} gold pieces'",
									Environment.NewLine,
									"\t",
									MaterialName,
									WeaponBaseCostMultiplier,
									MagicEnchantmentCostModification
								);
		}
	}
}
