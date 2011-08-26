using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Material Type
	//			Cost adjustment
	public class WeaponMake
	{
		public string materialType;
		public int costAdjustment;

		public WeaponMake(string material, int adjustment)
		{
			materialType = material;
			costAdjustment = adjustment;
		}



		public override string ToString()
		{
			return String.Format("Material:\t\t\t{0}", materialType);
		}
	}
}
