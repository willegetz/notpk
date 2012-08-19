using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonBuildersGuidebook1.TrapComponentLogic;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using DungeonBuildersGuidebook1.ConsoleApp;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		protected TrapBaseLogic trapBaseLogic;
		protected TrapEffectLogic trapEffectLogic;

		public TrapArchitect()
		{
			trapBaseLogic = new TrapBaseLogic();
			trapEffectLogic = new TrapEffectLogic();
		}

		public void SetRandomNumber()
		{
			randomNumber = new Random((int)DateTime.UtcNow.Ticks);
		}

		public TrapBases GetRandomTrapBase()
		{
			return trapBaseLogic.GetRandomTrapBase(randomNumber.Next(1, 100));
		}

		public string DetermineMechanicalOrMagical(TrapBases trapBase)
		{
			if (trapBase.MechanismTypeSpecified)
			{
				return randomNumber.Next(1, 100) > 50 ? "magical" : "mechanical";
			}
			else
			{
				return string.Empty;
			}
		}

		public TrapEffects GetRandomTrapEffect()
		{
			return trapEffectLogic.GetRandomTrapEffect(randomNumber.Next(1, 100));
		}
	}
}
