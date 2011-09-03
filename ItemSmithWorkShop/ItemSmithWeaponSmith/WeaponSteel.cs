using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class WeaponSteel
	{
		private SimpleDagger SimpleDagger { get; set; }
		private string name;

		public WeaponSteel(SimpleDagger simpleDagger)
		{
			if (simpleDagger == null)
			{
				return;
			}
			else
			{
				SimpleDagger = simpleDagger;
				SetDaggerTraits();
			}
		}

		public Object SetDaggerTraits()
		{
			SimpleDagger.WeaponName = SimpleDagger.WeaponName + " [Steel]";
			SimpleDagger.SpecialText = SimpleDagger.SpecialText + "\n\tThis is now a Steel Dagger!";
			return SimpleDagger;
		}



	}
}
