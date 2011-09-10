using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class MagicWeapon
	{
		private SimpleDagger Dagger { get; set; }

		private int combatEnhancementBonus;

		public MagicWeapon(SimpleDagger dagger, int plusEnhancement)
		{
			if (dagger == null)
			{
				return;
			}
			Dagger = dagger;
			ConfirmValidPlusEnhancement(plusEnhancement);
			SetMagicalTraits();
		}

		private void ConfirmValidPlusEnhancement(int plusEnhancement)
		{
			if (plusEnhancement > 0 && plusEnhancement <=5)
			{
				combatEnhancementBonus = plusEnhancement;
			}
			return;
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

		private Object SetMagicalTraits()
		{
			CheckMasterworkStatus();

			Dagger.WeaponName = String.Format("+{0} {1}", combatEnhancementBonus, Dagger.WeaponName);
			Dagger.ToHitModifier = combatEnhancementBonus;

			return Dagger;
		}
	}
}
