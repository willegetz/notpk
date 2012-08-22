using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJK.CSharp.CustomLists.RangeDictionary;
using DungeonBuildersGuidebook1.TrapComponentObjects;

namespace DungeonBuildersGuidebook1.Factories
{
	public class SimpleTrapEffectFactory
	{
		private RangeDictionary<int, TrapEffects> trapEffectsTable;
		private RangeDictionary<int, SpecificTrapFactory> trapEffectsTable1;

		public SimpleTrapEffectFactory(RangeDictionary<int, SpecificTrapFactory> trapEffectsTable)
		{
			// TODO: Complete member initialization
			this.trapEffectsTable1 = trapEffectsTable;
		}

		public SpecificTrapFactory GetFactory(int specificResult)
		{
			return trapEffectsTable1[specificResult];
		}
	}
}
