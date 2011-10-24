using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	class CreateWeapon
	{
		GenericWeapon weapon;
		GenericWeapon1 weapon1;

		List<WeaponData> weaponDataBundle = new List<WeaponData>();

		public CreateWeapon(WeaponData weaponData)
		{
			weapon1 = new GenericWeapon1(weaponData);
		}

		internal string DisplayWeapon1()
		{
			return weapon1.ToString();
		}







		public CreateWeapon(WeaponData weaponData1, WeaponData weaponData2)
		{
			weaponDataBundle.Add(weaponData1);
			weaponDataBundle.Add(weaponData2);

			weapon = new GenericDoubleWeapon(weaponData1, weaponData2, null);
		}

		internal string DisplayWeapon()
		{
			return weapon.ToString();
		}
	}
}
