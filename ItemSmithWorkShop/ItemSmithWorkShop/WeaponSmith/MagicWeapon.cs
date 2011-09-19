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
		public double TotalEnhancementBonus { get; set; }
		public double MagicAbilityEnhancement { get; set; }

		private double MagicAbilityCasterLevel { get; set; }
		private double HardnessEnhancementBonus { get; set; }
		private double HitPointEnhancementBOnus { get; set; }
		private double enhancementBonus;
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
			CheckMasterworkStatus();
			SetMagicalTraits();
			MagicItemDisplay();
		}

		private void ConfirmValidPlusEnhancement(int plusEnhancement)
		{
			if (plusEnhancement > 0 && plusEnhancement <=5)
			{
				enhancementBonus = plusEnhancement;
				Dagger.PlusEnhancementBonus = plusEnhancement;
			}
			return;
		}

		public void IsGlowingWeapon(bool qualifier)
		{
			if (qualifier)
			{
				Dagger.WeaponName = string.Format("{0} [Glowing]", Dagger.WeaponName);
				Dagger.WeaponText = string.Format("{0}\n\tThis weapon sheds light equivalent to a light spell\n\t\t(bright light in a 20 foot radius, shadowy light in a 40 foot radius)\n\t\tThe light from this weapon can't be concealed when drawn, nor can it be shut off.", Dagger.WeaponText);
			}
		}

		private void CheckMasterworkStatus()
		{
			if (Dagger.IsMasterwork)
			{
				Dagger.MasterWorkLabel = string.Empty;
				return;
			}
			else
			{
				Dagger.IsMasterworkQualifier(true);
				Dagger.MasterWorkLabel = string.Empty;
			}
		}

		private void CalculateMagicalCost()
		{
			TotalEnhancementBonus = enhancementBonus + MagicAbilityEnhancement;
			
			if (Dagger.IsColdIron)
			{
				TotalEnhancementCost = ((TotalEnhancementBonus * TotalEnhancementBonus) * enhancementMultiplier) + coldIronAdditionalCost;
			}
			else
			{
				TotalEnhancementCost = (TotalEnhancementBonus * TotalEnhancementBonus) * enhancementMultiplier;
			}
			Dagger.EnchantmentCost = TotalEnhancementCost;
		}

		private void CalculateCasterLevel()
		{
			if (MagicAbilityCasterLevel == 0)
			{
				Dagger.CasterLevel = enhancementBonus * 3;
			}
			else
			{
				if (Dagger.CasterLevel >= MagicAbilityCasterLevel)
				{
					Dagger.CasterLevel = enhancementBonus * 3;
				}
				else
				{
					Dagger.CasterLevel = MagicAbilityCasterLevel;
				}
			}
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

		public void CalculateHardness()
		{
			Dagger.WeaponHardness += (enhancementBonus * 2);
		}

		public void CalculateHitPoints()
		{
			Dagger.WeaponHitPoints += (enhancementBonus * 10);
		}

		private void SetMagicalTraits()
		{
			Dagger.IsMagical = true;
			CalculateMagicalCost();
			CalculateCasterLevel();
			CalculateCreationDays();
			CalculateExperienceCost();
			CalculateRawMaterialCost();
			CalculateHardness();
			CalculateHitPoints();
		}

		private Object MagicItemDisplay()
		{
			Dagger.WeaponName = string.Format("+{0} {1}", Dagger.PlusEnhancementBonus, Dagger.WeaponType);
			Dagger.ToHitModifier = enhancementBonus;
			Dagger.WeaponDamage = string.Format("{0} +{1}", Dagger.WeaponDamage, enhancementBonus);
			Dagger.WeaponDamageType = string.Format("{0}, {1}", Dagger.WeaponDamageType, MagicDamageType);
			Dagger.CalculateWeaponCost();

			return Dagger;
		}

		List<MagicWeapon> weaponEnchantments = new List<MagicWeapon>();

		private string MagicAbilityName { get; set; }

		public void EnchantWeaponWith(string magicAbility)
		{
			MagicAbilityName = magicAbility;
			MagicAbilityCasterLevel = 10;

			SetMagicAbility();
		}

		private void SetMagicAbility()
		{
			Dagger.WeaponName = string.Format("+{0} {1} {2}", Dagger.PlusEnhancementBonus, MagicAbilityName, Dagger.WeaponType);
			Dagger.WeaponDamage = string.Format("{0} +1d6", Dagger.WeaponDamage);
			Dagger.WeaponDamageType = string.Format("{0}, Fire", Dagger.WeaponDamageType);
			MagicAbilityEnhancement = 1;
			Dagger.WeaponText = string.Format("{0}\n\n\tUpon command, a flaming weapon is sheathed in fire.\n\tThe fire does not harm the wielder. The effect\n\tremains until another command is given.\n\tCraft Magic Arms and Armor and flame blade, flame strike, or fireball", Dagger.WeaponText);
			//CalculateMagicalCost();
			SetMagicalTraits();
			Dagger.CalculateWeaponCost();
		}
	}
}
