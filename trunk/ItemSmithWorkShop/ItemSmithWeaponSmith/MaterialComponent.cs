using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public abstract class MaterialComponent
	{
		public string MaterialName { get; set; } // Working
		public int ToHitModifier { get; set; } // Working
		public int PriceAdjustment { get; set; } // Working
		public decimal HardnessModifier { get; set; } // Working
		public string SpecialText { get; set; } // Working


	}
}
