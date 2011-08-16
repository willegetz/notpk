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
		private Cost cost;
		private int baseCost;

		protected bool IsMasterWork { get; set; }		

		public string materialType;
		public int costAdjustment;

		public WeaponMake(string material, int adjustment)
		{
			baseCost = cost.WeaponCost;
			materialType = material;
			costAdjustment = adjustment;
		}

		public override string ToString()
		{
			return String.Format("Material:\t\t\t{0}", materialType);
		}

		public void IsMasterWorkQualifier(bool qualifier)
		{
			IsMasterWork = qualifier;
			MasterWorkWeapon();
		}

		private void MasterWorkWeapon()
		{
			if (IsMasterWork)
			{
				cost.WeaponCost = cost.WeaponCost + costAdjustment;
			}
		}
	}
}
