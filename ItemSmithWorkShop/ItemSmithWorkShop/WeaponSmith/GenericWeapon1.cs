using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	class GenericWeapon1
	{
		private WeaponData data;

		public GenericWeapon1(WeaponData weaponData)
		{
			data = weaponData;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();

			sb.Append(String.Format("WeaponName:\t\t{0}\n", data.WeaponName.ToString()));
			sb.Append(String.Format("WeaponPart:\t\t{0}\n", data.WeaponPart));
			sb.Append(String.Format("WeaponCategory:\t\t{0}\n", data.WeaponCategory.ToString()));
			sb.Append(String.Format("WeaponProficiencyRequirement:\t\t{0}\n", data.WeaponProficiencyRequirement.ToString()));
			sb.Append(String.Format("WeaponDamage:\t\t{0}\n", data.WeaponDamage.ToString()));
			sb.Append(String.Format("WeaponThreatRange:\t\t{0}\n", data.WeaponThreatRange.ToString()));
			sb.Append(String.Format("WeaponCritical:\t\t{0}\n", data.WeaponCritical.ToString()));
			sb.Append(String.Format("WeaponDamageType:\t\t{0}\n", data.WeaponDamageType.ToString()));
			sb.Append(String.Format("WeaponHardness:\t\t{0}\n", data.WeaponHardness.ToString()));
			sb.Append(String.Format("WeaponHitPoints:\t\t{0}\n", data.WeaponHitPoints.ToString()));
			sb.Append(String.Format("BasePrice:\t\t{0}\n", data.BasePrice.ToString()));
			sb.Append(String.Format("WeaponWeight:\t\t{0}\n", data.WeaponWeight.ToString()));
			sb.Append(String.Format("WeaponText:\t\t{0}\n", data.WeaponText.ToString()));
			sb.Append(String.Format("RangeIncrement:\t\t{0}", data.RangeIncrement));

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
