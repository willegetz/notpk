using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;
using ItemSmithWorkShop.WeaponUtilities;
using ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites;

namespace ItemSmithWorkShop.AdventureItems.WeaponAdons
{
	public class MasterworkWeaponItem : WeaponItemWeaver
	{
		WeaponItemWeaver weaponItem;
		MaterialComponentOrder materialComponent;
		WeaponOrder weaponOrder;
		private WeaponOrder weapon;
		private MaterialComponentOrder component;

		public MasterworkWeaponItem(WeaponItemWeaver weapon, MaterialComponentOrder component)
		{
			weaponItem = weapon;
			materialComponent = component;
		}

		public MasterworkWeaponItem(WeaponOrder weapon, MaterialComponentOrder component)
		{
			weaponOrder = weapon;
			materialComponent = component;
			AlternateAssignmentPath();
		}

		private void AlternateAssignmentPath()
		{
			weaponOrder.SetName(materialComponent.Name);
			weaponOrder.SetCost(materialComponent.CostModifier, materialComponent.MasterworkCost);
			weaponOrder.SetToHit(materialComponent.ToHit);
			weaponOrder.SetDescription(materialComponent.Description);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(string.Format("Name: '{0}'", weaponOrder.Name));
			sb.AppendLine(string.Format("Cost: '{0}'", weaponOrder.Cost));
			sb.AppendLine(string.Format("To Hit: '{0}'", weaponOrder.ToHit));
			sb.AppendLine(string.Format("Damage: '{0}'", weaponOrder.Damage));
			sb.AppendLine(string.Format("Weight: '{0}'", weaponOrder.Weight));
			sb.AppendLine(string.Format("Description: {0}", weaponOrder.Description));
			return sb.ToString();
		}

		public override bool IsMasterwork()
		{
			return true;
		}

		public override string GetName()
		{
			return materialComponent.Name + weaponItem.GetName();
		}

		public override double GetCost()
		{
			return weaponItem.GetCost() + materialComponent.MasterworkCost;
		}

		public override string GetToHit()
		{
			return materialComponent.ToHit;
		}

		// required for display
		public override string GetDamage()
		{
			return weaponItem.GetDamage();
		}

		// required for display
		public override double GetWeight()
		{
			return weaponItem.GetWeight();
		}

		public override string GetDescription()
		{
			return string.Format(materialComponent.Description, weaponItem.GetName()) + weaponItem.GetDescription();
		}

		internal string GetItem()
		{
			return DisplayUtilities.BasicDisplay(GetName(), GetCost(), GetWeight(), GetToHit(), GetDamage(), GetDescription());
		}
	}
}
