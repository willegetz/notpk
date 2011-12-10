using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MithralWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		public MithralWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return "Mithral " + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (weaponItem.GetWeight() * 500);
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight() / 2;
		}

		public string GetToHit()
		{
			return "+1";
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + "\r\n\tMithral weapons are always considered to be masterwork quality.";
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		internal string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
