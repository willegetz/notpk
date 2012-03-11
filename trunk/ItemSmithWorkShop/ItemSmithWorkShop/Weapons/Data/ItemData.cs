using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.Data
{
	public class ItemData
	{
		private static Dictionary<string, WeaponTemplate> weaponData;

		static ItemData()
		{
			LoadWeaponData();
		}

		private static void LoadWeaponData()
		{
			weaponData = new Dictionary<string, WeaponTemplate>(StringComparer.OrdinalIgnoreCase)
			             	{
			             		{ "Dagger",
			             			new WeaponTemplate {
			             					weaponName = "Dagger",
			             					proficiency = "Simple",
			             					weaponUse = "Melee",
			             					weaponCategory = "Light",
			             					weaponSubCategory = "Thrown",
			             					weaponSize = "Medium",
			             					weaponCost = 2,
											damage = "1d4",
											threatRangeLowerBound = 19,
											criticalDamage = "x2",
											rangeIncrement = 10,
											maxRange = 0,
											weight = 1,
											damageType = "Piercing or Slashing",
											specialInfo = "+2 bonus on Sleight of Hand checks made to conceal a\n\tdagger on your body"
														}
			             		}
							};
		}



		public static WeaponTemplate RetrieveWeaponTemplate(string weaponKey)
		{
			return weaponData[weaponKey];
		}
	}
}
