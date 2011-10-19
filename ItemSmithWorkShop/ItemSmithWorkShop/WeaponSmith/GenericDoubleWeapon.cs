using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class GenericDoubleWeapon : GenericWeapon
	{
		public GenericWeapon FirstWeaponPart { get; set; }
		public GenericWeapon SecondWeaponPart { get; set; }

		public string WeaponFirstHead { get; set; }
		public string WeaponSecondHead { get; set; }

		public GenericDoubleWeapon(WeaponData firstWeaponData, WeaponData secondWeaponData, string size)
		{
			FirstWeaponPart = new GenericWeapon(firstWeaponData, size);
			SecondWeaponPart = new GenericWeapon(secondWeaponData, size);

			SetProperties();
		}

		public void SetProperties()
		{
			WeaponName = FirstWeaponPart.WeaponName;
			WeaponSize = FirstWeaponPart.WeaponSize;
			WeaponCategory = FirstWeaponPart.WeaponCategory;
			WeaponProficiencyRequirement = FirstWeaponPart.WeaponProficiencyRequirement;
			WeaponWeight = FirstWeaponPart.WeaponWeight;
			BasePrice = (FirstWeaponPart.BasePrice + SecondWeaponPart.BasePrice) / 2;
		}

		private double HighestCasterLevel()
		{
			if (FirstWeaponPart.CasterLevel >= SecondWeaponPart.CasterLevel)
			{
				return FirstWeaponPart.CasterLevel;
			}
			else
			{
				return SecondWeaponPart.CasterLevel;
			}
		}

		public override string ToString()
		{
			return DisplayDoubleWeapon();
		}

		public string DisplayDoubleWeapon()
		{
			var buildDoubleWeapon = new StringBuilder();

			buildDoubleWeapon.Append(string.Format("{0} ({1})\n", WeaponName, WeaponSize));
			buildDoubleWeapon.Append(string.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			buildDoubleWeapon.Append(string.Format("Weight: {0} pound(s)\n", (FirstWeaponPart.WeaponWeight + SecondWeaponPart.WeaponWeight) / 2));
			buildDoubleWeapon.Append(string.Format("Total Weapon Cost: {0} gold pieces\n", (FirstWeaponPart.TotalWeaponCost + SecondWeaponPart.TotalWeaponCost) - BasePrice));
			if (FirstWeaponPart.IsMagical == true || SecondWeaponPart.IsMagical == true)
			{
				buildDoubleWeapon.Append(string.Format("Total Creation Costs\n"));
				buildDoubleWeapon.Append(string.Format("\tHighest Caster Level: {0}\n", HighestCasterLevel()));
				buildDoubleWeapon.Append(string.Format("\tTotal Days to Create: {0}\n", (FirstWeaponPart.DaysToCreate + SecondWeaponPart.DaysToCreate)));
				buildDoubleWeapon.Append(string.Format("\tTotal Experience Cost: {0}\n", (FirstWeaponPart.ExperienceCost + SecondWeaponPart.ExperienceCost)));
				buildDoubleWeapon.Append(string.Format("\tTotal Raw Material Cost: {0}\n", ((FirstWeaponPart.RawMaterialCost + FirstWeaponPart.ItemCost) + (SecondWeaponPart.RawMaterialCost + SecondWeaponPart.ItemCost)) - BasePrice));
			}
				
			// Weapon Head 1
			buildDoubleWeapon.Append(string.Format("\n{0} {1}{2}{3}\n", WeaponName, FirstWeaponPart.WeaponPart, FirstWeaponPart.MaterialName, FirstWeaponPart.MasterWorkLabel));
			if (ToHitModifier != 0)
			{
				buildDoubleWeapon.Append(string.Format("To Hit: +{0}\n", FirstWeaponPart.ToHitModifier));
			}
			if (FirstWeaponPart.ToHitModifier != 0)
			{
				buildDoubleWeapon.Append(string.Format("To Hit: +{0}\n", FirstWeaponPart.ToHitModifier));
			}
			buildDoubleWeapon.Append(string.Format("Damage: {0} [{1} {2}] {3}\n", FirstWeaponPart.WeaponDamage, FirstWeaponPart.WeaponThreatRange, FirstWeaponPart.WeaponCritical, FirstWeaponPart.WeaponDamageType));
			buildDoubleWeapon.Append(string.Format("Hardness: {0}\nHit Points: {1}\n", FirstWeaponPart.WeaponHardness, FirstWeaponPart.WeaponHitPoints));
			if (FirstWeaponPart.TotalWeaponCost != BasePrice)
			{
				buildDoubleWeapon.Append(string.Format("{0} Enhancement Cost: {1} gold pieces\n", FirstWeaponPart.WeaponPart, (FirstWeaponPart.TotalWeaponCost - BasePrice)));
			}
			if (FirstWeaponPart.IsMagical)
			{
				buildDoubleWeapon.Append(string.Format("Creation Costs\n\tCaster Level: {0}\n", FirstWeaponPart.CasterLevel));
				buildDoubleWeapon.Append(string.Format("\tDays to Create: {0}\n", FirstWeaponPart.DaysToCreate));
				buildDoubleWeapon.Append(string.Format("\tExperience Cost: {0} experience points\n", FirstWeaponPart.ExperienceCost));
				buildDoubleWeapon.Append(string.Format("\tRaw Material Cost: {0} gold pieces\n", (FirstWeaponPart.RawMaterialCost + FirstWeaponPart.ItemCost) - FirstWeaponPart.BasePrice));
				buildDoubleWeapon.Append(FirstWeaponPart.AdditionalCreationCosts);
			}
			buildDoubleWeapon.Append(string.Format("Weapon Text:\n\t{0}", FirstWeaponPart.WeaponText));

			// Weapon Head 2
			buildDoubleWeapon.Append(string.Format("\n\n{0} {1}{2}{3}\n", WeaponName, SecondWeaponPart.WeaponPart, SecondWeaponPart.MaterialName, SecondWeaponPart.MasterWorkLabel));
			if (ToHitModifier != 0)
			{
				buildDoubleWeapon.Append(string.Format("To Hit: +{0}\n", SecondWeaponPart.ToHitModifier));
			}
			if (SecondWeaponPart.ToHitModifier != 0)
			{
				buildDoubleWeapon.Append(string.Format("To Hit: +{0}\n", SecondWeaponPart.ToHitModifier));
			}
			buildDoubleWeapon.Append(string.Format("Damage: {0} [{1} {2}] {3}\n", SecondWeaponPart.WeaponDamage, SecondWeaponPart.WeaponThreatRange, SecondWeaponPart.WeaponCritical, SecondWeaponPart.WeaponDamageType));
			buildDoubleWeapon.Append(string.Format("Hardness: {0}\nHit Points: {1}\n", SecondWeaponPart.WeaponHardness, SecondWeaponPart.WeaponHitPoints));
			if (SecondWeaponPart.TotalWeaponCost != BasePrice)
			{
				buildDoubleWeapon.Append(string.Format("{0} Enhancement Cost: {1} gold pieces\n", SecondWeaponPart.WeaponPart, (SecondWeaponPart.TotalWeaponCost - BasePrice)));
			}
			if (SecondWeaponPart.IsMagical)
			{
				buildDoubleWeapon.Append(string.Format("Creation Costs\n\tCaster Level: {0}\n", SecondWeaponPart.CasterLevel));
				buildDoubleWeapon.Append(string.Format("\tDays to Create: {0}\n", SecondWeaponPart.DaysToCreate));
				buildDoubleWeapon.Append(string.Format("\tExperience Cost: {0} experience points\n", SecondWeaponPart.ExperienceCost));
				buildDoubleWeapon.Append(string.Format("\tRaw Material Cost: {0} gold pieces\n", (SecondWeaponPart.RawMaterialCost + FirstWeaponPart.ItemCost) - FirstWeaponPart.BasePrice));
				buildDoubleWeapon.Append(SecondWeaponPart.AdditionalCreationCosts);
			}
			buildDoubleWeapon.Append(string.Format("Weapon Text:\n\t{0}", SecondWeaponPart.WeaponText));

			return buildDoubleWeapon.ToString();
		}
	}
}
