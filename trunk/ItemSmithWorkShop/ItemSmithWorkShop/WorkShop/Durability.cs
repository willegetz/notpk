using System;

namespace ItemSmithWorkShop
{
	//		Durability
	//			Hardness
	//			Hit Points
	public class Durability
	{
		public int WeaponHardness { get; set; }
		public int WeaponHitPoints { get; set; }

		public Durability(int hardness, int weaponHits)
		{
			WeaponHardness = hardness;
			WeaponHitPoints = weaponHits;
		}

		public override string ToString()
		{
			return String.Format("Weapon Hardness: {0}\nWeapon Hit Points {1}", WeaponHardness, WeaponHitPoints);
		}
	}
}
