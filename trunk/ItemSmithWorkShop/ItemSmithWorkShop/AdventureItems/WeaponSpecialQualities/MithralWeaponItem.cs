using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MithralWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string MithralNamePrefix = "Mithral ";
		private const int MithralCostModifier = 500;

		private const double MithralWeightModifier = .5;
		private const string ToHitModifier = "+1";
		private const string MithralDescription = "\r\n\tMithral weapons are always considered to be masterwork quality.";

		public MithralWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override string GetName()
		{
			return MithralNamePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + (weaponItem.GetWeight() * MithralCostModifier);
		}

		public override string GetToHit()
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

		public override double GetWeight()
		{
			return weaponItem.GetWeight() * MithralWeightModifier;
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription() + MithralDescription;
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
