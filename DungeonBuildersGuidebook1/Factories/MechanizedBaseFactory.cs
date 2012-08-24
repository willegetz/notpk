using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	class MechanizedBaseFactory : ISpecificTrapFactory
	{
		private readonly TrapEffectFactory mechanismFactory;
		private readonly DiceCup mechanismTableDie;
		private readonly string effectDescription;

		public MechanizedBaseFactory(TrapEffectFactory mechanismFactory, DiceCup mechanismTableDie, string effectDescription)
		{
			this.mechanismFactory = mechanismFactory;
			this.mechanismTableDie = mechanismTableDie;
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			var mechanism = mechanismFactory.GetFactory(mechanismTableDie.Roll()).Get();
			return string.Format("{0} ({1})", effectDescription, mechanism);
		}
	}
}
