using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class AdamantineWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string ComponentName = "Adamantine ";
		private const int ComponentCostModifier = 3000;
		private const int MasterworkCostModifier = 0;
		private const double ComponentWeightModifier = 1.33;
		private const string ToHitBonus = "+1";
		private const int ComponentDamageModifier = 0;
		private const string ComponentDescription = "\r\n\tAdamantine weapons are always considered to be masterwork quality.\r\n\tAdamantine bypasses a damage reduction of 20.";

		public AdamantineWeaponItem(WeaponItemWeaver weapon)
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
			return weaponItem.GetCost() + ComponentCostModifier;
		}

		public override string GetToHit()
		{
			return ToHitBonus;
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override string GetThreat()
		{
			return weaponItem.GetThreat();
		}

		public override string GetCriticalMultiplier()
		{
			return weaponItem.GetCriticalMultiplier();
		}

		public override string GetDamageType()
		{
			return weaponItem.GetDamageType();
		}

		public override double GetHardness()
		{
			return weaponItem.GetHardness();
		}

		public override double GetHitPoints()
		{
			return weaponItem.GetHitPoints();
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight() * ComponentWeightModifier;
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + ComponentDescription;
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
