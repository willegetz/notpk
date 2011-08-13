using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItemSmithWorkShop
{
	//		Damage
	//			Base Damage
	//			Threat Range
	//			Critical Multiplier
	//			Damage Type
	public class Damage
	{
		public string baseDamage;
		public string threatRange;
		public string criticalMultiplier;
		public string damageType;

		public Damage(string damage, string threat, string critical, string type)
		{
			baseDamage = damage;
			threatRange = threat;
			criticalMultiplier = critical;
			damageType = type;
		}


	}
}
