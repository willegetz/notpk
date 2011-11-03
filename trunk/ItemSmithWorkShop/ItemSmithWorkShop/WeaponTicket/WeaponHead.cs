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
		public List<double> dataValues;
		public List<string> descriptions;

		public WeaponHead(string name)
		{
			weaponData = TempWeaponDictionary.GetWeaponData(name);
			columnLengths = new List<int>();
			dataValues = new List<double>();
			descriptions = new List<string>();
			WeaponName = weaponData.WeaponName;
			Category = weaponData.WeaponCategory;
			ProficiencyRequirement = weaponData.WeaponProficiencyRequirement;
			Damage = weaponData.WeaponDamage;
			DamageType = weaponData.WeaponDamageType;

			//AddValuesToCollection();
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
				descriptions.Add(weaponName);
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
				descriptions.Add(category);
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
				descriptions.Add(proficiency);
				proficiencyLength = proficiency.Length;
				columnLengths.Add(proficiencyLength);
			}
		}

		public override string Damage
		{
			get
			{
				return damage;
			}
			set
			{
				damage = value;
				descriptions.Add(damage);
				damageLength = damage.Length;
				columnLengths.Add(damageLength);
			}
		}

		public override string DamageType
		{
			get
			{
				return damageType;
			}
			set
			{
				damageType = value;
				descriptions.Add(damageType);
				damageTypeLength = damageType.Length;
				columnLengths.Add(damageTypeLength);
			}
		}

		public override int ColumnWidth { get; set; }

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

			sb.Append(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", WeaponName.PadLeft(ColumnWidth), Category.PadLeft(ColumnWidth), ProficiencyRequirement.PadLeft(ColumnWidth), Damage.PadLeft(ColumnWidth), DamageType.PadLeft(ColumnWidth), ThreatRange().PadLeft(ColumnWidth), CriticalMultiplier().PadLeft(ColumnWidth)));
			
			return sb.ToString();
		}
	}
}
