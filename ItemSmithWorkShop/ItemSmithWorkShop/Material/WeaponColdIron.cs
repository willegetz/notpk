using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponColdIron
	{
		private GenericDagger Dagger { get; set; }

		private double coldIronCost;

		public WeaponColdIron(GenericDagger dagger)
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
			Dagger.IsColdIron = true;
			CalculateColdIronCost();
			Dagger.MaterialName = " [Cold Iron]";
			Dagger.WeaponCost = coldIronCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tCold Iron is effective against some Fey.\n\tMagic enhancements cost an additional 2000 gold pieces.";

			return Dagger;
		}

		private void CalculateColdIronCost()
		{
			coldIronCost = (Dagger.WeaponCost - Dagger.BasePrice) + (Dagger.BasePrice * 2);
		}

	}
}
