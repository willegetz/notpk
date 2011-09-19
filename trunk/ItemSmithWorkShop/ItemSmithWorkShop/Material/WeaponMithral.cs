﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponMithral
	{
		private GenericDagger Dagger { get; set; }

		private double mithralCost = 500;

		public WeaponMithral(GenericDagger dagger)
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
			Dagger.MaterialName = " [Mithral]";
			Dagger.SpecialMaterialCost = (mithralCost * Dagger.WeaponWeight) - Dagger.MasterworkCost;
			Dagger.WeaponWeight = (Dagger.WeaponWeight / 2);
			Dagger.WeaponText = Dagger.WeaponText + "\n\tThis item is made of mithral!";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}
	}
}
