using System;
using System.Linq;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites
{
	public class WeaponItem : WeaponItemWeaver
	{
		private readonly WeaponOrder order;
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
			order = weapon;

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

		public override bool IsMasterwork()
		{
			return false;
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

		public override string GetThreat()
		{
			return threatRange;
		}

		public override string GetCriticalMultiplier()
		{
			return critical;
		}

		public override string GetDamageType()
		{
			return damageType;
		}

		public override double GetHardness()
		{
			return hardness;
		}

		public override double GetHitPoints()
		{
			return hitPoints;
		}

		internal void SetName(string sizeKey)
		{
			name = string.Format("{0} [{1}]", name, sizeKey);
		}

		internal void SetCost(double sizeMultiplier)
		{
			cost = (cost * sizeMultiplier);
		}

		internal void SetHardness(double sizeMultiplier)
		{
			hardness = (hardness * sizeMultiplier);
		}

		internal void SetWeight(double sizeMultiplier)
		{
			weight = (weight * sizeMultiplier);
		}

		internal void SetHitPoints(double sizeMultiplier)
		{
			hitPoints = (hitPoints * sizeMultiplier);
		}

		internal void SetDamage(string newDamage)
		{
			damage = newDamage;
		}
	}
}