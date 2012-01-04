using System;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.AdventureItems.MagicWeaponUtilities
{
	public class MagicWeaponItem : WeaponItemWeaver
	{
		private const int PlayerXpInvestment = 25;
		private const int PlayerMaterialInvestment = 2;
		private const int MasterworkCost = 300;
		readonly WeaponItemWeaver weaponItem;
		private readonly int enhancementBonus;
		private const string requiredFeats = "Craft Magic Arms and Armor";

		public MagicWeaponItem(WeaponItemWeaver weapon, int bonus)
		{
			if (bonus < 1 || bonus > 5)
			{
				throw new ArgumentOutOfRangeException("Bonus", bonus, "The Enhancement Bonus must be between 1 and 5");
			}
			weaponItem = weapon;
			enhancementBonus = bonus;
		}

		public override string GetName()
		{
			return string.Format("+{0} {1}", enhancementBonus, weaponItem.GetName());
		}

		private double GetEnhancementCost()
		{
			return (Math.Pow(enhancementBonus, 2) * 2000);
		}

		public override int GetEnhancementBonusForCost()
		{
			return enhancementBonus;
		}

		public override double GetWeaponCost()
		{
			if (weaponItem.IsMasterwork())
			{
				return weaponItem.GetCost();
			}
			return weaponItem.GetCost() + MasterworkCost;
		}

		private double GetCostForEnhancement()
		{
			return GetEnhancementCost() + GetAdditionalMagicCostModifier();
		}

		public override double GetAdditionalMagicCostModifier()
		{
			return weaponItem.GetAdditionalMagicCostModifier();
		}

		public override double GetCost()
		{
			return GetWeaponCost() + GetCostForEnhancement();
		}

		public override string GetDamage()
		{
			return string.Format("{0}{1}", weaponItem.GetDamage(), GetDamageModifier(enhancementBonus, weaponItem.GetDamageModifier()));
		}

		public override string GetThreat()
		{
			return string.Format(" [{0} {1}]", weaponItem.GetThreat(), weaponItem.GetCriticalMultiplier());
		}

		public override string GetDamageType()
		{
			return weaponItem.GetDamageType() + ", Magic";
		}

		private static string GetDamageModifier(int enhancement, int existantDamageModifier)
		{
			if (existantDamageModifier == -1)
			{
				return string.Format(" +{0}", existantDamageModifier + enhancement);
			}
			return string.Format(" +{0}", enhancement);
		}

		public override double GetMinimumCasterLevel()
		{
			return enhancementBonus * 3;
		}

		public override double GetDaysToCreate()
		{
			return GetEnhancementCost() / 1000;
		}

		public override double GetCreationXpCost()
		{
			return GetEnhancementCost() / PlayerXpInvestment;
		}

		public override double GetCreationRawMaterialCost()
		{
			return (GetEnhancementCost() / PlayerMaterialInvestment) + (GetCost() - GetEnhancementCost());
		}

		public override int GetEnhancementBonus()
		{
			return enhancementBonus;
		}

		public override double GetModifiedHardness()
		{
			return weaponItem.GetHardness() + (enhancementBonus * 2);
		}

		public override double GetModifiedHitPoints()
		{
			return weaponItem.GetHitPoints() + (enhancementBonus * 10);
		}

		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDescription()
		{
			return weaponItem.GetDescription();
		}

		public override string GetCreationRequirements()
		{
			return string.Format("\r\n\tRequired Feats: {0}", requiredFeats);
		}
	}
}
