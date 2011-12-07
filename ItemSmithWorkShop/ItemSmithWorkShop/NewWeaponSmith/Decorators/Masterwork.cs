using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewWeaponSmith;

namespace Decorators
{
	public class Masterwork : AdventureItemDecorator
	{
		AdventureItem adventureItem;

		public Masterwork(AdventureItem item)
		{
			adventureItem = item;
		}

		public override string GetItemName()
		{
			return "Masterwork " + adventureItem.GetItemName();
		}

		public override double GetCost()
		{
			return 300 + adventureItem.GetCost();
		}
	}
}
