using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class NullTrapBase : TrapBases
	{
		public NullTrapBase(int spcificResult, int minimumBounds, int maximumBounds)
		{
			base.TrappedObjectOrArea = string.Format("Invalid trap base selection. '{0}' is not within the bounds '{1} - {2}'", spcificResult, minimumBounds, maximumBounds);
			base.RollUpperBound = -1;
			base.MechanismTypeSpecified = false;
			base.MechanismType = string.Empty;
		}
	}
}
