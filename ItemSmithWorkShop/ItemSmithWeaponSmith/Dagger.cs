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
		public string SpecialText { get; set; }
		public MaterialComponent Material { get; set; }

		public void WeaponName(string name)
		{
			Weapon = name;
		}

		public string WeaponMaterial()
		{
			if (Material == null)
			{
				return "";
			}
			else
			{
				return String.Format(" [{0}]", Material.MaterialName);
			}
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
			if (Material == null)
			{
			    WeaponValue = cost;
			}
			else
			{
			    WeaponValue = (cost + Material.PriceAdjustment);
			}
		}

		public string WeaponWeight()
		{
			return "1 pound";
		}

		public decimal WeaponHardness()
		{
			decimal hardness;
			if (Material == null)
			{
				return 10;
			}
			else
			{
				hardness = Math.Round(10 * Material.HardnessModifier);
				return hardness;
			}
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
			sb.Append(SpecialText);

			return sb.ToString();
		}

		public override string ToString()
		{
			return DisplayWeapon();
		}

		public void WeaponMaterial(MaterialComponent component)
		{
			if (component == null)
			{
				Material.MaterialName = "";
				Material.PriceAdjustment = 0;
				Material.HardnessModifier = 1;
				Material.ToHitModifier = 0;
				Material.SpecialText = "";
			}
			else
			{
				Material = component;
				AssignToHit(Material.ToHitModifier);
				AssignSpecialText(Material.SpecialText);
			}
		}

		private void AssignSpecialText(string specialText)
		{
			SpecialText = String.Format("\n\n{0}", specialText);
		}

		private void AssignToHit(int toHitModifier)
		{
			ToHitModifier = toHitModifier;
		}

	}
}
