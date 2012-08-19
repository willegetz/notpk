using System;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private string TrapBase { get; set; }
		public string TrapEffect { get; set; }

		public void SetTrapBase(TrapBases trapBase)
		{
			TrapBase = trapBase.TrappedObjectOrArea;
		}

		public void SetTrapEffect(TrapEffects trapEffect)
		{
			TrapEffect = trapEffect.EffectDescription;
		}
	}
}
