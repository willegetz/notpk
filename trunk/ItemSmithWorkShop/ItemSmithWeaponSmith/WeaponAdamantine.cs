using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponAdamantine
	{
		private double adamantineHitPointModifier = 1.33;
		private double adamantineCost = 3000;

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

		private Object SetAdamantineTraits()
		{
			Dagger.WeaponName = Dagger.WeaponName + " [Adamantine]";
			Dagger.ToHitModifier = 1;
			Dagger.WeaponHitPoints = Math.Round(Dagger.WeaponHitPoints * adamantineHitPointModifier);
			Dagger.WeaponCost += adamantineCost;
			Dagger.SpecialText = Dagger.SpecialText + "\n\tDagger bypasses damage reduction value of 20.";
			
			return Dagger;
		}



	}
}
