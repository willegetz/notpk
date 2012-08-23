using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class GasTrapEffectFactory : ISpecificTrapFactory
	{
		private TrapEffectFactory gasTrapContentFactory;
		private DiceCup gasTrapTableDie;
		private string gasTrapContents;

		public GasTrapEffectFactory(TrapEffectFactory gasTrapContentFactory, DiceCup gasTrapTableDie, string gasTrapContents)
		{
			// TODO: Complete member initialization
			this.gasTrapContentFactory = gasTrapContentFactory;
			this.gasTrapTableDie = gasTrapTableDie;
			this.gasTrapContents = gasTrapContents;
		}
		public string Get()
		{
			return gasTrapContents + " " + gasTrapContentFactory.GetFactory(gasTrapTableDie.Roll()).Get();
		}
	}
}
