using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class ColdIronWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string ComponentName = "Cold Iron ";
		private const int ComponentCostModifier = 2;
		private const int MasterworkCostModifier = 0;
		private const double ComponentWeightModifier = 1;
		private const string ToHitBonus = "";
		private const int ComponentDamageModifier = 0;
		private const string ComponentDescription = "\r\n\tCold Iron is effective against some Fey.\r\n\tMagic enhancements cost an additional 2000 gold pieces.";

		private const int ColdIronAdditionalMagicCost = 2000;

		public ColdIronWeaponItem(WeaponItemWeaver weapon)
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
			return weaponItem.GetCost() * ComponentCostModifier;
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return ColdIronAdditionalMagicCost;
		}

		public override string GetToHit()
		{
			return weaponItem.GetToHit();
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
			return weaponItem.GetWeight();
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + ComponentDescription;
		}

		public string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription()); 
		}
	}
}
