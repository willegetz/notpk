using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Weapons.Interfaces;

namespace ItemSmithWorkShop.Weapons
{
	public class ForgedWeapon : IWeapon1
	{
		public string Proficiency { get; private set; }
		public string WeaponUse { get; private set; }
		public string WeaponCategory { get; private set; }
		public string WeaponSubCategory { get; private set; }
		public string WeaponSize { get; private set; }

		public string WeaponName { get; private set; }
		public double WeaponCost { get; private set; }
		public string Damage { get; private set; }
		public string ThreatRange { get; private set; }
		public string CriticalDamage { get; private set; }
		public double RangeIncrement { get; private set; }
		public double MaxRange { get; private set; }
		public double Weight { get; private set; }
		public string DamageType { get; private set; }
		public string SpecialInfo { get; private set; }

		public string GivenName { get; private set; }

		public void SetWeaponName(string forgedWeaponName)
		{
			WeaponName = forgedWeaponName;
		}
	}
}
