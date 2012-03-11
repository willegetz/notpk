using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop.Items.Interfaces
{
	public interface IWeapon
	{
		string Proficiency { get;}
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
		double RangeIncrement { get;}
		double MaxRange { get;}
		double Weight { get;}
		string DamageType { get;}
		string SpecialInfo { get;}

		string GivenName { get;}
	}
}
