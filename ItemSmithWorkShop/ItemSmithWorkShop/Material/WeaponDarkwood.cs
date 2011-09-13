using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponDarkwood
	{
		private SimpleDagger Dagger { get; set; }

		public WeaponDarkwood(SimpleDagger dagger)
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
			Dagger.WeaponText = Dagger.WeaponText + "\n\tThis item is made of Darkwood!";
			return Dagger;
		}
	}
}
