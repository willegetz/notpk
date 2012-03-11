using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Weapons.Interfaces
{
	public interface IMaterialComponents
	{
		string ComponentName { get; }
		double WeaponCostModifier { get; }
		bool IsMasterwork { get; }
	}
}
