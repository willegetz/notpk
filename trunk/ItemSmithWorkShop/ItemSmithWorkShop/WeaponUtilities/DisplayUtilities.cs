using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.WeaponUtilities
{
	public class DisplayUtilities
	{
		internal static string BasicDisplay(string name, double cost, double weight, string toHit, string damage, string description)
		{
			return string.Format("{0}:\t'{1} gp'\r\nWeight: '{2} pound(s)'\r\nTo Hit: '{3}'\r\nDamage: '{4}'\r\n\t{5}", name, cost, weight, toHit, damage, description);
		}
	}
}
