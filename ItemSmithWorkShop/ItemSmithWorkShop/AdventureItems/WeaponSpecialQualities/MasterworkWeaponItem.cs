﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MasterworkWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;

		private const string MasterworkNamePrefix = "Masterwork ";
		private const int MasterworkCost = 300;
		
		private const string ToHitBonus = "+1";

		public MasterworkWeaponItem(WeaponItemWeaver weapon)
		{
			weaponItem = weapon;
		}

		public override string GetName()
		{
			return MasterworkNamePrefix + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return MasterworkCost + weaponItem.GetCost();
		}

		public override string GetDescription()
		{
			return string.Format("A masterwork {0} has an additional +1 to hit.\r\n\t", weaponItem.GetName()) + weaponItem.GetDescription();
		}

		public string GetToHit()
		{
			return ToHitBonus;
		}

		internal string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", GetName(), GetCost(), weaponItem.GetWeight(), GetToHit(), weaponItem.GetDamage(), GetDescription());
		}
	}
}