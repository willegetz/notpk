using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class MaterialComponentData
	{
		public string Name { get; set; }
		public int ComponentCostModifier { get; set; }
		public int MasterworkCostModifier { get; set; }
		public int ComponentWeightModifier { get; set; }
		public string ToHitBonus { get; set; }
		public int ComponentDamageModifier { get; set; }
		public string ComponentDescription { get; set; }
	}
}
