using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class WeaponAdamantine
	{
		private double adamantineHitPointModifier = 1.33;
		private double adamantineCost = 2700;

		private SimpleDagger Dagger { get; set; }

		public WeaponAdamantine(SimpleDagger dagger)
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
				Dagger.IsMasterworkQualifier(true);
			}
		}

		private Object SetAdamantineTraits()
		{
			CheckMasterworkStatus();
			Dagger.WeaponName = Dagger.WeaponName + " [Adamantine]";
			Dagger.WeaponHitPoints = Math.Round(Dagger.WeaponHitPoints * adamantineHitPointModifier);
			Dagger.WeaponCost += adamantineCost;
			Dagger.WeaponText = Dagger.WeaponText + "\n\tDagger bypasses damage reduction value of 20.";
			
			return Dagger;
		}



	}
}
