using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop.WeaponOrder
{
	class WeaponHead : LineItem
	{
		WeaponData weaponData;
		List<WeaponData> data;

		public WeaponHead(string name)
		{
			weaponData = TempWeaponDictionary.GetWeaponData(name);
		}

		public override string WeaponHeadName()
		{
			return weaponData.WeaponName;
		}

		public override string Category()
		{
			return weaponData.WeaponCategory;
		}

		public override string ProficiencyRequirement()
		{
			return weaponData.WeaponProficiencyRequirement;
		}

		public override string Damage()
		{
			return weaponData.WeaponDamage;
		}

		public override string DamageType()
		{
			return weaponData.WeaponDamageType;
		}

		public override string ThreatRange()
		{
			return weaponData.WeaponThreatRange;
		}

		public override string CriticalMultiplier()
		{
			return weaponData.WeaponCritical;
		}

		public override string ToString()
		{
			List<int> stringLength = new List<int>();

			var sb = new StringBuilder();

			sb.Append(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", WeaponHeadName(), Category(), ProficiencyRequirement(), Damage(), DamageType(), ThreatRange(), CriticalMultiplier()));
			
			return sb.ToString();

		}
	}
}
