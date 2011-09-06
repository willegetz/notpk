using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponAlchemicalSilver
	{
		private SimpleDagger Dagger { get; set; }

		private double alchemySilverCost = 20;

		public WeaponAlchemicalSilver(SimpleDagger dagger)
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
			Dagger.WeaponName = Dagger.WeaponName + " [Alchemical Silver]";
			Dagger.WeaponDamage = Dagger.WeaponDamage + " -1";
			Dagger.WeaponCost += alchemySilverCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tAlchemical Silver bypasses damage reduction on lycanthropes.";

			return Dagger;
		}

	}
}
