using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class NullTrapEffect : TrapEffects
	{
		public NullTrapEffect(int spcificResult, int minimumBounds, int maximumBounds)
		{
			base.RollUpperBound = -1;
			base.EffectDescription = string.Format("Invalid effect selection '{0}' is not within the bounds '{1} - {2}'", spcificResult, minimumBounds, maximumBounds);
			base.AdditionalInformation = string.Empty;
			base.RollAgain = false;
			base.NumberOfReRolls = 0;
		}
	}
}
