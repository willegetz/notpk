using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MasterworkWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string MasterworkNamePrefix = "Masterwork ";
		private const int MasterworkCost = 300;
		
		private const string ToHitBonus = "+1";
		private const string MasterworkDescription = "A masterwork {0} has an additional +1 to hit.\r\n\t";


		public MasterworkWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return MasterworkNamePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return MasterworkCost + weaponItem.GetCost();
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override string GetDescription()
		{
			return string.Format(MasterworkDescription, weaponItem.GetName()) + weaponItem.GetDescription();
		}

		public override string GetToHit()
		{
			return ToHitBonus;
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
