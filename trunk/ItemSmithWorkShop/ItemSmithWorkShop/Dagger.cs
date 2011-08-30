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

		private string Weapon { get; set; }
		private string WeaponValue { get; set; }

		public void WeaponName(string name)
		{
			Weapon = name;
		}

		public string WeaponMaterial()
		{
			return "Steel";
		}

		public string WeaponProficiencyRequirement()
		{
			return "Light Weapon";
		}

		public string WeaponCategory()
		{
			return "Melee";
		}

		public string WeaponDamage()
		{
			return "1d4";
		}

		public string WeaponThreatRange()
		{
			return "19-20";
		}

		public string WeaponCritical()
		{
			return "x2";
		}

		public string WeaponDamageType()
		{
			return "Piercing or Slashing";
		}

		public void WeaponCost(string cost)
		{
			WeaponValue = cost;
		}

		public string WeaponWeight()
		{
			return "1 pound";
		}

		public int WeaponHardness()
		{
			return 10;
		}

		public int WeaponHitPoints()
		{
			return 2;
		}

		public string DisplayWeapon()
		{
			var sb = new StringBuilder();

			//sb.Append(WeaponMaterial() + " " + Weapon + "\n");
			sb.Append(Weapon + " [" + WeaponMaterial() + "]\n");
			sb.Append(String.Format("{0} Weapon\n{1} Proficiency\n",WeaponCategory(), WeaponProficiencyRequirement()));
			sb.Append(String.Format("Damage: {0} [{1} {2}] {3}\n",  WeaponDamage(), WeaponThreatRange(), WeaponCritical(), WeaponDamageType()));
			sb.Append(String.Format("Weight: {0}\n", WeaponWeight()));
			sb.Append(String.Format("Hardness: {0}\nHitPoints: {1}\nWeight: {2}\n", WeaponHardness(), WeaponHitPoints(), WeaponWeight()));
			sb.Append(WeaponValue);

			return sb.ToString();
		}

		public override string ToString()
		{
			return DisplayWeapon();
		}
	}
}
