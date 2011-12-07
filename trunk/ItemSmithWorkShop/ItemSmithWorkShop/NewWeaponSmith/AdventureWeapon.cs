using System;
using System.Collections.Generic;
using System.Linq;

namespace NewWeaponSmith
{
	public class AdventureWeapon : AdventureItem
	{

		public AdventureWeapon(string weaponName)
		{
			itemName = weaponName;
		}

		public override double GetCost()
		{
			return 2;
		}

	}
}
