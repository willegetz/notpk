using System;
using System.Collections.Generic;
using System.Linq;
using ItemSmithWorkShop.AdventureItems.AdventureItemUtilities;

namespace ItemSmithWorkShop.WeaponUtilities
{
	class MaterialComponentDictionary : AdventureItem
	{
		private static Dictionary<string, MaterialComponentData> componentData;

		static MaterialComponentDictionary()
		{
			LoadComponentDictionary();
		}

		public static MaterialComponentData GetComponentData(string materialComponent)
		{
			if (componentData.ContainsKey(materialComponent))
			{
				return componentData[materialComponent];	
			}
			throw new KeyNotFoundException(string.Format("The Material Component '{0}' is not present in this collection of weapons.", materialComponent));
		}

		private static void LoadComponentDictionary()
		{
			componentData = new Dictionary<string, MaterialComponentData>(StringComparer.OrdinalIgnoreCase)
			{
				{ "Masterwork", new MaterialComponentData{ Name = "Masterwork ", ComponentCostModifier = 0, MasterworkCostModifier = 300, ComponentWeightModifier = 1, IsMasterwork = true,
				ToHitBonus = "+1", ComponentDamageModifier = 0, ComponentDescription = "A masterwork {0} has an additional +1 to hit.\r\n\t"}},
				{ "Adamantine", new MaterialComponentData{ Name = "Adamantine ", ComponentCostModifier = 3000, MasterworkCostModifier = 0, ComponentWeightModifier = 1.33, IsMasterwork = true,
				ToHitBonus = "+1", ComponentDamageModifier = 0, ComponentDescription = "Adamantine weapons are always considered to be masterwork quality.\r\n\tAdamantine bypasses a damage reduction of 20.\r\n\t"}},
				{ "Silver", new MaterialComponentData{ Name = "Alchemical Silver ", ComponentCostModifier = 20, MasterworkCostModifier = 0, ComponentWeightModifier = 1, 
				ToHitBonus = "", ComponentDamageModifier = -1, ComponentDescription = "Alchemical Silver bypasses damage reduction on lycanthropes\r\n\t"}},
				{ "Cold Iron", new MaterialComponentData{ Name = "Cold Iron ", ComponentCostModifier = 2, MasterworkCostModifier = 0, ComponentWeightModifier = 1, IsMasterwork = true, AdditionalCostModifier = 2000,
				ToHitBonus = "", ComponentDamageModifier = 0, ComponentDescription = "Cold Iron is effective against some Fey.\r\n\tMagic enhancements cost an additional 2000 gold pieces.\r\n\t"}},
				{ "Darkwood", new MaterialComponentData{ Name = "Darkwood ", ComponentCostModifier = 10, MasterworkCostModifier = 300, ComponentWeightModifier = .5, IsMasterwork = true,
				ToHitBonus = "+1", ComponentDamageModifier = 0, ComponentDescription = "Darkwood weapons are always considered to be masterwork quality.\r\n\t"}},
				{ "Mithral", new MaterialComponentData{ Name = "Mithral ", ComponentCostModifier = 500, MasterworkCostModifier = 0, ComponentWeightModifier = .5, IsMasterwork = true,
				ToHitBonus = "+1", ComponentDamageModifier = 0, ComponentDescription = "Mithral weapons are always considered to be masterwork quality.\r\n\t"}},

			};
			
		}
	}
}
