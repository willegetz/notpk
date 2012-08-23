using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class PitTrapEffectFactory : ISpecificTrapFactory
	{
		private TrapEffectFactory pitContentEffectFactory;
		private DiceCup pitTrapTableDie;
		private string pitTrapContents;

		public PitTrapEffectFactory(TrapEffectFactory pitContentEffectFactory, DiceCup pitTrapTableDie, string pitTrapContents)
		{
			// TODO: Complete member initialization
			this.pitContentEffectFactory = pitContentEffectFactory;
			this.pitTrapTableDie = pitTrapTableDie;
			this.pitTrapContents = pitTrapContents;
		}
		public string Get()
		{
			return pitTrapContents + " " + pitContentEffectFactory.GetFactory(pitTrapTableDie.Roll()).Get();
		}
	}
}
