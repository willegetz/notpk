using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	public class GenericWeapon
	{
		WeaponSizing sizing;
		WeaponData weaponData;

		public double masterworkCostModifier = 300;

		public virtual string WeaponProficiencyRequirement { get; set; }
		public string WeaponCategory { get; set; }
		public string WeaponThreatRange { get; set; }
		public string WeaponCritical { get; set; }
		public string RangeIncrement { get; set; }
		public string AdditionalCreationCosts { get; set; }
		public string WeaponPart { get; set; }

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
		public bool IsMasterwork { get; set; }
		public bool IsColdIron { get; set; }

		public double externalMasterworkCost;

		public GenericWeapon(){}

		public GenericWeapon(WeaponData data, string size)
		{
			CheckForNullData(data);
			CheckForNullSize(size);
			sizing = new WeaponSizing();

			SetWeaponInitialValues();
		}

		private void CheckForNullData(WeaponData data)
		{
			if (data == null)
			{
				weaponData = TempWeaponDictionary.GetWeaponData("");
			}
			else
			{
				weaponData = data;
			}
		}

		private void CheckForNullSize(string weaponSize)
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

		private void SetWeaponInitialValues()
		{
			WeaponType = weaponData.WeaponName;
			WeaponName = weaponData.WeaponName;
			WeaponPart = weaponData.WeaponPart;
			WeaponCategory = weaponData.WeaponCategory;
			WeaponProficiencyRequirement = weaponData.WeaponProficiencyRequirement;
			WeaponDamage = weaponData.WeaponDamage;
			WeaponThreatRange = weaponData.WeaponThreatRange;
			WeaponCritical = weaponData.WeaponCritical;
			WeaponDamageType = weaponData.WeaponDamageType;
			RangeIncrement = weaponData.RangeIncrement;
			WeaponHardness = weaponData.WeaponHardness;
			WeaponHitPoints = weaponData.WeaponHitPoints;
			BasePrice = weaponData.BasePrice;
			WeaponWeight = weaponData.WeaponWeight;
			WeaponText = weaponData.WeaponText;

			sizing.SetSizingValues(WeaponDamage, WeaponSize);
			ApplySizingModifier();
			CalculateWeaponCost();
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

			if (WeaponHardness < 1 && WeaponHardness != 0)
			{
				WeaponHardness = 1;
			}
			if (WeaponHitPoints < 1 && WeaponHitPoints != 0)
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

		//public virtual void IsMasterworkQualifier(bool value)
		//{
		//    if (value)
		//    {
		//        IsMasterwork = true;
		//        MasterworkProperties();
		//    }
		//}

		//protected virtual void MasterworkProperties()
		//{
		//    MasterWorkLabel = " [Masterwork]";
		//    ToHitModifier = 1;
		//    WeaponText = WeaponText + string.Format("\n\tThis {0} is masterwork quality!", WeaponType.ToLower());
		//    MasterworkCost = masterworkCostModifier;
		//    CalculateWeaponCost();
		//}

		public virtual void CalculateWeaponCost()
		{
			if (IsMasterwork && CalculateWeaponCosts.GetMasterworkCost() == 0)
			{
				externalMasterworkCost = 0;
			}
			else if (IsMasterwork && CalculateWeaponCosts.GetMasterworkCost() != 0)
			{
				externalMasterworkCost = CalculateWeaponCosts.GetMasterworkCost();
			}
			ItemCost = BasePrice + MasterworkCost + externalMasterworkCost + SpecialMaterialCost;
			TotalWeaponCost = ItemCost + EnchantmentCost;
			//ItemCost = BasePrice + MasterworkCost + SpecialMaterialCost;
			//TotalWeaponCost = ItemCost + EnchantmentCost;
		}

		protected string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(string.Format("{0}{1} ({2}){3}\n", WeaponName, MaterialName, WeaponSize, MasterWorkLabel));
			buildWeapon.Append(string.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			if (ToHitModifier != 0)
			{
				buildWeapon.Append(string.Format("To Hit: +{0}\n", ToHitModifier));
			}
			buildWeapon.Append(string.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			if (!string.IsNullOrEmpty(RangeIncrement))
			{
				buildWeapon.Append(string.Format("Range Increment: {0}\n", RangeIncrement));
			}
			buildWeapon.Append(string.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2} pound(s)\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(string.Format("{0} gold pieces\n", (TotalWeaponCost)));
			if (IsMagical)
			{
				buildWeapon.Append(string.Format("\nCreation Costs\n\tCaster Level: {0}\n", CasterLevel));
				buildWeapon.Append(string.Format("\tDays to Create: {0}\n", DaysToCreate));
				buildWeapon.Append(string.Format("\tExperience Cost: {0} experience points\n", ExperienceCost));
				buildWeapon.Append(string.Format("\tRaw Material Cost: {0} gold pieces\n", (RawMaterialCost + ItemCost)));
				buildWeapon.Append(AdditionalCreationCosts);
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