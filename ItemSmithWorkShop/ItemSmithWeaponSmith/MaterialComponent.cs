using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public abstract class MaterialComponent
	{
		public string MaterialName { get; set; }
		public int ToHitModifier { get; set; }
		public int PriceAdjustment { get; set; }
		public decimal HardnessModifier { get; set; }
		public string SpecialText { get; set; }


	}
}
