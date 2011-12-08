using System;
using System.Collections.Generic;
using System.Linq;

namespace ItemSmithWorkShop.AdventureItems
{
	public class WeaponOrder
	{
		private double BasePrice;
		private string RangeIncrement;
		private string WeaponCategory;
		private string WeaponCritical;
		private string WeaponDamage;
		private string WeaponDamageType;
		private double WeaponHardness;
		private double WeaponHitPoints;
		private string WeaponName;
		private string WeaponPart;
		private string WeaponProficiencyRequirement;
		private string WeaponText;
		private string WeaponThreatRange;
		private double WeaponWeight;

		public WeaponOrder(WeaponData weaponData)
		{
			WeaponInformation(weaponData);
		}

		private void WeaponInformation(WeaponData data)
		{
			WeaponName = data.WeaponName;
			WeaponPart = data.WeaponPart;
			WeaponCategory = data.WeaponCategory;
			WeaponProficiencyRequirement = data.WeaponProficiencyRequirement;
			WeaponDamage = data.WeaponDamage;
			WeaponThreatRange = data.WeaponThreatRange;
			WeaponCritical = data.WeaponCritical;
			WeaponDamageType = data.WeaponDamageType;
			WeaponHardness = data.WeaponHardness;
			WeaponHitPoints = data.WeaponHitPoints;
			BasePrice = data.BasePrice;
			WeaponWeight = data.WeaponWeight;
			WeaponText = data.WeaponText;
			RangeIncrement = data.RangeIncrement;
		}

		internal string GetName()
		{
			return WeaponName;
		}
		public double GetCost()
		{
			return BasePrice;
		}
	}
}
