using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	class CreateWeapon
	{

		GenericWeapon weapon;
		private WeaponData weaponDataBundle;
		private WeaponData weaponData1;
		private WeaponData weaponData2;

		public CreateWeapon(WeaponData weaponData)
		{
			weaponDataBundle = weaponData;
			weapon = new GenericWeapon(weaponData, null);
		}

		public CreateWeapon(WeaponData weaponData1, WeaponData weaponData2)
		{
			this.weaponData1 = weaponData1;
			this.weaponData2 = weaponData2;

			weapon = new GenericDoubleWeapon(weaponData1, weaponData2, null);
		}

		internal string DisplayWeapon()
		{
			return weapon.ToString();
		}
	}
}
