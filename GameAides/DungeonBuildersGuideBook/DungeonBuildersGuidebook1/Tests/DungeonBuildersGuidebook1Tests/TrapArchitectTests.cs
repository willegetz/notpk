﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RJK.CSharp.CustomLists;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Threading;
using System.Xml.Linq;
using DungeonBuildersGuidebook1;

namespace DungeonBuildersGuidebook1Tests
{
	[TestClass]
	[UseReporter(typeof(DiffReporter))]
	public class TrapArchitectTests
	{
		// Part 1:
		// Generate a random number from 1 to 100
		// Submit the number to retrieve a Trap Basic
		// Check if the Trap Basic can be either mechanical or magical
		// 		Randomly determine if it is mechanical or magical
		   
		// The user will be allowed to input a value instead of generating one randomly
		// The user will be allowed to re-roll if they do not like their result
		// The user should also be allowed to pick their Trap Basic

		[TestMethod]
		public void TestFirstTrap()
		{
			int objectIndex = 40;
			int result = 60;
			
			var trapArchitect = new FakeTrapArchitect();
			var trapBase = trapArchitect.FakeGetRandomTrapBase(objectIndex);
			var mechanism = trapArchitect.FakegetMechanismType(trapBase, result);

			var firstTrap = new StringBuilder();
			if (string.IsNullOrEmpty(mechanism))
			{
				firstTrap.Append(trapBase.TrappedObjectOrArea);
			}
			else
			{
				firstTrap.Append(string.Format("{0} ({1})", trapBase.TrappedObjectOrArea, mechanism));
			}

			Approvals.Verify(firstTrap.ToString());
			//There is a human input element
		}

		[TestMethod]
		public void TestReRollTrap()
		{
			var trapArchitect = new FakeTrapArchitect();
			
			int firstTrapBaseRoll = 40;
			int firstMechanismRoll = 60;
			int secondTrapBaseRoll = 82;
			int secondMechanismRoll = 38;

			var firstTrapBase = trapArchitect.FakeGetRandomTrapBase(firstTrapBaseRoll);
			var firstMechanism = trapArchitect.FakegetMechanismType(firstTrapBase, firstMechanismRoll);
			var rerolledMechanism = trapArchitect.FakegetMechanismType(firstTrapBase, secondMechanismRoll);

			var trap = new StringBuilder();
			trap.AppendLine("First Trap");
			if (string.IsNullOrEmpty(firstMechanism))
			{
				trap.AppendLine(firstTrapBase.TrappedObjectOrArea);
			}
			else
			{
				trap.AppendLine(string.Format("{0} ({1})", firstTrapBase.TrappedObjectOrArea, firstMechanism));
			}

			trap.AppendLine();
			trap.AppendLine("Mechanism Change");
			trap.AppendLine(string.Format("{0} ({1})", firstTrapBase.TrappedObjectOrArea, rerolledMechanism));

			trap.AppendLine();
			trap.AppendLine("Second Trap");

			var secondTrapBase = trapArchitect.FakeGetRandomTrapBase(secondTrapBaseRoll);
			var secondMechanism = trapArchitect.FakegetMechanismType(secondTrapBase, secondMechanismRoll);

			if (string.IsNullOrEmpty(secondMechanism))
			{
				trap.AppendLine(secondTrapBase.TrappedObjectOrArea);
			}
			else
			{
				trap.AppendLine(string.Format("{0} ({1})", secondTrapBase.TrappedObjectOrArea, secondMechanism));
			}

			Approvals.Verify(trap.ToString());

		}

		[TestMethod]
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
																		EffectRollRequired = bool.Parse(p.Element("EffectRollRequired").Value),
																		EffectDiceToRoll = p.Elements("EffectDiceToRoll").Select(e => e.Value).ToList(),
																	}
															);
			var blah = 4;
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
			return base.trapBaseLogic.GetRandomTrapBase(objectIndex);
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