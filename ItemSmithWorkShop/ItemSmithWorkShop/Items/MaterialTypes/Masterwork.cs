using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;

namespace ItemSmithWorkShop.Items.MaterialTypes
{
	public class Masterwork : IMaterialComponent
	{
		// Masterwork applies to weapons, armor, and shields.
		// Depending on what is needed, Masterwork will do its thing.
		// Weapon adjustments will be made to weapons.
		// Armor adjustments will be made to armor.
		// Shield adjustments will be made to shields
		// Items that are not weapons, armor, and shields can also be made masterwork

		// Weapons
		// Attack roll bonus: +1 Enchantment
		// Cost is an additional 300 gold pieces

		// Armor and Shields
		// Armor check penalty is reduced by 1
		// Cost is an additional 150 gold pieces


		public string ComponentName { get { return "Masterwork"; } }
		public double WeaponCostModifier { get { return 300; } }
		public bool IsMasterwork { get { return true; } }
		public string ToHitBonus { get { return "+1"; } }


		#region IMaterialComponent Members


		public double ApplyCostModifier(IWeapon weaopn)
		{
			throw new NotImplementedException();
		}

		public double GetAdditionalEnchantmentCost()
		{
			throw new NotImplementedException();
		}

		public bool VerifyMasterwork(IWeapon weapon)
		{
			throw new NotImplementedException();
		}

		public string AppendSpecialInfo(IWeapon weapon)
		{
			throw new NotImplementedException();
		}

		public double ApplyWeightModifer(IWeapon weapon)
		{
			throw new NotImplementedException();
		}

		public string ApplyToHitModifier()
		{
			return ToHitBonus;
		}

		#endregion
	}
}
