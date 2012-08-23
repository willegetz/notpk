using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class ComplexTrapEffectFactory : ISpecificTrapFactory
	{
		private TrapEffectFactory effectFactory;
		private DiceCup mainTableDice;
		private string effectDescription;

		public ComplexTrapEffectFactory(TrapEffectFactory effectFactory, DiceCup mainTableDice, string effectDescription)
		{
			// TODO: Complete member initialization
			this.effectFactory = effectFactory;
			this.mainTableDice = mainTableDice;
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			return effectDescription + ", and " + effectFactory.GetFactory(mainTableDice.Roll()).Get();
		}
	}
}
