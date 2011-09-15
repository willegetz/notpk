using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponAlchemicalSilver
	{
		private GenericDagger Dagger { get; set; }

		private double alchemySilverCost = 20;

		public WeaponAlchemicalSilver(GenericDagger dagger)
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
			Dagger.WeaponCost += alchemySilverCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tAlchemical Silver bypasses damage reduction on lycanthropes.";

			return Dagger;
		}

	}
}
