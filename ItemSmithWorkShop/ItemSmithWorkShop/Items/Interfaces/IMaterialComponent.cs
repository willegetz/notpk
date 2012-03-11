using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IMaterialComponent
	{
		string ComponentName { get; }
		double WeaponCostModifier { get; }
		bool IsMasterwork { get; }
	}
}
