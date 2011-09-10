﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class MagicWeapon
	{
		private SimpleDagger Dagger { get; set; }
		private string MagicDamageType { get { return "Magic"; } }

		private double TotalEnhancementCost { get; set; }
		private double TotalEnhancementBonus { get; set; }
		private double plusEnhancementBonus;

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
				plusEnhancementBonus = plusEnhancement;
			}
			return;
		}

		public void IsGlowingWeapon(bool qualifier)
		{
			if (qualifier)
			{
				Dagger.IsMagical = qualifier;
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
			TotalEnhancementCost = (TotalEnhancementBonus * TotalEnhancementBonus) * 2000;
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
