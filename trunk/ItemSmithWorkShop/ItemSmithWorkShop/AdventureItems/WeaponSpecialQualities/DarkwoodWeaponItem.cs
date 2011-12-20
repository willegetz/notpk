using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class DarkwoodWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string DarkwoodNamePrefix = "Darkwood ";
		private const int DarkwoodCostModifier = 10;
		private const int MasterworkCostModifier = 300;
		
		private const double DarkwoodWeightModifier = .5;
		private const string ToHitModifier = "+1";
		private double weight;

		public DarkwoodWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
			weight = weaponItem.GetWeight();
		}

		public override string GetName()
		{
			return DarkwoodNamePrefix + weaponItem.GetName();
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (weight * DarkwoodCostModifier) + MasterworkCostModifier;
		}

		public override double GetWeight()
		{
			
			return weight * DarkwoodWeightModifier;
		}

		public string GetToHit()
		{
			return ToHitModifier;
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

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + "\r\n\tDarkwood weapons are always considered to be masterwork quality.";
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
