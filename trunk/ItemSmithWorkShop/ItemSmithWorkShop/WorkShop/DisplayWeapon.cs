﻿using System;

namespace ItemSmithWorkShop
{
	public class DisplayWeapon
	{
		public string WeaponName { get; set; }
		public string WeaponPreRequisites { get; set; }
		public string WeaponCost { get; set; }
		public string WeaponDamage { get; set; }
		public string WeaponComposition { get; set; }
		public string WeaponSturdiness { get; set; }

		public DisplayWeapon(NameOfWeapon weapon, PreRequisites preRequisites, Cost cost)
		{
			WeaponName = weapon.ToString();
			WeaponPreRequisites = preRequisites.ToString();
			WeaponCost = cost.ToString();
		}

		public DisplayWeapon(NameOfWeapon weapon, PreRequisites preRequisites, Cost cost, Damage damage)
		{
			WeaponName = weapon.ToString();
			WeaponPreRequisites = preRequisites.ToString();
			WeaponCost = cost.ToString();
			WeaponDamage = damage.ToString();
		}

		public DisplayWeapon(NameOfWeapon weapon, WeaponMake weaponComposition, PreRequisites preRequisites, Cost cost, Damage damage, Durability durability)
		{
			WeaponName = String.Format("Weapon Name:\t\t{0}", (weaponComposition.MasterWorkMark + weaponComposition.MaterialType + weapon.WeaponName));
			WeaponPreRequisites = String.Format("Weapon Proficiency:\t{0}\rWeapon Category:\t{1} {2}",
												preRequisites.requirements[0], preRequisites.requirements[1], preRequisites.requirements[2]); //preRequisites.weaponProficiency, preRequisites.weaponCategory, preRequisites.attackType);
			WeaponCost = String.Format("Weapon Cost:\t\t{0} {1}", (cost.WeaponCost + weaponComposition.AdjustedCost), cost.currencyType);//cost.ToString();)
			WeaponDamage = String.Format("Weapon To Hit:\t\t{0}\rWeapon Damage:\t\t{1} {2}\rWeapon Threat Range:{3} / {4}", weaponComposition.MasterWorkToHit, damage.BaseDamage, damage.DamageType, damage.ThreatRange, damage.CriticalMultiplier);
			WeaponSturdiness = String.Format("Weight:\t\t\t\t{0} {1}\rWeapon Hardness:\t{2}\rWeapon Hit Points:\t{3}",
			                                 weaponComposition.AdjustedWeight, weaponComposition.WeightType,
			                                 durability.WeaponHardness, durability.WeaponHitPoints);
		}

		public override string ToString()
		{
			return String.Format("{0}\r{1}\r{2}\r{3}\r{4}", WeaponName, WeaponPreRequisites, WeaponCost, WeaponDamage, WeaponSturdiness);
		}
	}
}