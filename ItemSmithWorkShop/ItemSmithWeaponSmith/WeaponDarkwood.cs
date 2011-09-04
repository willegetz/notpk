using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponDarkwood
	{
		private DaggerMedium Dagger { get; set; }

		public WeaponDarkwood(DaggerMedium dagger)
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
			Dagger.IsMasterworkQualifier(true);
			Dagger.WeaponName = Dagger.WeaponName + " [Darkwood]";
			Dagger.WeaponCost += (Dagger.WeaponWeight * 10);
			Dagger.WeaponWeight = (.5 * Dagger.WeaponWeight);
			Dagger.SpecialText = Dagger.SpecialText + "\n\tThis item is made of Darkwood!";
			return Dagger;
		}
	}
}
