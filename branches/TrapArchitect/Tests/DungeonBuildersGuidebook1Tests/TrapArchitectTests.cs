﻿using System.Collections.Generic;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using DungeonBuildersGuidebook1;
using RpgTools.Dice;
using System;
using NUnit.Framework;

namespace DungeonBuildersGuidebook1Tests
{
	[TestFixture]
	[UseReporter(typeof(DiffReporter))]
	public class TrapArchitectTests
	{
		// The user should also be allowed to pick their Trap Basic
		//		Some form of display to pick from

		[Test]
		public void RandomEntryTest()
		{
			DiceCup.SetRandom(new Random(4));
			var architect = new TrapArchitect();

			var factoryList = new List<string>();
			var firstList = new List<string>();

			int repeat = 100;

			for (int i = 1; i <= repeat; i++)
			{
				var result = DiceCup.Roll("1d100");
				factoryList.Add(architect.GetSpecificTrapEffect1(result));
			}

			Approvals.VerifyAll(factoryList, "List");
		}

		[Test]
		public void RandomFactoryTest()
		{
			DiceCup.SetRandom(new Random(100));

			var architect = new TrapArchitect();
			var effectList = new List<string>();
			int repeat = 100;
			for (int i = 0; i < repeat; i++)
			{
				effectList.Add(architect.GetTrapEffectFactory());
			}

			Approvals.VerifyAll(effectList, "Traps");
		}

		[Test]
		public void RandomTrapConstructionTest()
		{
			DiceCup.SetRandom(new Random(200));

			var architect = new TrapArchitect();
			var traps = new List<string>();
			var iterator = 100;
			for (int i = 0; i < iterator; i++)
			{
				var sb = new StringBuilder();
				sb.AppendLine(architect.GetTrapBaseFactory());
				sb.AppendLine(architect.GetTrapEffectFactory());
				sb.AppendLine(architect.GetTrapDamageFactory());
				traps.Add(sb.ToString());
			}

			Approvals.VerifyAll(traps, "Traps");
		}

		[Test]
		public void TrapObjectTest()
		{
			DiceCup.SetRandom(new Random(300));
			var architect = new TrapArchitect();
			var traps = new List<Trap>();

			var iterator = 100;
			for (int i = 0; i < iterator; i++)
			{
				traps.Add(architect.GetTrap());
			}

			Approvals.VerifyAll(traps, "Trap");
		}
	}
}
