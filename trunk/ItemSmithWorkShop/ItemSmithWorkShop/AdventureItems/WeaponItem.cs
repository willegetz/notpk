using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems;

namespace AdventureItems
{
	public class WeaponItem : AdventureItem
	{
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
			name = weapon.GetName();
			cost = weapon.GetCost();
			weight = weapon.GetWeight();
			description = weapon.GetDescription();

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

		internal string GetName()
		{
			return name;
		}

		public double GetCost()
		{
			return cost;
		}

		public double GetWeight()
		{
			return weight;
		}

		public string GetDescription()
		{
			return description;
		}

		public override string GetItem()
		{
			return string.Format("{0}:\t'{1} gp\r\nWeight: '{2} pound(s)'\r\nDamage: '{4}'\r\n\t{3}", name, cost, weight, description, damage);
		}
	}
}