using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class DisplayWeapon
	{
		public string WeaponName { get; set; }
		public string WeaponPreRequisites { get; set; }
		public string WeaponCost { get; set; }
		public string WeaponDamage { get; set; }
		public string WeaponComposition { get; set; }

		public DisplayWeapon(Weapon weapon, PreRequisites preRequisites, Cost cost)
		{
			WeaponName = weapon.ToString();
			WeaponPreRequisites = preRequisites.ToString();
			WeaponCost = cost.ToString();
		}

		public DisplayWeapon(Weapon weapon, PreRequisites preRequisites, Cost cost, Damage damage)
		{
			WeaponName = weapon.ToString();
			WeaponPreRequisites = preRequisites.ToString();
			WeaponCost = cost.ToString();
			WeaponDamage = damage.ToString();
		}

		public DisplayWeapon(Weapon weapon, WeaponMake weaponComposition, PreRequisites preRequisites, Cost cost, Damage damage)
		{
			WeaponName = weapon.ToString();
			WeaponComposition = weaponComposition.ToString();
			WeaponPreRequisites = preRequisites.ToString();
			WeaponCost = cost.ToString();
			WeaponDamage = damage.ToString();
		}

		public override string ToString()
		{
			return String.Format("{0}\r{1}\r{2}\r{3}\r{4}", WeaponName, WeaponComposition,WeaponPreRequisites, WeaponCost, WeaponDamage);
		}
	}
}
