using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class MasterworkAlchemicalSilver : IMaterialComponent
	{
		private const double ammunitionCostModifier = 2;
		private const double lightWeaponCostModifier = 20;
		private const double oneHandedWeaponCostModifier = 90;
		private const double twoHandedWeaponCostModifier = 180;
		private const double masterworkCostModifier = 300;

		public string ComponentName { get { return "Masterwork Alchemical Silver"; } }

		// property returns '0' as the there are four different modifiers that can be applied depending on circumstance.
		public double WeaponCostModifier { get { return 0; } }

		public bool IsMasterwork { get { return true; } }

		public string ToHitBonus { get { return "+1"; } }

		public string ComponentInfo { get { return "I am a masterwork alchemical silver weapon"; } }

		public double ApplyCostModifier(IWeapon weapon)
		{
			if (weapon.WeaponCategory.Contains("Light"))
			{
				return weapon.WeaponCost + lightWeaponCostModifier + masterworkCostModifier;
			}
			return weapon.WeaponCost;
		}

		public string AppendSpecialInfo(IWeapon weapon)
		{
			return string.Format("{1}{0}{2}", Environment.NewLine, weapon.SpecialInfo, ComponentInfo);
		}

		public string ApplyToHitModifier()
		{
			return ToHitBonus;
		}

		public bool VerifyMasterwork(IWeapon weapon)
		{
			return IsMasterwork;
		}

		public double ApplyWeightModifer(IWeapon weapon)
		{
			return weapon.Weight;
		}

		public double GetAdditionalEnchantmentCost()
		{
			return 0;
		}
	}
}
