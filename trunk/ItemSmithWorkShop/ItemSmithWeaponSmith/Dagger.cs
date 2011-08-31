using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class Dagger
	{
		// Simplicity First.
		// Display the item  first
		// Build in complexity one step at a time

		private string Weapon { get; set; }
		private int WeaponValue { get; set; }
		private int ToHitModifier { get; set; }

		private bool IsMasterwork { get; set; }

		public void WeaponName(string name)
		{
			Weapon = name;
		}

		public string WeaponMaterial()
		{
			return String.Format("[{0}]", Material.MaterialName);
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

		public void WeaponCost(int cost)
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
			Weapon = "Masterwork " + Weapon;
			ToHitModifier = 1;
			WeaponValue += 300;
		}

		public string DisplayWeapon()
		{
			var sb = new StringBuilder();

			sb.Append(Weapon + WeaponMaterial() + "\n");
			sb.Append(String.Format("{0} Weapon\n{1} Proficiency\n", WeaponCategory(), WeaponProficiencyRequirement()));
			sb.Append(String.Format("Attack Bonus: +{0}\n", ToHitModifier));
			sb.Append(String.Format("Damage: {0} [{1} {2}] {3}\n", WeaponDamage(), WeaponThreatRange(), WeaponCritical(), WeaponDamageType()));
			sb.Append(String.Format("Weight: {0}\n", WeaponWeight()));
			sb.Append(String.Format("Hardness: {0}\nHitPoints: {1}\nWeight: {2}\n", WeaponHardness(), WeaponHitPoints(), WeaponWeight()));
			sb.Append(WeaponValue + " gold pieces");

			return sb.ToString();
		}

		public override string ToString()
		{
			return DisplayWeapon();
		}

		public void WeaponMaterial(SteelMaterial steel)
		{
			Material = steel;
		}

		public SteelMaterial Material { get; set; }
	}
}
