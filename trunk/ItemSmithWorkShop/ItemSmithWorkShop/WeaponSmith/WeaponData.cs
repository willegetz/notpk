using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponData
	{
		public string WeaponName = "Dagger";
		public string WeaponCategory = "Melee";
		public string WeaponProficiencyRequirement = "Light Weapon";
		public string WeaponDamage = "1d4";
		public string WeaponThreatRange = "19-20";
		public string WeaponCritical = "x2";
		public string WeaponDamageType = "Piercing or Slashing";
		public double WeaponHardness = 10;
		public double WeaponHitPoints = 2;
		public double BasePrice = 2;
		public double WeaponWeight = 1;
		public string WeaponText = "The dagger is a common secondary weapon. You get a +2 bonus on\n\tSleight of Hand checks made to conceal a dagger on your body.";
	}
}