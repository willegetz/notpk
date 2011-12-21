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

		private const string ComponentName = "Alchemical Silver ";
		private const int ComponentCostModifier = 20;
		private const int MasterworkCostModifier = 0;
		private const double ComponentWeightModifier = 1;
		private const string ToHitBonus = "";
		private const int ComponentDamageModifier = -1;
		private const string ComponentDescription = "\r\n\tAlchemical Silver bypasses damage reduction on lycanthropes";

		public AlchemicalSilverWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override bool IsMasterwork()
		{
			return false;
		}

		public override string GetName()
		{
			return ComponentName + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + ComponentCostModifier;
		}

		// To Hit

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		public override int GetDamageModifier()
		{
			return ComponentDamageModifier;
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
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4} {5}'\r\n\t{6}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDamageModifier(), GetDescription());
		}
	}
}
