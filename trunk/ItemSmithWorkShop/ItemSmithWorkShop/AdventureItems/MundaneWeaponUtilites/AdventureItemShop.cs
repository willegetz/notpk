using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureItems
{
	public abstract class AdventureItemShop
	{
		public AdventureItem OrderItem(string itemName)
		{

			var adventureItem = CreateItem(itemName);

			return adventureItem;
		}

		protected abstract AdventureItem CreateItem(string itemName);
	}
}
