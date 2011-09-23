using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponSteel
	{
		private GenericWeapon SimpleDagger { get; set; }

		public WeaponSteel(GenericWeapon simpleDagger)
		{
			if (simpleDagger == null)
			{
				return;
			}
			else
			{
				SimpleDagger = simpleDagger;
				SetSteelTraits();
			}
		}

		public Object SetSteelTraits()
		{
			SimpleDagger.MaterialName = " [Steel]";
			SimpleDagger.WeaponText = SimpleDagger.WeaponText + "\n\tThis is now a Steel Dagger!";
			return SimpleDagger;
		}



	}
}
