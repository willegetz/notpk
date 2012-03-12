using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.Items.Interfaces;
using ItemSmithWorkShop.Items.Weapons;
using ItemSmithWorkShop.Items.Data;

namespace ItemSmithWorkShop.Items.TheForge
{
	public class ItemForge
	{
		private static IWeapon weapon;
		private static IMaterialComponent component;

		public static ForgedWeapon ForgeWeapon(IWeapon weaponPart, IMaterialComponent componentPart)
		{
			var forgedWeapon = new ForgedWeapon();
			weapon = weaponPart;
			component = componentPart;

			forgedWeapon.additionalEnchantmentCost = component.GetAdditionalEnchantmentCost();
			forgedWeapon.componentName = component.ComponentName;
			forgedWeapon.criticalDamage = weapon.CriticalDamage;
			forgedWeapon.damage = weapon.Damage;
			forgedWeapon.damageType = weapon.DamageType;
			forgedWeapon.givenName = weapon.GivenName;
			forgedWeapon.isMasterwork = component.VerifyMasterwork(weapon);
			forgedWeapon.maxRange = weapon.MaxRange;
			forgedWeapon.proficiency = weapon.Proficiency;
			forgedWeapon.rangeIncrement = weapon.RangeIncrement;
			forgedWeapon.specialInfo = component.AppendSpecialInfo(weapon);
			forgedWeapon.threatRange = weapon.ThreatRange;
			forgedWeapon.weaponCategory = weapon.WeaponCategory;
			forgedWeapon.weaponCost = component.ApplyCostModifier(weapon);
			forgedWeapon.weaponName = weapon.WeaponName;
			forgedWeapon.weaponSize = weapon.WeaponSize;
			forgedWeapon.weaponSubCategory = weapon.WeaponSubCategory;
			forgedWeapon.weaponUse = weapon.WeaponUse;
			forgedWeapon.weight = component.ApplyWeightModifer(weapon);
			forgedWeapon.toHitModifier = component.ApplyToHitModifier();

			return forgedWeapon;
		}
	}
}
