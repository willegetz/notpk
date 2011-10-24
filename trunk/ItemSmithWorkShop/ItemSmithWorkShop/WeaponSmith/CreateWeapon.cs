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
		WeaponSizing sizing;

		List<WeaponData> weaponDataBundle = new List<WeaponData>();
		WeaponData data;

		public CreateWeapon(WeaponData weaponData) 
		{
			data = weaponData;
			weapon1 = new GenericWeapon1();
			sizing = new WeaponSizing();
			weaponDataBundle = new List<WeaponData>();
		}

		public void SizeAdjustment(string size)
		{
			sizing.SetSizingValues(data, size);
		}

		public void ManipulatePrice(double adjustment)
		{
			weapon1.PriceAdjustment(data.BasePrice, adjustment);
		}

		public void ProduceFinalWeapon()
		{
			weapon1.PutWeaponStuffInString(data);
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
