using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureItems
{
	// AdventureItem should be the overall return type for a weapon.
	public abstract class AdventureItem
	{
		protected string name = "Unknown Item";
		protected double cost;

		public virtual string GetItem()
		{
			return string.Format("{0}:\t'{1} gp", name, cost);
		}
	}
}
