using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Cost
	//			Base Cost
	//			Currency Type
	public class Cost
	{
		private int masterWorkWeaponCost = 300;

		public int WeaponCost { get; set; }
		public bool IsMasterWork { get; set; }
		public string currencyType;

		public Cost(){}

		public Cost(int cost, string currency)
		{
			WeaponCost = cost;
			currencyType = currency;
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
				WeaponCost += masterWorkWeaponCost;
			}
		}

		public override string ToString()
		{
			return String.Format("Weapon Cost:\t\t{0} {1}", WeaponCost.ToString(), currencyType);
		}
		// Operate on the cost
		// Display the cost and currency
	}
}
