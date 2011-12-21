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

		private const string ComponentName = "Masterwork ";
		private const int ComponentCostModifier = 0;
		private const int MasterworkCostModifier = 300;
		private const double ComponentWeightModifier = 1;
		private const string ToHitBonus = "+1";
		private const int ComponentDamageModifier = 0;
		private const string ComponentDescription = "A masterwork {0} has an additional +1 to hit.\r\n\t";


		public MasterworkWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override string GetName()
		{
			return ComponentName + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + MasterworkCostModifier;
		}

		public override string GetToHit()
		{
			return ToHitBonus;
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDescription()
		{
			return string.Format(ComponentDescription, weaponItem.GetName()) + weaponItem.GetDescription();
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
