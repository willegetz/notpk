using System;
using System.Collections.Generic;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MagicWeaponItem : WeaponItemWeaver
	{
		readonly WeaponItemWeaver weaponItem;
		private readonly int enhancementBonus;
		private readonly double additionalMagicalCost;

		public MagicWeaponItem(WeaponItemWeaver weapon, int bonus)
		{
			if (bonus < 1 || bonus > 5)
			{
				throw new ArgumentOutOfRangeException( "Bonus", bonus, "The Enhancement Bonus must be between 1 and 5");
			}
			weaponItem = weapon;
			enhancementBonus = bonus;
			additionalMagicalCost = weaponItem.GetAdditionalMagicCostModifier();
		}

		public override string GetName()
		{
			return string.Format("+{0} {1}", enhancementBonus, weaponItem.GetName());
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (Math.Pow(enhancementBonus, 2) * 2000) + additionalMagicalCost;
		}

		public override string GetDamage()
		{
			return string.Format("{0}{1}", weaponItem.GetDamage(), GetDamageModifier(enhancementBonus,  weaponItem.GetDamageModifier()));
		}

		private static string GetDamageModifier(int enhancement, int existantDamageModifier)
		{
			if (existantDamageModifier == -1)
			{
				return string.Format(" +{0}", existantDamageModifier + enhancement);
			}
			return string.Format(" +{0}", enhancement);
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '+{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), weaponItem.GetWeight(), enhancementBonus, GetDamage(), weaponItem.GetDescription());
		}
	}
}
