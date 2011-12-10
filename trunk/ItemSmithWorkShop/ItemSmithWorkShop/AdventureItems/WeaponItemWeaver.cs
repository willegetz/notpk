using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.AdventureItems
{
	public abstract class WeaponItemWeaver
	{
		public virtual string GetName()
		{
			return string.Empty;
		}

		public virtual double GetCost()
		{
			return 0;
		}

		public virtual string GetDescription()
		{
			return string.Empty;
		}

		public virtual double GetWeight()
		{
			return 0;
		}

		public virtual string GetDamage()
		{
			return string.Empty;
		}
	}
}
