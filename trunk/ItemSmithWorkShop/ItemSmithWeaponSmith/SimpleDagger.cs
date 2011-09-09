using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class SimpleDagger : WeaponSizeAdjustments
	{
		private double masterworkCostModifier;
		public int BasePrice { get; set; }

		public string WeaponProficiencyRequirement
		{
			get
			{
				return "Light Weapon";
			}
		}

		public string WeaponCategory
		{
			get
			{
				return "Melee";
			}
		}

		public string WeaponThreatRange
		{
			get
			{
				return "19-20";
			}
		}

		public string WeaponCritical
		{
			get
			{
				return "x2";
			}
		}

		public string WeaponDamageType
		{
			get
			{
				return "Piercing or Slashing";
			}
		}

		public double WeaponCost
		{
			get;
			set;
		}

		public string WeaponText { get; set; }
		public bool IsMasterwork { get; private set; }
		public int ToHitModifier { get; set; }
		public string AdditionalText { get; set; }

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
			WeaponName = "Masterwork " + WeaponName;
			ToHitModifier = 1;
			WeaponText = WeaponText + "\n\tThis dagger is masterwork quality!";
			masterworkCostModifier = 300;
		}

		public SimpleDagger(string weaponSize)
		{
			
			WeaponName = "Dagger";
			WeaponDamage = "1d4";
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
