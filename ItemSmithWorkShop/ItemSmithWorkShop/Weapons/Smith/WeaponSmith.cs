using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Weapons.MaterialTypes;
using ItemSmithWorkShop.Weapons.Interfaces;

namespace ItemSmithWorkShop.Weapons.Smith
{
	public class WeaponSmith
	{
		private IWeapon1 forgedWeapon;
		private IWeapon1 weapon;
		private Mithral material;
		
		private string forgedWeaponName;

        public WeaponSmith(IWeapon1 weapon, Mithral material)
		{
			forgedWeapon = new ForgedWeapon();
			this.weapon = weapon;
			this.material = material;
		}

        public IWeaponItem ForgeWeapon()
		{
			forgedWeaponName = string.Format("{0} {1}", material.MaterialName, weapon.WeaponName);
			forgedWeapon.SetWeaponName(forgedWeaponName);

			return forgedWeapon;
		}

		public string Display()
		{
			return forgedWeapon.WeaponName;
		}
	}
}
