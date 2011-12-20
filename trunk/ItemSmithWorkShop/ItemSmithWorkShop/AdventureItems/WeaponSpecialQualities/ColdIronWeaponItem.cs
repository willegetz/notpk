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

		private const string ColdIronNamePrefix = "Cold Iron ";
		private const int ColdIronModifier = 2;
		private const int ColdIronAdditionalMagicCost = 2000;

		private const string ColdIronDescription = "\r\n\tCold Iron is effective against some Fey.\r\n\tMagic enhancements cost an additional 2000 gold pieces.";

		public ColdIronWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return ColdIronNamePrefix + weaponItem.GetName();
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() * ColdIronModifier;
		}

		public override string GetToHit()
		{
			return weaponItem.GetToHit();
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return ColdIronAdditionalMagicCost;
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

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + ColdIronDescription;
		}

		public string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription()); 
		}
	}
}
