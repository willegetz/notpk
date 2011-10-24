using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	class GenericWeapon1
	{
		private WeaponData data;

		public GenericWeapon1(){}

		public GenericWeapon1(WeaponData weaponData)
		{
			data = weaponData;
		}

		public double PriceAdjustment(double price, double adjustment)
		{
			price += adjustment;

			return price;
		}

		public void PutWeaponStuffInString(WeaponData weaponData)
		{
			data = weaponData;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append(String.Format("WeaponName:\t\t\t\t\t\t{0}\n", data.WeaponName));
			sb.Append(String.Format("WeaponPart:\t\t\t\t\t\t{0}\n", data.WeaponPart));
			sb.Append(String.Format("WeaponCategory:\t\t\t\t\t{0}\n", data.WeaponCategory));
			sb.Append(String.Format("WeaponProficiencyRequirement:\t{0}\n", data.WeaponProficiencyRequirement));
			sb.Append(String.Format("WeaponDamage:\t\t\t\t\t{0}\n", data.WeaponDamage));
			sb.Append(String.Format("WeaponThreatRange:\t\t\t\t{0}\n", data.WeaponThreatRange));
			sb.Append(String.Format("WeaponCritical:\t\t\t\t\t{0}\n", data.WeaponCritical));
			sb.Append(String.Format("WeaponDamageType:\t\t\t\t{0}\n", data.WeaponDamageType));
			sb.Append(String.Format("WeaponHardness:\t\t\t\t\t{0}\n", data.WeaponHardness));
			sb.Append(String.Format("WeaponHitPoints:\t\t\t\t{0}\n", data.WeaponHitPoints));
			sb.Append(String.Format("BasePrice:\t\t\t\t\t\t{0}\n", data.BasePrice));
			sb.Append(String.Format("WeaponWeight:\t\t\t\t\t{0}\n", data.WeaponWeight));
			sb.Append(String.Format("WeaponText:\t\t{0}\n", data.WeaponText));
			sb.Append(String.Format("RangeIncrement:\t\t\t\t\t{0}", data.RangeIncrement));

			return sb.ToString();
		}
	}
}

//WeaponName { get; set; }
//WeaponPart { get; set; }
//WeaponCategory { get; set; }
//WeaponProficiencyRequirement
//WeaponDamage { get; set; }
//WeaponThreatRange { get; set
//WeaponCritical { get; set; }
//WeaponDamageType { get; set;
//WeaponHardness { get; set; }
//WeaponHitPoints { get; set; 
//BasePrice { get; set; }
//WeaponWeight { get; set; }
//WeaponText { get; set; }

//RangeIncrement { get; set; }
