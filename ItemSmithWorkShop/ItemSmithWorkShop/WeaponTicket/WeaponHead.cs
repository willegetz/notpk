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
		public List<int> columnLengths;
		public List<T> dataValues;

		public WeaponHead(string name)
		{
			weaponData = TempWeaponDictionary.GetWeaponData(name);
			columnLengths = new List<int>();
			dataValues = new List<T>();
			WeaponName = weaponData.WeaponName;
			Category = weaponData.WeaponCategory;
			ProficiencyRequirement = weaponData.WeaponProficiencyRequirement;

			AddValuesToCollection();
		}

		public override string WeaponName
		{
			get
			{
				return weaponName;
			}
			set
			{
				weaponName = value;
				weaponNameLength = weaponName.Length;
				columnLengths.Add(weaponNameLength);
			}
		}

		public override string Category
		{
			get
			{
				return category;
			}
			set
			{
				category = value;
				categoryLength = category.Length;
				columnLengths.Add(categoryLength);
			}
		}

		public override string ProficiencyRequirement
		{
			get
			{
				return proficiency;
			}
			set
			{
				proficiency = value;
				proficiencyLength = proficiency.Length;
				columnLengths.Add(proficiencyLength);
			}
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
			var sb = new StringBuilder();

			sb.Append(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}\n", WeaponName, Category, ProficiencyRequirement, Damage(), DamageType(), ThreatRange(), CriticalMultiplier()));
			
			return sb.ToString();
		}
	}
}
