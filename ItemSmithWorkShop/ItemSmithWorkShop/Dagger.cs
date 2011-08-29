using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	class Dagger
	{
		// Simplicity First.
		// Display the item  first
		// Build in complexity one step at a time

		//Display the name
		public string WeaponName()
		{
			return "Dagger";
		}

		public string WeaponMaterial()
		{
			return "Steel";
		}

		// Display the proficiencies
		public string WeaponProficiencyRequirement()
		{
			return "Light Weapon";
		}

		// Display the weapon category
		public string WeaponCategory()
		{
			return "Melee";
		}

		// Display the weapon damage
		public string WeaponDamage()
		{
			return "1d4";
		}

		// Display the threat range
		public string WeaponThreatRange()
		{
			return "19-20";
		}

		// Display the weapon's crit stats
		public string WeaponCritical()
		{
			return "x2";
		}

		// Display the weapon damage type
		public string WeaponDamageType()
		{
			return "Piercing or Slashing";
		}

		// Display the weapon cost
		public string WeaponCost()
		{
			return "2 gold pieces";
		}

		// Display the weapon weapon weight
		public string WeaponWeight()
		{
			return "1 pound";
		}

		// Display the weapon hardness
		public int WeaponHardness()
		{
			return 10;
		}

		// Display the weapon hit points
		public int WeaponHitPoints()
		{
			return 2;
		}

		public string DisplayWeapon()
		{
			var sb = new StringBuilder();

			sb.Append(WeaponMaterial() + " " + WeaponName() + "\n");
			sb.Append(String.Format("{0} Weapon\n{1} Proficiency\n",WeaponCategory(), WeaponProficiencyRequirement()));
			sb.Append(String.Format("Damage: {0} [{1} {2}] {3}\n",  WeaponDamage(), WeaponThreatRange(), WeaponCritical(), WeaponDamageType()));
			sb.Append(String.Format("Weight: {0}\n", WeaponWeight()));
			sb.Append(String.Format("Hardness: {0}\nHitPoints: {1}\nWeight: {2}\n", WeaponHardness(), WeaponHitPoints(), WeaponWeight()));
			sb.Append(WeaponCost());

			return sb.ToString();
		}

		public override string ToString()
		{
			return DisplayWeapon();
		}
	}
}
