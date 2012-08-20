using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Xml.Linq;
using DungeonBuildersGuidebook1;
using RpgTools.Dice;
using DungeonBuildersGuidebook1.TrapComponentObjects;

namespace DungeonBuildersGuidebook1Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class TrapArchitectTests
	{
		// The user should also be allowed to pick their Trap Basic
		//		Some form of display to pick from

		[TestMethod]
		[Ignore] // Test 
		public void TestGenerateRandomTrapsTest()
		{
			var architect = new TrapArchitect();
			var traps = new List<TheTrap>();

			var numberOfTraps = 100;
			for (int i = 1; i <= numberOfTraps; i++)
			{
				var theTrap = new TheTrap();

				theTrap.SetTrapBase(architect.GetRandomTrapBase());
				theTrap.SetTrapEffect(architect.GetRandomTrapEffect());
				theTrap.SetTrapDamage(architect.GetRandomTrapDamage());
				traps.Add(theTrap);
			}

			var sb = new StringBuilder();
			foreach (var trap in traps)
			{
				sb.AppendLine(trap.ToString());
				sb.AppendLine();
			}
			Approvals.VerifyAll(traps, "Traps");
		}

		[TestMethod]
		public void GetSpecificTrapsTest()
		{
			var architect = new TrapArchitect();
			var traps = new List<TheTrap>();
			
			int tableMax = 100;

			var trapDiceRolls = new List<int>();
			for (int i = 1; i < tableMax; i += 2)
			{
				trapDiceRolls.Add(i);
			}

			var damageDiceRolls = new List<int>();
			var damageResult = 3;
			for (int i = 0; i < trapDiceRolls.Count; i++)
			{
				if (damageResult <= 18)
				{
					damageDiceRolls.Add(damageResult);
					damageResult++;
				}
				else
				{
					damageResult = 3;
					damageDiceRolls.Add(damageResult);
					damageResult++;
				}
			}

			for (int i = 0; i < trapDiceRolls.Count; i++)
			{
				var theTrap = new TheTrap();
				theTrap.SetTrapBase(architect.GetSpecificTrapBase(trapDiceRolls[i]));
				theTrap.ChangeMechanismType("magical");
				theTrap.SetTrapEffect(architect.GetSpecificTrapEffect(trapDiceRolls[i]));
				theTrap.SetTrapDamage(architect.GetSpecificTrapDamage(damageDiceRolls[i]));
				traps.Add(theTrap);
			}

			Approvals.VerifyAll(traps, "Traps");
		}

		[TestMethod]
		public void RerollTrapTest()
		{
			var architect = new TrapArchitect();
			var trap = new TheTrap();
			var sb = new StringBuilder();

			int firstTrapBase = 2;
			int firstTrapEffect = 24;
			int firstDamageEffect = 10;

			trap.SetTrapBase(architect.GetSpecificTrapBase(firstTrapBase));
			trap.SetTrapEffect(architect.GetSpecificTrapEffect(firstTrapEffect));
			trap.SetTrapDamage(architect.GetSpecificTrapDamage(firstDamageEffect));

			sb.AppendLine("Initial Trap");
			sb.AppendLine(trap.ToString());
			sb.AppendLine();

			int rerollTrapBase = 67;
			int rerollTrapEffect = 84;
			int indexOfEffectToChange = 0;
			trap.SetTrapBase(architect.GetSpecificTrapBase(rerollTrapBase));
			trap.ChangeAnEffect(indexOfEffectToChange, architect.GetSpecificTrapEffect(rerollTrapEffect));
			
			sb.AppendLine("New Trap Base");
			sb.AppendLine(trap.ToString());
			
			Approvals.Verify(sb.ToString());
		}

		[TestMethod]
		[Ignore] // Experiment workspace
		public void TrapEffectsTest()
		{
			// A trap effect has at minimum an effect name and an upper bound on the range
			// A trap effect may have additional rolls 
			//	These rolls will be for random values defined by the trap effect
			// A trap effect may require the consultation of another table
			//	These consultations will be performed on tables that are named
			//		These tables handle their own information
			var filePath = @"..\..\..\..\DungeonBuildersGuidebook1\DataFiles\TrapEffectsAndTraits.xml";
			var root = XElement.Load(filePath);

			var effects = root.Descendants("Effect").Select(p => new TrapEffects()
																	{
																		RollUpperBound = int.Parse(p.Element("RollUpperBound").Value),
																		EffectDescription = p.Element("EffectDescription").Value,
																		//EffectRollRequired = bool.Parse(p.Element("EffectRollRequired").Value),
																		//EffectDiceToRoll = p.Elements("EffectDiceToRoll").Select(e => e.Value).ToList(),
																	}
															);

			var sb = new StringBuilder();
			var results = new List<int>();
			//foreach (var item in effects.Where(r => r.RollAgain))
			//{
			//    foreach (var die in item.EffectDiceToRoll)
			//    {
			//        var bag = new DiceCup(DiceDefinition.Parse(die));
			//        results.Add(bag.Roll());
			//    }

			//    var blah = string.Format(item.EffectDescription, results[0]);

			//    item.EffectDescription = blah;
			//}

			foreach (var item in effects)
			{
				sb.AppendLine(item.EffectDescription);
			}
			Approvals.Verify(sb.ToString());
		}

		[TestMethod]
		public void TestLoadXmlElement()
		{
			var trapArchitect = new TrapArchitect();
			var filePath = @"..\..\..\data.xml";

			var root = XElement.Load(filePath);
			var blah = root.Descendants("Data").Select(p => new FakeProduct()
												{
													Category = p.Element("Category").Value,
													Quantity = int.Parse(p.Element("Quantity").Value),
													Price = double.Parse(p.Element("Price").Value),
												}
									);

			var blah3 = blah.Where(c => c.Category == "A");


			var sb = new StringBuilder();
			foreach (var item in blah)
			{
				sb.AppendLine(item.ToString());
			}

			sb.AppendLine();

			sb.AppendLine("The items from Category A");
			foreach (var item in blah3)
			{
				sb.AppendLine(item.ToString());
			}
			
			IEnumerable<decimal> prices1 =
				from el in root.Elements("Data")
				let price = (decimal)el.Element("Price")
				orderby price
				select price;
			foreach (decimal el in prices1) ;

			Approvals.Verify(sb.ToString());
		}
	}

	class FakeTrapArchitect : TrapArchitect
	{
		public TrapBases FakeGetRandomTrapBase(int objectIndex)
		{
			return base.trapBaseLogic.GetRandomTrapBase();
		}

		public string FakegetMechanismType(TrapBases trapBase, int result)
		{
			if (trapBase.MechanismTypeSpecified)
			{
				return result > 50 ? "magical" : "mechanical";
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
