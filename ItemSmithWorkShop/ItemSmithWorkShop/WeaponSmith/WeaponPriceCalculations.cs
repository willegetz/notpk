using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponSmith
{
	public class WeaponPriceCalculations
	{
		private static double MasterworkWeaponCost { get; set; }
		private static double BasePrice { get; set; }
		private static double SpecialMaterialCost { get; set; }

		internal static void SetMasterworkCost(double masterworkCost)
		{
			MasterworkWeaponCost = masterworkCost;
		}

		public static double GetMasterworkCost()
		{
			return MasterworkWeaponCost;
		}

		internal static void SetBasePrice(int basePrice)
		{
			BasePrice = basePrice;
		}

		internal static double GetBasePriceCost()
		{
			return BasePrice;
		}

		internal static void SetSpecialMaterialCost(double specialMaterial)
		{
			SpecialMaterialCost = specialMaterial;
		}

		internal static double GetSpecialMaterialCost()
		{
			return SpecialMaterialCost;
		}
	}
}
