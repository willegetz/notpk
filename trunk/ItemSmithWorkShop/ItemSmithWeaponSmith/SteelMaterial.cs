using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class SteelMaterial : MaterialComponent
	{
		public SteelMaterial()
		{
			MaterialName = "Steel";
			ToHitModifier = 0;
			PriceAdjustment = 0;
			HardnessModifier = 1;
			SpecialText = "Additional information and flavor text";
		}

		private string DisplaySteelMaterial()
		{
			var sb = new StringBuilder();

			sb.Append(String.Format("Material Name: {0}\n", MaterialName));
			sb.Append(String.Format("To Hit Modifier +{0}\n", ToHitModifier));
			sb.Append(String.Format("Price Adjustment: +{0} gold pieces\n", PriceAdjustment));
			sb.Append(String.Format("Hardness Modifier: x{0}\n", HardnessModifier));
			sb.Append(String.Format("Special Properties: {0}", SpecialText));

			return sb.ToString();
		}

		public override string ToString()
		{

			return DisplaySteelMaterial();
		}
	}
}
