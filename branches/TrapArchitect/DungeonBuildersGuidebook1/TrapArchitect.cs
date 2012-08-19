using System;
using DungeonBuildersGuidebook1.TrapComponentLogic;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		protected TrapBaseLogic trapBaseLogic;
		protected TrapEffectLogic trapEffectLogic;
		protected TrapDamageLogic trapDamageLogic;

		public TrapArchitect()
		{
			SetRandomNumber();
			DiceCup.SetRandom(randomNumber);
			trapBaseLogic = new TrapBaseLogic();
			trapEffectLogic = new TrapEffectLogic();
			trapDamageLogic = new TrapDamageLogic();
		}

		public void SetRandomNumber()
		{
			randomNumber = new Random((int)DateTime.UtcNow.Ticks);
		}

		public TrapBases GetRandomTrapBase()
		{
			return trapBaseLogic.GetRandomTrapBase();
		}


		public TrapBases GetSpecificTrapBase(int specificResult)
		{
			//TODO Add check to validate range.
			return trapBaseLogic.GetSpecificTrapBase(specificResult);
		}

		public TrapEffects GetRandomTrapEffect()
		{
			return trapEffectLogic.GetRandomTrapEffect();
		}

		public TrapEffects GetSpecificTrapEffect(int specificResult)
		{
			//TODO Add check to validate range.
			return trapEffectLogic.GetSpecificTrapEffect(specificResult);
		}

		public TrapDamages GetRandomTrapDamage()
		{
			return trapDamageLogic.GetRandomTrapDamage();
		}

		public TrapDamages GetSpecificTrapDamage(int specificResult)
		{
			//TODO Add check to validate range.
			return trapDamageLogic.GetSpecificTrapDamage(specificResult);
		}
	}
}
