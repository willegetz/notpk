using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class NullTrapDamage : TrapDamages
	{
		public NullTrapDamage(int spcificResult, int minimumBounds, int maximumBounds)
		{
			base.DamageDescription = string.Format("Invalid trap damage selection. '{0}' is not within the bounds '{1} - {2}'", spcificResult, minimumBounds, maximumBounds);
			base.RollUpperBound = -1;
		}
	}
}
