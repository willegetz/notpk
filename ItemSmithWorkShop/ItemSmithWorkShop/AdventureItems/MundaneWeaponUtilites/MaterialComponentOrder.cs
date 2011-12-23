using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItemSmithWorkShop.WeaponUtilities;

namespace ItemSmithWorkShop.AdventureItems.MundaneWeaponUtilites
{
	public class MaterialComponentOrder
	{

		public string Name { get; private set; }
		public int CostModifier { get; private set; }
		public int MasterworkCost { get; private set; }
		public int WeightModifier { get; private set; }
		public string ToHit { get; private set; }
		public int DamageModifier { get; private set; }
		public string Description { get; private set; }

		public MaterialComponentOrder(MaterialComponentData component)
		{
			ComponentInformation(component);
		}

		private void ComponentInformation(MaterialComponentData component)
		{
			Name = component.Name;
			CostModifier = component.ComponentCostModifier;
			MasterworkCost = component.MasterworkCostModifier;
			WeightModifier = component.ComponentWeightModifier;
			ToHit = component.ToHitBonus;
			DamageModifier = component.ComponentDamageModifier;
			Description = component.ComponentDescription;
		}
	}
}
