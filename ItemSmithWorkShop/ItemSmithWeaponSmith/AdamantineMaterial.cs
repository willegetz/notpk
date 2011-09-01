using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWeaponSmith
{
	public class AdamantineMaterial : MaterialComponent
	{
		public override int PriceAdjustment
		{
			get
			{
				return base.PriceAdjustment + 3000;
			}
			set
			{
				base.PriceAdjustment = value;
			}
		}

		public AdamantineMaterial()
		{
			MaterialName = "Adamantine";
			ToHitModifier = 1;
			HitPointModifier = 1.33;
			SpecialText = "Bypass 20 Hardness";
		}

		private string DisplayAdamantineMaterial()
		{
			var sb = new StringBuilder();

			sb.Append(String.Format("Material Name: {0}\n", MaterialName));
			sb.Append(String.Format("To Hit Modifier +{0}\n", ToHitModifier));
			sb.Append(String.Format("Price Adjustment: +{0} gold pieces\n", PriceAdjustment));
			sb.Append(String.Format("Hit Point Modifier: x{0}\n", HitPointModifier));
			sb.Append(String.Format("Special Properties: {0}", SpecialText));

			return sb.ToString();
		}

		public override string ToString()
		{
			
			return DisplayAdamantineMaterial();
		}
	}
}
