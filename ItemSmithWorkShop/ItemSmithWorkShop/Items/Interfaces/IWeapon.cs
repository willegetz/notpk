using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IWeapon
	{
		// All weapons have these
		string GivenName { get; } // Even if the weapon does not receive a given name, it should be able to have one.
		string Proficiency { get; }
		string WeaponUse { get;}
		string WeaponCategory { get;}
		string WeaponSubCategory { get;}
		string WeaponSize { get;}
		string WeaponName { get;}
		double WeaponCost { get;}
		string Damage { get;}
		double ThreatRangeLowerBound { get; }
		string ThreatRange { get;}
		string CriticalDamage { get;}
		double Weight { get;}
		string DamageType { get;}
		string SpecialInfo { get;}

		bool IsMasterwork { get; }

		// Ranged weapons have a range increment.
		//		Although all weapons can be used as improvised ranged weaopns.
		//			An improvised thrown weapon has a range increment of 10 feet.
		double RangeIncrement { get; }
		double MaxRange { get; }

	}
}
