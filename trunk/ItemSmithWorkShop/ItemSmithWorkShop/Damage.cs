using System;
using System.Collections.Generic;

namespace ItemSmithWorkShop
{
	//		Damage
	//			Base Damage
	//			Threat Range
	//			Critical Multiplier
	//			Damage Type
	public class Damage
	{
		public IList<String> combatDamage = new List<String>();

		public string BaseDamage { get; set; }
		public string DamageType { get; set; }
		public string ThreatRange { get; set; }
		public string CriticalMultiplier { get; set; }

		public Damage(string damage, string type, string threat, string critical)
		{
			combatDamage.Add(damage);
			combatDamage.Add(type);
			combatDamage.Add(threat);
			combatDamage.Add(critical);

			BaseDamage = damage;
			DamageType = type;
			ThreatRange = threat;
			CriticalMultiplier = critical;
		}

		public override string ToString()
		{
			return string.Format("Base Damage: {0}\nDamage Type: {1}\nThreat Range: {2}\nCritical Multiplier {3}", BaseDamage, DamageType, ThreatRange, CriticalMultiplier);
		}
	}
}
