using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponData
	{
		public string WeaponName { get; set; }
		public string WeaponCategory { get; set; }
		public string WeaponProficiencyRequirement { get; set; }
		public string WeaponDamage { get; set; }
		public string WeaponThreatRange { get; set; }
		public string WeaponCritical { get; set; }
		public string WeaponDamageType { get; set; }
		public double WeaponHardness { get; set; }
		public double WeaponHitPoints { get; set; }
		public double BasePrice { get; set; }
		public double WeaponWeight { get; set; }
		public string WeaponText { get; set; }

		public string RangeIncrement { get; set; }
	}
}