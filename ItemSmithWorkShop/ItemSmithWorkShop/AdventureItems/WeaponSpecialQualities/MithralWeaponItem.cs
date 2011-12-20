using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MithralWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string MithralNamePrefix = "Mithral ";
		private const int MithralCostModifier = 500;

		private const double MithralWeightModifier = .5;

		public MithralWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return MithralNamePrefix + weaponItem.GetName();
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (weaponItem.GetWeight() * MithralCostModifier);
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight() * MithralWeightModifier;
		}

		public string GetToHit()
		{
			return "+1";
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
			return weaponItem.GetDescription() + "\r\n\tMithral weapons are always considered to be masterwork quality.";
		}

		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		internal string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
