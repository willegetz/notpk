using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class NullTrapBase : TrapBases
	{
		public NullTrapBase()
		{
			TrappedObjectOrArea = "Invalid trap selection";
			RollUpperBound = -1;
			MechanismTypeSpecified = false;
			MechanismType = string.Empty;
		}
	}
}
