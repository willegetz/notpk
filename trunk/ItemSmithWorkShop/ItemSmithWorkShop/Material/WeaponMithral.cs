using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	public class WeaponMithral
	{
		GenericWeapon Dagger;

		private double mithralCost = 500;

		public WeaponMithral(GenericWeapon dagger)
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
				MasterworkWeapon.MakeMasterwork(Dagger);
				Dagger.masterworkCostModifier = 0;
			}
		}

		private Object SetMithralTraits()
		{
			Dagger.MaterialName = " [Mithral]";
			Dagger.SpecialMaterialCost = (mithralCost * Dagger.WeaponWeight) - WeaponPriceCalculations.GetMasterworkCost();
			Dagger.WeaponWeight = (Dagger.WeaponWeight / 2);
			Dagger.WeaponText = Dagger.WeaponText + "\n\tThis item is made of mithral!";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}
	}
}
