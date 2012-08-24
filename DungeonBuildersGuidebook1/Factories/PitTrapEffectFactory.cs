using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class PitTrapEffectFactory : ISpecificTrapFactory
	{
		private readonly TrapEffectFactory pitContentEffectFactory;
		private readonly DiceCup pitTrapTableDie;
		private readonly string pitTrapContents;

		public PitTrapEffectFactory(TrapEffectFactory pitContentEffectFactory, DiceCup pitTrapTableDie, string pitTrapContents)
		{
			this.pitContentEffectFactory = pitContentEffectFactory;
			this.pitTrapTableDie = pitTrapTableDie;
			this.pitTrapContents = pitTrapContents;
		}
		public string Get()
		{
			return pitTrapContents + " " + pitContentEffectFactory.GetFactory(pitTrapTableDie.Roll()).Get()	;
		}
	}
}
