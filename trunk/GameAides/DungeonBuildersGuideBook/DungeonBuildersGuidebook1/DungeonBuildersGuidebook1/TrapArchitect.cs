﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		protected TrapBaseLogic trapBaseLogic;
		protected TrapEffectLogic trapEffectLogic;

		private List<string> eitherMagicalOrMechanical { get; set; }

		public TrapArchitect()
		{
			trapBaseLogic = new TrapBaseLogic();
			trapEffectLogic = new TrapEffectLogic();
			eitherMagicalOrMechanical = new List<string>();
			eitherMagicalOrMechanical.AddRange(TrapBasicsTable10a.GetMagicalOrMechanicalList());
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
	}
}
