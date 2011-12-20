using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class AlchemicalSilverWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string SilverNmaePrefix = "Alchemical Silver ";
		private const int SilverCostModifier = 20;
		
		private const int SilverDamageModifier = -1;
		private const string SilverDescription = "\r\n\tAlchemical Silver bypasses damage reduction on lycanthropes";

		public AlchemicalSilverWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return SilverNmaePrefix + weaponItem.GetName();
		}

		public override bool IsMasterwork()
		{
			return false;
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + SilverCostModifier;
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override int GetDamageModifier()
		{
			return SilverDamageModifier;
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
			return weaponItem.GetDescription() + SilverDescription;
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4} {5}'\r\n\t{6}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDamageModifier(), GetDescription());
		}
	}
}
