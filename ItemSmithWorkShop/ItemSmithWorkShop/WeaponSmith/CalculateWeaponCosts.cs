using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	public class CalculateWeaponCosts
	{
		private static double MasterworkWeaponCost { get; set; }

		internal static void SetMasterworkCost(double masterworkCost)
		{
			MasterworkWeaponCost = masterworkCost;
		}

		public static double GetMasterworkCost()
		{
			return MasterworkWeaponCost;
		}
	}
}
