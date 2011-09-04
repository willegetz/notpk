using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponMithral
	{
		private DaggerMedium Dagger { get; set; }

		private double mithralCost = 500;

		public WeaponMithral(DaggerMedium dagger)
		{
			if (dagger == null)
			{
				return;
			}
			else
			{
				Dagger = dagger;
				CheckMasterworkStatus();
				SetMithralTraits();
			}
		}

		private void CheckMasterworkStatus()
		{
			if (Dagger.IsMasterwork)
			{
				return;
			}
			else
			{
				Dagger.IsMasterworkQualifier(true);
			}
		}

		private Object SetMithralTraits()
		{
			Dagger.WeaponName = Dagger.WeaponName + " [Mithral]";
			Dagger.WeaponCost += (mithralCost * Dagger.WeaponWeight);
			Dagger.WeaponWeight = (Dagger.WeaponWeight / 2);
			Dagger.SpecialText = Dagger.SpecialText + "\n\tThis item is made of mithral!";

			return Dagger;
		}

	}
}
