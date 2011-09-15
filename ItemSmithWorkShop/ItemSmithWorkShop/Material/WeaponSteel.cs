using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponSteel
	{
		private GenericDagger SimpleDagger { get; set; }

		public WeaponSteel(GenericDagger simpleDagger)
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
