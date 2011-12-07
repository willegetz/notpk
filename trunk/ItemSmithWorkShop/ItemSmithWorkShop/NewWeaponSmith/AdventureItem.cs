using System;
using System.Collections.Generic;
using System.Linq;

namespace NewWeaponSmith
{
	public abstract class AdventureItem
	{
		public string itemName = "Unknown Item";

		public virtual string GetItemName()
		{
			return itemName;
		}

		public abstract double GetCost();
	}
}
