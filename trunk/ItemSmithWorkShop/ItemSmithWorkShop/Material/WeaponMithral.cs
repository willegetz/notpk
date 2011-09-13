using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponMithral
	{
		private SimpleDagger Dagger { get; set; }

		private double mithralCost = 500;

		public WeaponMithral(SimpleDagger dagger)
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
				Dagger.masterworkCostModifier = 0;
				return;
			}
			else
			{
				Dagger.IsMasterworkQualifier(true);
				Dagger.masterworkCostModifier = 0;
			}
		}

		private Object SetMithralTraits()
		{
			Dagger.WeaponName = Dagger.WeaponName + " [Mithral]";
			Dagger.WeaponCost += (mithralCost * Dagger.WeaponWeight);
			Dagger.WeaponWeight = (Dagger.WeaponWeight / 2);
			Dagger.WeaponText = Dagger.WeaponText + "\n\tThis item is made of mithral!";

			return Dagger;
		}

	}
}
