using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	public class MagicWeapon
	{
		private GenericDagger Dagger { get; set; }
		private string MagicDamageType { get { return "Magic"; } }

		private double TotalEnhancementCost { get; set; }
		private double TotalEnhancementBonus { get; set; }
		private double plusEnhancementBonus;
		private double enhancementMultiplier = 2000;
		private double coldIronAdditionalCost = 2000;

		public MagicWeapon(GenericDagger dagger, int plusEnhancement)
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
				plusEnhancementBonus = plusEnhancement;
			}
			return;
		}

		public void IsGlowingWeapon(bool qualifier)
		{
			if (qualifier)
			{
				Dagger.WeaponName = String.Format("{0} Glowing", Dagger.WeaponName);
				Dagger.WeaponText = String.Format("{0}\n\tThis weapon sheds light equivelant to a light spell\n\t\t(bright light in a 20 foot radius, shadowy light in a 40 foot radius)\n\t\tThe light from this weapon can't be concealed when drawn, nor can it be shut off.", Dagger.WeaponText);
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

		private void CalculateMagicalCost()
		{
			TotalEnhancementBonus = plusEnhancementBonus;
			
			if (Dagger.IsColdIron)
			{
				TotalEnhancementCost = ((TotalEnhancementBonus * TotalEnhancementBonus) * enhancementMultiplier) + coldIronAdditionalCost;
			}
			else
			{
			TotalEnhancementCost = (TotalEnhancementBonus * TotalEnhancementBonus) * enhancementMultiplier;
			}
		}

		private void CalculateCasterLevel()
		{
			Dagger.CasterLevel = plusEnhancementBonus * 3;
		}

		public void CalculateCreationDays()
		{
			Dagger.DaysToCreate = TotalEnhancementCost / 1000;
		}

		public void CalculateExperienceCost()
		{
			Dagger.ExperienceCost = TotalEnhancementCost / 25;
		}

		public void CalculateRawMaterialCost()
		{
			Dagger.RawMaterialCost = TotalEnhancementCost / 2;
		}

		private void SetMagicalTraits()
		{
			Dagger.IsMagical = true;
			CheckMasterworkStatus();
			CalculateMagicalCost();
			CalculateCasterLevel();
			CalculateCreationDays();
			CalculateExperienceCost();
			CalculateRawMaterialCost();
			MagicItemDisplay();
		}

		private Object MagicItemDisplay()
		{
			Dagger.WeaponName = String.Format("+{0} {1}", plusEnhancementBonus, Dagger.WeaponName);
			Dagger.ToHitModifier = plusEnhancementBonus;
			Dagger.WeaponDamage = String.Format("{0} +{1}", Dagger.WeaponDamage, plusEnhancementBonus);
			Dagger.WeaponDamageType = String.Format("{0}, {1}", Dagger.WeaponDamageType, MagicDamageType);
			Dagger.WeaponCost += TotalEnhancementCost;
			Dagger.WeaponHardness += plusEnhancementBonus;
			Dagger.WeaponHitPoints += plusEnhancementBonus;

			return Dagger;
		}
	}
}
