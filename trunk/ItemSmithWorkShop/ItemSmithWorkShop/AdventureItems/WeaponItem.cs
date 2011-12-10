﻿using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
    public class WeaponItem : WeaponItemWeaver
	{
		private string name;
		private double cost;
		private double weight;
		private string description;
		private string damage;
		private string threatRange;
		private string critical;
		private string range;
		private string damageType;
		private string proficiency;
		private string category;
		private double hardness;
		private double hitPoints;

		public WeaponItem(WeaponOrder weapon)
		{
			name = weapon.Name;
			cost = weapon.Cost;
			weight = weapon.Weight;
			description = weapon.Description;
			damage = weapon.Damage;
			threatRange = weapon.ThreatRange;
			critical = weapon.Critical;
			range = weapon.Range;
			damageType = weapon.DamageType;
			proficiency = weapon.Proficiency;
			category = weapon.Category;
			hardness = weapon.Hardness;
			hitPoints = weapon.HitPoints;
		}

		public override string GetName()
		{
			return name;
		}

		public override double GetCost()
		{
			return cost;
		}

		public override double GetWeight()
		{
			return weight;
		}

		public override string GetDescription()
		{
			return description;
		}

		public override string GetDamage()
		{
			return damage;
		}

		public string GetItem()
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nDamage: '{3}'\r\n\t{4}", name, cost, weight, damage, description);
		}
	}
}