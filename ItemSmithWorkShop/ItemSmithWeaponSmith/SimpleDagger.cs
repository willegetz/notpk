using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class SimpleDagger
	{
		public string WeaponName { get; set;}

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
			get
			{
				return "1d4";
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
			get
			{
				return 2;
			}
		}

		public string WeaponWeight
		{
			get
			{
				return "1 pound";
			}
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
			get
			{
				return 2;
			}
		}

		public string SpecialText { get; set; }

		public SimpleDagger()
		{
			WeaponName = "Dagger";
			SpecialText = "This is a dagger!";
		}

		private string WeaponToDisplay()
		{
			var buildWeapon = new StringBuilder();

			buildWeapon.Append(WeaponName + "\n");
			buildWeapon.Append(String.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory, WeaponProficiencyRequirement));
			buildWeapon.Append(String.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage, WeaponThreatRange, WeaponCritical, WeaponDamageType));
			buildWeapon.Append(String.Format("Weight: {0}\n", WeaponWeight));
			buildWeapon.Append(String.Format("Hardness: {0}\nHit Points: {1}\nWeight: {2}\n", WeaponHardness, WeaponHitPoints, WeaponWeight));
			buildWeapon.Append(String.Format("{0} gold pieces\n", WeaponCost));
			buildWeapon.Append(String.Format("\nSpecial Text:\n\t{0}", SpecialText));

			return buildWeapon.ToString();
		}

		public override string ToString()
		{
			return WeaponToDisplay();
		}
	}
}
