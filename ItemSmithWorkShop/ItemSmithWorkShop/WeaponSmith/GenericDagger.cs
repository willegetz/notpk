using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class GenericDagger
	{
		WeaponSizing sizing;

		public double masterworkCostModifier = 300;
		private WeaponData weaponData;

		public string WeaponProficiencyRequirement { get; set; }
		public string WeaponCategory { get; set; }
		public string WeaponThreatRange { get; set; }
		public string WeaponCritical { get; set; }

		public string WeaponName { get; set; }
		public string WeaponType { get; set; }
		public string WeaponDamage { get; set; }
		public double WeaponHardness { get; set; }
		public double WeaponHitPoints { get; set; }
		public double WeaponWeight { get; set; }
		public double BasePrice { get; set; }

		public string WeaponSize { get; set; }
		public string WeaponDamageType { get; set; }
		public string WeaponText { get; set; }
		public string AdditionalText { get; set; }
		public string MasterWorkLabel { get; set; }
		public string MaterialName { get; set; }

		public int PlusEnhancementBonus { get; set; }

		public double MasterworkCost { get; set; }
		public double SpecialMaterialCost { get; set; }
		public double EnchantmentCost { get; set; }
		public double ItemCost { get; set; }
		public double ToHitModifier { get; set; }
		public double TotalWeaponCost { get; set; }
		public double CasterLevel { get; set; }
		public double DaysToCreate { get; set; }
		public double ExperienceCost { get; set; }
		public double RawMaterialCost { get; set; }

		public bool IsMagical { get; set; }
		public bool IsMasterwork { get; private set; }
		public bool IsColdIron { get; set; }

		public GenericDagger(string name, string size, string category, string proficiency, string damage, string threatRange, string criticalMultiplier, string damageType, double hardness, double hitPoints, double weight, double basePrice, string weaponText)
		{
			WeaponType = name;
			WeaponName = name;
			WeaponCategory = category;
			WeaponProficiencyRequirement = proficiency;
			WeaponDamage = damage;
			WeaponThreatRange = threatRange;
			WeaponCritical = criticalMultiplier;
			WeaponDamageType = damageType;
			WeaponHardness = hardness;
			WeaponHitPoints = hitPoints;
			BasePrice = basePrice;
			WeaponWeight = weight;
			WeaponText = weaponText;

			CheckForNull(size);
			sizing = new WeaponSizing(WeaponDamage, WeaponSize);
			ApplySizingModifier();
			CalculateWeaponCost();
		}

		public GenericDagger(WeaponData weaponData, string size)
		{
			WeaponType = weaponData.WeaponName;
			WeaponName = weaponData.WeaponName;
			WeaponCategory = weaponData.WeaponCategory;
			WeaponProficiencyRequirement = weaponData.WeaponProficiencyRequirement;
			WeaponDamage = weaponData.WeaponDamage;
			WeaponThreatRange = weaponData.WeaponThreatRange;
			WeaponCritical = weaponData.WeaponCritical;
			WeaponDamageType = weaponData.WeaponDamageType;
			WeaponHardness = weaponData.WeaponHardness;
			WeaponHitPoints = weaponData.WeaponHitPoints;
			BasePrice = weaponData.BasePrice;
			WeaponWeight = weaponData.WeaponWeight;
			WeaponText = weaponData.WeaponText;

			CheckForNull(size);
			sizing = new WeaponSizing(WeaponDamage, WeaponSize);
			ApplySizingModifier();
			CalculateWeaponCost();
		}

		private void CheckForNull(string weaponSize)
		{
			if (string.IsNullOrEmpty(weaponSize))
			{
				WeaponSize = "Medium";
			}
			else
			{
				WeaponSize = weaponSize;
			}
		}

		private void ApplySizingModifier()
		{
			WeaponDamage = sizing.NewDamage;
			WeaponWeight *= sizing.Multiplier;

			ApplyHardnessHitPointsSizeModifier();
			ApplyCostSizeModifier();
		}

		private void ApplyHardnessHitPointsSizeModifier()
		{
			WeaponHardness *= sizing.Multiplier;
			WeaponHitPoints *= sizing.Multiplier;

			if (WeaponHardness < 1)
			{
				WeaponHardness = 1;
			}
			if (WeaponHitPoints < 1)
			{
				WeaponHitPoints = 1;
			}
		}

		private void ApplyCostSizeModifier()
		{
			if (WeaponSize == "Small")
			{
				TotalWeaponCost = BasePrice;
			}
			else
			{
				BasePrice *= sizing.Multiplier;
				ItemCost = BasePrice;
			}
		}

		public void IsMasterworkQualifier(bool value)
		{
			if (value)
			{
				IsMasterwork = true;
				MasterworkProperties();
			}
		}

		private void MasterworkProperties()
		{
			MasterWorkLabel = " [Masterwork]";
			ToHitModifier = 1;
			WeaponText = WeaponText + "\n\tThis dagger is masterwork quality!";
			MasterworkCost = masterworkCostModifier;
			CalculateWeaponCost();
		}

		public void CalculateWeaponCost()
		{
			ItemCost = BasePrice + MasterworkCost + SpecialMaterialCost;
			TotalWeaponCost = ItemCost + EnchantmentCost;
		}

		private string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(string.Format("{0}{1} ({2}){3}\n", WeaponName, MaterialName, WeaponSize, MasterWorkLabel));
			buildWeapon.Append(string.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			if (ToHitModifier != 0)
			{
				buildWeapon.Append(string.Format("To Hit: +{0}\n", ToHitModifier));
			}
			buildWeapon.Append(string.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			buildWeapon.Append(string.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2} pound(s)\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(string.Format("{0} gold pieces\n", (TotalWeaponCost)));
			if (IsMagical)
			{
				buildWeapon.Append(string.Format("\nCreation Costs\n\tCaster Level: {0}\n", CasterLevel));
				buildWeapon.Append(string.Format("\tDays to Create: {0}\n", DaysToCreate));
				buildWeapon.Append(string.Format("\tExperience Cost: {0} experience points\n", ExperienceCost));
				buildWeapon.Append(string.Format("\tRaw Material Cost: {0} gold pieces\n", (RawMaterialCost + ItemCost)));
			}
			buildWeapon.Append(string.Format("\nWeapon Text:\n\t{0}", WeaponText));
			if (!string.IsNullOrEmpty(AdditionalText))
			{
				buildWeapon.Append(string.Format("\n\nAdditional Text:\n\t{0}", AdditionalText));
			}

			return buildWeapon.ToString();
		}

		public override string ToString()
		{
			return WeaponToDisplay();
		}
	}
}