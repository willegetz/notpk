﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponUtilities;
using ExtraordinaryWeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.ExtraordinaryWeaponUtilities
{
	public class ExtraordinaryQualityWeapon : WeaponItemWeaver
	{
		WeaponItemWeaver weapon;
		MaterialComponentOrder component;

		public ExtraordinaryQualityWeapon(WeaponItemWeaver weaponItem, MaterialComponentOrder materialComponent)
		{
			weapon = weaponItem;
			component = materialComponent;
		}

		public override bool IsMasterwork()
		{
			return component.IsMasterwork;
		}

		public override string GetName()
		{
			return component.Name + weapon.GetName();
		}

		public override double GetCost()
		{
			return weapon.GetCost() + component.MasterworkCost + component.CostModifier;
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return component.AdditionalCostModifier;
		}

		public override string GetToHit()
		{
			return component.ToHit;
		}

		// required for display
		public override string GetDamage()
		{
			return weapon.GetDamage();
		}

		public override int GetDamageModifier()
		{
			return component.DamageModifier;
		}

		// required for display
		public override double GetWeight()
		{
			return weapon.GetWeight() * component.WeightModifier;
		}

		public override string GetDescription()
		{
			return string.Format(component.Description, weapon.GetName()) + weapon.GetDescription();
		}

		public override string GetThreat()
		{
			return weapon.GetThreat();
		}

		public override string GetCriticalMultiplier()
		{
			return weapon.GetCriticalMultiplier();
		}

		public override string GetDamageType()
		{
			return weapon.GetDamageType();
		}

		public override double GetHardness()
		{
			return weapon.GetHardness();
		}

		public override double GetHitPoints()
		{
			return weapon.GetHitPoints();
		}

		internal string GetItem()
		{
			if (GetDamageModifier() != 0)
			{
				return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDamageModifier(), GetDescription());
			}
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}