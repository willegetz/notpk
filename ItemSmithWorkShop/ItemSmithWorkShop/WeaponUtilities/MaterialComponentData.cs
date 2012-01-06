using System;
using System.Linq;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class MaterialComponentData
	{
		public string Name { get; set; }
		public double ComponentCostModifier { get; set; }
		public int MasterworkCostModifier { get; set; }
		public double ComponentWeightModifier { get; set; }
		public string ToHitBonus { get; set; }
		public int ComponentDamageModifier { get; set; }
		public string ComponentDescription { get; set; }
		public bool IsMasterwork { get; set; }
		public double AdditionalCostModifier { get; set; }
	}
}
