using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponSmith;

namespace ItemSmithWorkShop
{
	public class WeaponAdamantine
	{
		private double adamantineHitPointModifier = 1.33;
		private double adamantineCost = 3000;

		private GenericWeapon Dagger { get; set; }

		public WeaponAdamantine(GenericWeapon dagger)
		{
			if (dagger == null)
			{
				return;
			}
			else
			{
				Dagger = dagger;
				SetAdamantineTraits();
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
				MasterworkWeapon.MakeMasterwork(Dagger);
			}
		}

		private Object SetAdamantineTraits()
		{
			CheckMasterworkStatus();
			Dagger.MaterialName = " [Adamantine]";
			Dagger.WeaponHitPoints = Math.Round(Dagger.WeaponHitPoints * adamantineHitPointModifier);
			Dagger.SpecialMaterialCost = (adamantineCost - CalculateWeaponCosts.GetMasterworkCost());
			Dagger.WeaponText = Dagger.WeaponText + "\n\tDagger bypasses damage reduction value of 20.";
			Dagger.CalculateWeaponCost();

			return Dagger;
		}



	}
}
