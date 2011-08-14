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
		public int weaponCost;
		public string currencyType;

		public Cost(int cost, string currency)
		{
			weaponCost = cost;
			currencyType = currency;
		}

		public override string ToString()
		{
			return String.Format("Weapon Cost:\t\t{0} {1}", weaponCost.ToString(), currencyType);
		}
		// Operate on the cost
		// Display the cost and currency
	}
}
