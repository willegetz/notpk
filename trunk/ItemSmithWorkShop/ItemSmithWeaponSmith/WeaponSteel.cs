using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponSteel
	{
		private DaggerMedium SimpleDagger { get; set; }

		public WeaponSteel(DaggerMedium simpleDagger)
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
			SimpleDagger.WeaponName = SimpleDagger.WeaponName + " [Steel]";
			SimpleDagger.SpecialText = SimpleDagger.SpecialText + "\n\tThis is now a Steel Dagger!";
			return SimpleDagger;
		}



	}
}
