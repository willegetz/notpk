using System.Collections.Generic;
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
		public void SpeceficTrapTest()
		{
			DiceCup.SetRandom(new Random(4));
			var architect = new TrapArchitect();

			var trapBase = architect.GetSpecificTrapBase(15);
			var trapEffect = architect.GetSpecificTrapEffect(33);
			var trapDamage = architect.GetSpecificTrapDamage(8);
			var trap = new Trap(trapBase, trapEffect, trapDamage);

			Approvals.Verify(trap);
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

		[Test]
		public void PitTrapTest()
		{
			DiceCup.SetRandom(new Random(400));
			var architect = new TrapArchitect();
			var traps = new List<Trap>();

			var floodAreaKey = 36; // Flood area uses the pit trap subtable
			var pitTrapOpenKey = 89;
			var pitTrapTumbleKey = 94;

			var iterator = 33;
			for (int i = 0; i < iterator; i++)
			{

				var floodTrapBase = architect.GetTrapBaseFactory();
				var floodTrapEffect = architect.GetSpecificTrapEffect(floodAreaKey);
				var floodTrapDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(floodTrapBase, floodTrapEffect, floodTrapDamage));

				var pitTrapOpenBase = architect.GetTrapBaseFactory();
				var pitTrapOpenEffect = architect.GetSpecificTrapEffect(pitTrapOpenKey);
				var pitTrapOpenDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(pitTrapOpenBase, pitTrapOpenEffect, pitTrapOpenDamage));

				var pitTrapTumbleBase = architect.GetTrapBaseFactory();
				var pitTrapTumbleEffect = architect.GetSpecificTrapEffect(pitTrapTumbleKey);
				var pitTrapTumbleDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(pitTrapTumbleBase, pitTrapTumbleEffect, pitTrapTumbleDamage));
			}

			Approvals.VerifyAll(traps, "Pit Trap!");
		}

		[Test]
		public void GasTrapTest()
		{
			DiceCup.SetRandom(new Random(500));
			var architect = new TrapArchitect();
			var traps = new List<Trap>();

			var gasTrapKey = 38;
			var iterator = 100;
			for (int i = 0; i < iterator; i++)
			{
				var gasTrapBase = architect.GetTrapBaseFactory();
				var gasTrapEffect = architect.GetSpecificTrapEffect(gasTrapKey);
				var gasTrapDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(gasTrapBase, gasTrapEffect, gasTrapDamage));
			}

			Approvals.VerifyAll(traps, "Gas Trap!");
		}

		[Test]
		public void NestedRollTrapsTest()
		{
			DiceCup.SetRandom(new Random(600));
			var architect = new TrapArchitect();
			var traps = new List<Trap>();

			var riddleTrapKey = 5;
			var lockEntranceKey = 46;
			var lockExitKey = 47;
			var rollTwiceKey = 99;
			var rollThriceKey = 100;

			var iterator = 20;
			for (int i = 0; i < iterator; i++)
			{
				var riddleTrapBase = architect.GetTrapBaseFactory();
				var riddleTrapEffect = architect.GetSpecificTrapEffect(riddleTrapKey);
				var riddleTrapDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(riddleTrapBase, riddleTrapEffect, riddleTrapDamage));

				var lockEntranceBase = architect.GetTrapBaseFactory();
				var lockEntranceEffect = architect.GetSpecificTrapEffect(lockEntranceKey);
				var lockEntranceDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(lockEntranceBase, lockEntranceEffect, lockEntranceDamage));

				var lockExitBase = architect.GetTrapBaseFactory();
				var lockExitEffect = architect.GetSpecificTrapEffect(lockExitKey);
				var lockExitDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(lockExitBase, lockExitEffect, lockExitDamage));

				var rollTwiceBase = architect.GetTrapBaseFactory();
				var rollTwiceEffect = architect.GetSpecificTrapEffect(rollTwiceKey);
				var rollTwiceDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(rollTwiceBase, rollTwiceEffect, rollTwiceDamage));

				var rollThriceBase = architect.GetTrapBaseFactory();
				var rollThriceEffect = architect.GetSpecificTrapEffect(rollThriceKey);
				var rollThriceDamage = architect.GetTrapDamageFactory();
				traps.Add(new Trap(rollThriceBase, rollThriceEffect, rollThriceDamage));
			}

			Approvals.VerifyAll(traps, "Nested Trap!");
		}
	}
}
