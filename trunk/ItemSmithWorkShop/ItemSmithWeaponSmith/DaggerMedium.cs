using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class DaggerMedium
	{
		private double masterworkCostModifier;
		public int BasePrice { get; set; }

		public string WeaponName { get; set; }

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

		public string WeaponDamage
		{
			get;
			set;
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

		public double WeaponWeight
		{
			get;
			set;
		}

		public double WeaponHardness
		{
			get
			{
				return 10;
			}
		}

		public double WeaponHitPoints
		{
			get;
			set;
		}

		public string SpecialText { get; set; }
		public bool IsMasterwork { get; private set; }
		public int ToHitModifier { get; set; }

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
			SpecialText = SpecialText + "\n\tThis dagger is masterwork quality!";
			masterworkCostModifier = 300;
		}

		public DaggerMedium()
		{

			WeaponName = "Dagger";
			WeaponDamage = "1d4";
			WeaponHitPoints = 2;
			WeaponWeight = 1;
			SpecialText = "This is a dagger!";
			BasePrice = 2;
			WeaponCost = BasePrice;
		}

		private string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(WeaponName + "\n");
			buildWeapon.Append(String.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			buildWeapon.Append(String.Format("To Hit: {0}\n", ToHitModifier));
			buildWeapon.Append(String.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			buildWeapon.Append(String.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2} pound(s)\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(String.Format("{0} gold pieces\n", (WeaponCost + masterworkCostModifier)));
			buildWeapon.Append(String.Format("\nSpecial Text:\n\t{0}", SpecialText));

			return buildWeapon.ToString();
		}

		public override string ToString()
		{
			return WeaponToDisplay();
		}
	}
}
