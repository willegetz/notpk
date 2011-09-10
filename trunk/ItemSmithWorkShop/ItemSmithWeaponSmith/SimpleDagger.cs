using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class SimpleDagger : WeaponSizeAdjustments
	{
		WeaponSizeAdjustments sizeAdjustment;
		
		private double masterworkCostModifier;

		public string WeaponProficiencyRequirement { get { return "Light Weapon"; } }
		public string WeaponCategory { get { return "Melee"; } }
		public string WeaponThreatRange { get { return "19-20"; } }
		public string WeaponCritical { get { return "x2"; } }

		public string WeaponDamageType { get; set; }
		public string WeaponText { get; set; }
		public string AdditionalText { get; set; }
		public int BasePrice { get; set; }
		public double ToHitModifier { get; set; }
		public double WeaponCost { get; set; }
		public double CasterLevel { get; set; }
		public double DaysToCreate { get; set; }
		public double ExperienceCost { get; set; }
		public double RawMaterialCost { get; set; }
		public bool IsMagical { get; set; }
		public bool IsMasterwork { get; private set; }
		
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
			WeaponName = WeaponName + " [Masterwork]";
			ToHitModifier = 1;
			WeaponText = WeaponText + "\n\tThis dagger is masterwork quality!";
			masterworkCostModifier = 300;
		}

		public SimpleDagger(string weaponSize)
		{
			WeaponName = "Dagger";
			WeaponDamage = "1d4";
			WeaponDamageType = "Piercing or Slashing";
			WeaponHardness = 10;
			WeaponHitPoints = 2;
			WeaponWeight = 1;
			WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.";
			BasePrice = 2;
			CheckForNull(weaponSize);
			WeaponCost = BasePrice;
		}

		private string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(WeaponName + "\n");
			buildWeapon.Append(String.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			if (ToHitModifier != 0)
			{
				buildWeapon.Append(String.Format("To Hit: +{0}\n", ToHitModifier));
			}
			buildWeapon.Append(String.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			buildWeapon.Append(String.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2} pound(s)\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(String.Format("{0} gold pieces\n", (WeaponCost + masterworkCostModifier)));
			if (IsMagical)
			{
				buildWeapon.Append(String.Format("Creation Costs\n\tCaster Level: {0}\n", CasterLevel));
				buildWeapon.Append(String.Format("\tDays to Create: {0}\n", DaysToCreate));
				buildWeapon.Append(String.Format("\tExperience Cost: {0} experience points\n", ExperienceCost));
				buildWeapon.Append(String.Format("\tRaw Material Cost: {0} gold pieces\n", RawMaterialCost));
			}
			buildWeapon.Append(String.Format("\nWeapon Text:\n\t{0}", WeaponText));
			if (!String.IsNullOrEmpty(AdditionalText))
			{
				buildWeapon.Append(String.Format("\n\nAdditional Text:\n\t{0}", AdditionalText));
			}

			return buildWeapon.ToString();
		}

		public override string ToString()
		{
			return WeaponToDisplay();
		}
	}
}
