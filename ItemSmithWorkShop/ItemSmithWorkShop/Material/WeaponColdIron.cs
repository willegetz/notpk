using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponColdIron
	{
		private GenericWeapon Dagger { get; set; }

		private double coldIronCost;

		public WeaponColdIron(GenericWeapon dagger)
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
			Dagger.SpecialMaterialCost = coldIronCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tCold Iron is effective against some Fey.\n\tMagic enhancements cost an additional 2000 gold pieces.";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}

		private void CalculateColdIronCost()
		{
			coldIronCost = (Dagger.BasePrice);
		}

	}
}
