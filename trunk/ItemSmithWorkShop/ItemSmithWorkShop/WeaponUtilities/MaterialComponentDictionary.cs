using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventureItems;

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
			return componentData[materialComponent];
		}

		private static void LoadComponentDictionary()
		{
			componentData = new Dictionary<string, MaterialComponentData>(StringComparer.OrdinalIgnoreCase)
			{
				{"Masterwork", new MaterialComponentData{ Name = "Masterwork ", ComponentCostModifier = 0, MasterworkCostModifier = 300, ComponentWeightModifier = 1,
				ToHitBonus = "+1", ComponentDamageModifier = 0, ComponentDescription = "A masterwork {0} has an additional +1 to hit.\r\n\t"}},
			};
			
		}
	}
}
