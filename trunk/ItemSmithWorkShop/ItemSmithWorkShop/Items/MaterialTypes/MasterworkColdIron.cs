using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class MasterworkColdIron : IMaterialComponent
	{
		private const double masterworkCost = 300;
		private const double coldIronCost = 2;
		private const double magicEnchantmentCostModification = 2000;
		private string coldIronSpecialInfo = "This iron mined deep underground, known for its\r\teffectiveness against fey creatures, is forged at a\r\tlower temperature to preserve its delicate properties.";

		public double MagicEnchantmentCostModification { get { return magicEnchantmentCostModification; } }

		public string ComponentName { get { return "Masterwork Cold Iron"; } }

		public double WeaponCostModifier { get { return coldIronCost; } }

		public bool IsMasterwork { get { return true; } }

		public string ToHitBonus { get { return "+1"; } }

		public double DamageBonus { get { return 0; } }

		public string ComponentInfo { get { return coldIronSpecialInfo; } }

		public double ApplyCostModifier(IWeapon weapon)
		{
			return (weapon.WeaponCost * WeaponCostModifier) + masterworkCost;
		}

		public string AppendSpecialInfo(IWeapon weapon)
		{
			return string.Format("{1}{0}{2}", Environment.NewLine, weapon.SpecialInfo, ComponentInfo);
		}

		public string ApplyToHitModifier() { return ToHitBonus; }

		public bool VerifyMasterwork(IWeapon weapon)
		{
			if (weapon.IsMasterwork)
			{
				return weapon.IsMasterwork;
			}
			else
			{
				return IsMasterwork;
			}
		}

		public double ApplyWeightModifer(IWeapon weapon) { return weapon.Weight; }

		public double GetAdditionalEnchantmentCost() { return MagicEnchantmentCostModification; }
	}
}
