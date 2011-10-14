using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponAlchemicalSilver
	{
		GenericWeapon Dagger;

		private double alchemySilverCost = 20;

		public WeaponAlchemicalSilver(GenericWeapon dagger)
		{
			if (dagger == null)
			{
				return;
			}
			else
			{
				Dagger = dagger;
				SetAlchemySilverTraits();
			}
		}

		private Object SetAlchemySilverTraits()
		{
			Dagger.MaterialName = " [Alchemical Silver]";
			Dagger.WeaponDamage = Dagger.WeaponDamage + " -1";
			Dagger.SpecialMaterialCost  = alchemySilverCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tAlchemical Silver bypasses damage reduction on lycanthropes.";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}

	}
}
