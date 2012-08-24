using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class ComplexTrapEffectFactory : ISpecificTrapFactory
	{
		private readonly TrapEffectFactory effectFactory;
		private readonly DiceCup mainTableDice;
		private readonly string effectDescription;

		public ComplexTrapEffectFactory(TrapEffectFactory effectFactory, DiceCup mainTableDice, string effectDescription)
		{
			this.effectFactory = effectFactory;
			this.mainTableDice = mainTableDice;
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			return effectDescription + "\r\n" + effectFactory.GetFactory(mainTableDice.Roll()).Get();
		}
	}
}
