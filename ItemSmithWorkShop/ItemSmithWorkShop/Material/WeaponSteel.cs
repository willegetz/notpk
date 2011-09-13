using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponSteel
	{
		private SimpleDagger SimpleDagger { get; set; }

		public WeaponSteel(SimpleDagger simpleDagger)
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
			SimpleDagger.WeaponText = SimpleDagger.WeaponText + "\n\tThis is now a Steel Dagger!";
			return SimpleDagger;
		}



	}
}
