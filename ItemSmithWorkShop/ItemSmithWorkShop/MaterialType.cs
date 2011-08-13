using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Material Type
	//			Cost adjustment
	public class MaterialType
	{
		public string materialType;
		public int costAdjustment;

		public MaterialType(string material, int adjustment)
		{
			materialType = material;
			costAdjustment = adjustment;
		}
	}
}
