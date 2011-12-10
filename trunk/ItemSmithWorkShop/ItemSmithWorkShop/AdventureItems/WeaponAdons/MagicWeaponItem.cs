using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MagicWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;
		private int enhancementBonus;

		public MagicWeaponItem(WeaponItemWeaver weapon, int bonus)
		{
			weaponItem = weapon;
			enhancementBonus = bonus;
		}

		public override string GetName()
		{
			return string.Format("+{0} {1}", enhancementBonus, weaponItem.GetName());
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (Math.Pow(enhancementBonus, 2) * 2000);
		}

		public override string GetDamage()
		{
			return string.Format("{0} +{1}", weaponItem.GetDamage(), enhancementBonus);
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '+{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), weaponItem.GetWeight(), enhancementBonus, GetDamage(), weaponItem.GetDescription());
		}
	}
}
