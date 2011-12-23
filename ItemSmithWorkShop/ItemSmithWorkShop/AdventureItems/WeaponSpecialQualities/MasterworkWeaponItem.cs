using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MasterworkWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;
		MaterialComponentOrder materialComponent;

		public MasterworkWeaponItem(WeaponItemWeaver weapon, MaterialComponentOrder component)
		{
			weaponItem = weapon;
			materialComponent = component;
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override string GetName()
		{
			return materialComponent.Name + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + materialComponent.MasterworkCost;
		}

		public override string GetToHit()
		{
			return materialComponent.ToHit;
		}

		// required for display
		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		// required for display
		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDescription()
		{
			return string.Format(materialComponent.Description, weaponItem.GetName()) + weaponItem.GetDescription();
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
