using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class AlchemicalSilverWeaponItem : WeaponItemWeaver
	{
		private const string SilverNmaePrefix = "Alchemical Silver ";
		private const int SilverCostModifier = 20;
		private const string SilverDamageModifier = " -1";
		WeaponItemWeaver weaponItem;

		public AlchemicalSilverWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return SilverNmaePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + SilverCostModifier;
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage() + SilverDamageModifier;
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + "\r\n\tAlchemical Silver bypasses damage reduction on lycanthropes";
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nDamage: '{3}'\r\n\t{4}", GetName(), GetCost(), weaponItem.GetWeight(), GetDamage(), GetDescription());
		}
	}
}
