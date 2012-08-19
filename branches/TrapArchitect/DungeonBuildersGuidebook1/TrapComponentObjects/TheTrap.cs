using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private string TrapBase { get; set; }

		public void SetTrapBase(TrapBases trapBases)
		{
			TrapBase = trapBases.TrappedObjectOrArea;
		}
	}
}
