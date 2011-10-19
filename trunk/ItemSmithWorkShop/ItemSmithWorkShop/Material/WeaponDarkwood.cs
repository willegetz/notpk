using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	public class WeaponDarkwood
	{
		GenericWeapon Dagger;

		public WeaponDarkwood(GenericWeapon dagger)
		{
			if (dagger == null)
			{
				return;
			}
			else
			{
				Dagger = dagger;
				SetDarkwoodTraits();
			}
		}

		private Object SetDarkwoodTraits()
		{
			MasterworkWeapon.MakeMasterwork(Dagger);
			Dagger.MaterialName = " [Darkwood]";
			Dagger.SpecialMaterialCost = (Dagger.WeaponWeight * 10);
			Dagger.WeaponWeight = (.5 * Dagger.WeaponWeight);
			Dagger.WeaponText = Dagger.WeaponText + "\n\tThis item is made of Darkwood!";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}
	}
}
