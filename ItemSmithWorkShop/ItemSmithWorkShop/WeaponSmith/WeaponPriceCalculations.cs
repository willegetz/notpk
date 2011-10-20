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
		private static double MagicalEnhancementCost { get; set; }

		internal static void SetMasterworkCost(double masterworkCost)
		{
			MasterworkWeaponCost = masterworkCost;
		}

		public static double GetMasterworkCost()
		{
			return MasterworkWeaponCost;
		}

		internal static void SetBasePrice(double basePrice)
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

		internal static void SetMagicalCost(double magicalCost)
		{
			MagicalEnhancementCost = magicalCost;
		}

		internal static double GetMagicalEnchantmentCost()
		{
			return MagicalEnhancementCost;
		}

		internal static double DetermineTotalWeaponCost()
		{
			//ItemCost = BasePrice + externalMasterworkCost + SpecialMaterialCost;
			//TotalWeaponCost = ItemCost + EnchantmentCost;

			return BasePrice + MasterworkWeaponCost + SpecialMaterialCost + MagicalEnhancementCost;
		}
	}
}
