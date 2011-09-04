using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponColdIron
	{
		private DaggerMedium Dagger { get; set; }

		private double coldIronCost;

		public WeaponColdIron(DaggerMedium dagger)
		{
			if (dagger == null)
			{
				return;
			}
			else
			{
				Dagger = dagger;
				SetColdIronTraits();
			}
		}

		private Object SetColdIronTraits()
		{
			CalculateColdIronCost();
			Dagger.WeaponName = Dagger.WeaponName + " [Cold Iron]";
			Dagger.WeaponCost = coldIronCost;
			Dagger.SpecialText = Dagger.SpecialText + "\n\tCold Iron is effective against some Fey.\n\tMagic enhancements cost an additional 2000 gold pieces.";

			return Dagger;
		}

		private void CalculateColdIronCost()
		{
			coldIronCost = (Dagger.WeaponCost - Dagger.BasePrice) + (Dagger.BasePrice * 2);
		}

	}
}
