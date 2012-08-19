using System;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private TrapBases TrapBase { get; set; }
		private TrapEffects TrapEffect { get; set; }
		private TrapDamages TrapDamage { get; set; }

		public void SetTrapBase(TrapBases trapBase)
		{
				TrapBase = trapBase;
		}

		public void SetTrapEffect(TrapEffects trapEffect)
		{
			TrapEffect = trapEffect;
		}

		public void SetTrapDamage(TrapDamages trapDamages)
		{
			TrapDamage = trapDamages;
		}

		public override string ToString()
		{
			return string.Format("{0}{1} {2} and {3}", TrapBase.TrappedObjectOrArea, TrapBase.MechanismType.ToLower(), TrapEffect.EffectDescription.ToLower(), TrapDamage.DamageDescription.ToLower());
		}

		public void ChangeMechanismType(string newMechanismType)
		{
			if (!string.IsNullOrEmpty(TrapBase.MechanismType))
			{
				TrapBase.MechanismType = string.Format(" ({0})", newMechanismType);
			}
		}
	}
}
