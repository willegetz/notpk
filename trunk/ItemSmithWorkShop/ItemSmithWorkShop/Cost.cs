namespace ItemSmithWorkShop
{
	//		Cost
	//			Base Cost
	//			Currency Type
	public class Cost
	{
		public int WeaponCost { get; set; }
		
		public string currencyType;

		public Cost(int cost, string currency)
		{
			WeaponCost = cost;
			currencyType = currency;
		}

		public override string ToString()
		{
			return string.Format("Base Cost: {0} Currency Type: {1}", WeaponCost, currencyType);
		}
		// Operate on the cost
		// Display the cost and currency
	}
}
