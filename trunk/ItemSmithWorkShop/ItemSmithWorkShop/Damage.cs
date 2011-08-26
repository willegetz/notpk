namespace ItemSmithWorkShop
{
	//		Damage
	//			Base Damage
	//			Threat Range
	//			Critical Multiplier
	//			Damage Type
	public class Damage
	{
		public string BaseDamage { get; set; }
		public string DamageType { get; set; }
		public string ThreatRange { get; set; }
		public string CriticalMultiplier { get; set; }

		public Damage(string damage, string type, string threat, string critical)
		{
			BaseDamage = damage;
			DamageType = type;
			ThreatRange = threat;
			CriticalMultiplier = critical;
		}

		public override string ToString()
		{
			return string.Format("Base Damage: {0} Damage Type: {1} Threat Range: {2} Critical Multiplier {3}", BaseDamage, DamageType, ThreatRange, CriticalMultiplier);
		}
	}
}
