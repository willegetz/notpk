using System;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private string TrapBase { get; set; }
		private string TrapEffect { get; set; }
		private string TrapDamage { get; set; }
		private string MechanismType { get; set; }

		public void SetTrapBase(TrapBases trapBase)
		{
			TrapBase = trapBase.TrappedObjectOrArea;
			MechanismType = trapBase.MechanismType;
		}

		public void SetTrapEffect(TrapEffects trapEffect)
		{
			TrapEffect = trapEffect.EffectDescription.ToLower();
		}

		public void SetTrapDamage(TrapDamages trapDamages)
		{
			TrapDamage = trapDamages.DamageDescription.ToLower();
		}

		public override string ToString()
		{
			return string.Format("{0}{1} {2} and {3}", TrapBase, MechanismType, TrapEffect, TrapDamage);
		}

		public void ChangeMechanismType(string newMechanismType)
		{
			if (!string.IsNullOrEmpty(MechanismType))
			{
				MechanismType = string.Format(" ({0})", newMechanismType);
			}
		}
	}
}
