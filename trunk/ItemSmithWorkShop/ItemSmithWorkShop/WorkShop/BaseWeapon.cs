using System;

namespace ItemSmithWorkShop
{
	public class BaseWeapon
	{
		// Base weapon defined
		protected string WeaponName { get; set; }
		protected string WeaponProficiency { get; set; }
		protected string WeaponCategory { get; set; }
		protected string WeaponAttackType { get; set; }
		protected decimal WeaponMonetaryCost { get; set; }
		protected string CurrencyType { get; set; }
		protected string WeaponBaseDamage { get; set; }
		protected string WeaponThreatRange { get; set; }
		protected string WeaponCriticalDamage { get; set; }
		protected string WeaponWeight { get; set; }
		protected string WeaponDamageType { get; set; }

		// Adjustments made to base weapon
		protected string WeaponPrefix { get; set; }
		protected int WeaponToHitModifier { get; set; }
		protected string ToHitModifierType { get; set; }
		protected int WeaponDamageEnhancementModifier { get; set; }
		protected string WeaponDamageModifierType { get; set; }
		protected int MinimumCasterLevel { get; set; }
		protected int CraftingTimeInDays { get; set; }
		protected bool IsMasterwork;
		public bool IsMagical;

		public BaseWeapon() { }

		public override string ToString()
		{
			return String.Format("Weapon Name:\t\t{0}{1}" + "\r" +
								 "Weapon Proficiency:\t{2}" + "\r" +
								 "Weapon Category:\t{3}" + "\r" +
								 "Weapon Attack Type:\t{4}" + "\r" +
								 "Weapon Cost:\t\t{5:n0}{6}" + "\r" +
								 "To Hit Modifier:\t+{7}{8}" + "\r" +
								 "Base Damage:\t\t{9}+{10}{11}" + "\r" +
								 "Threat Range:\t\t{12}" + "\r" +
								 "Critical Damage:\t{13}" + "\r" +
								 "Weapon Weight:\t\t{14}" + "\r" +
								 "Damage Type(s):\t\t{15}" + "\r\r" +
								 "Minimum Caster Level:\t{16}" + "\r" +
								 "Days To Create:\t\t\t{17} days",
								 WeaponPrefix, WeaponName, WeaponProficiency, WeaponCategory, WeaponAttackType, WeaponMonetaryCost, CurrencyType, WeaponToHitModifier, ToHitModifierType, WeaponBaseDamage, WeaponDamageEnhancementModifier, WeaponDamageModifierType, WeaponThreatRange, WeaponCriticalDamage, WeaponWeight, WeaponDamageType, MinimumCasterLevel, CraftingTimeInDays);
		}

		public virtual void GetWeaponStatistics(string weaponName, string weaponProficiency, string weaponCategory, string weaponAttackType, decimal weaponCost, string currencyType, int weaponToHitModifier, string weaponBaseDamage, string weaponThreatRange, string weaponCriticalDamage, string weaponWeight, string weaponDamageType)
		{
			WeaponName = weaponName;
			WeaponProficiency = weaponProficiency;
			WeaponCategory = weaponCategory;
			WeaponAttackType = weaponAttackType;
			WeaponMonetaryCost = weaponCost;
			CurrencyType = currencyType;
			WeaponToHitModifier = weaponToHitModifier;
			WeaponBaseDamage = weaponBaseDamage;
			WeaponThreatRange = weaponThreatRange;
			WeaponCriticalDamage = weaponCriticalDamage;
			WeaponWeight = weaponWeight;
			WeaponDamageType = weaponDamageType;
		}

		public void IsMasterworkQualifier(bool qualifier)
		{
			IsMasterwork = qualifier;
			MasterworkWeapon();
		}

		private void MasterworkWeapon()
		{
			if (IsMasterwork)
			{
				WeaponPrefix = "Masterwork ";
				WeaponMonetaryCost = WeaponMonetaryCost + 300;
				WeaponToHitModifier = WeaponToHitModifier + 1;
				ToHitModifierType = " Enhancement";
			}
		}

		public void MagicWeaponQualifier(int enhancementBonus)
		{
			if (IsMasterwork && enhancementBonus >= 1 && enhancementBonus <= 5)
			{
				IsMagical = true;
			}
			else
			{
				IsMagical = false;
			}
		}

		public void MagicWeapon(int enhancementBonus, int totalEnhancementBonus)
		{
			MagicWeaponQualifier(enhancementBonus);

			if (IsMagical)
			{
				UpdateWeaponEnhancementText(enhancementBonus);
				UpdateWeaponEnhancementModifiers(enhancementBonus);
				MagicWeaponBaseCost(totalEnhancementBonus);
				DetirmineCasterLevelToCreateBasicMagicWeapon(enhancementBonus);
			}
		}

		private void UpdateWeaponEnhancementText(int enhancementBonus)
		{
			WeaponPrefix = "+" + enhancementBonus + " Magical ";

			WeaponDamageModifierType = " Enhancement";
			WeaponDamageType = WeaponDamageType + ", Magic";
		}

		private void UpdateWeaponEnhancementModifiers(int enhancementBonus)
		{
			WeaponToHitModifier = WeaponToHitModifier + (enhancementBonus - 1);
			WeaponDamageEnhancementModifier = enhancementBonus;
		}

		public void MagicWeaponBaseCost(int totalEnhancementBonus)
		{
			int baseCost = (totalEnhancementBonus * totalEnhancementBonus) * 2000;
			WeaponMonetaryCost = WeaponMonetaryCost + baseCost;
			TimeToCreate(baseCost);
		}

		public void DetirmineCasterLevelToCreateBasicMagicWeapon(int combatEnhancement)
		{
			MinimumCasterLevel = combatEnhancement * 3;
		}

		internal void TimeToCreate(int baseValue)
		{
			CraftingTimeInDays = baseValue / 1000;
		}
	}
}