using System;
using System.Collections.Generic;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems
{
	public class WeaponOrder
	{
		private string Name; //required
		private double Cost; //required
		public string Damage { get; private set; }
		public string ThreatRange { get; private set; }
		public string Critical { get; private set; }
		public string Range { get; private set; }
		public double Weight; //required
		public string DamageType { get; private set; }
		public string Description; //required
		public string Proficiency { get; private set; }
		public string Category { get; private set; }
		public double Hardness { get; private set; }
		public double HitPoints { get; private set; }

		public string Part { get; private set; }

		public WeaponOrder(WeaponData weaponData)
		{
			WeaponInformation(weaponData);
		}

		private void WeaponInformation(WeaponData data)
		{
			Name = data.WeaponName;
			Cost = data.BasePrice;
			Damage = data.WeaponDamage;
			ThreatRange = data.WeaponThreatRange;
			Critical = data.WeaponCritical;
			Range = data.RangeIncrement;
			Weight = data.WeaponWeight;
			DamageType = data.WeaponDamageType;
			Description = data.WeaponText;
			Proficiency = data.WeaponProficiencyRequirement;
			Category = data.WeaponCategory;
			Hardness = data.WeaponHardness;
			HitPoints = data.WeaponHitPoints;
			Part = data.WeaponPart;

		}

		internal string GetName()
		{
			return Name;
		}
		
		public double GetCost()
		{
			return Cost;
		}

		public double GetWeight()
		{
			return Weight;
		}

		public string GetDescription()
		{
			return Description;
		}
	}
}
