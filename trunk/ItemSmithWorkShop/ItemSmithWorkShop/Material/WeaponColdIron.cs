using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	public class WeaponColdIron
	{
		GenericWeapon Dagger;

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
			CalculateColdIronCost(Dagger.BasePrice);
			
			Dagger.MaterialName = " [Cold Iron]";
			Dagger.WeaponText = Dagger.WeaponText + "\n\tCold Iron is effective against some Fey.\n\tMagic enhancements cost an additional 2000 gold pieces.";
			
			Dagger.CalculateWeaponCost();

			return Dagger;
		}

		public void CalculateColdIronCost(double basePrice)
		{
			Dagger.SpecialMaterialCost = basePrice;
			WeaponPriceCalculations.SetSpecialMaterialCost(basePrice);
		}

	}
}
