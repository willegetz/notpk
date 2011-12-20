using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class AdamantineWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string AdamantineNamePrefix = "Adamantine ";
		private const int AdamantineCostModifier = 3000;
		private const double AdamantineWeightModifier = 1.33;
		
		private const string ToHitBonus = "+1";

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
			return AdamantineNamePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + AdamantineCostModifier;
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight() * AdamantineWeightModifier;
		}

		public string GetToHit()
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

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + "\r\n\tAdamantine weapons are always considered to be masterwork quality.\r\n\tAdamantine bypasses a damage reduction of 20.";
		}

		internal string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
