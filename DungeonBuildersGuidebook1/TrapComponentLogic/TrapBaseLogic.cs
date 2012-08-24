using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RJK.CSharp.CustomLists.RangeDictionary;
using System.Windows.Forms;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.TrapComponentLogic
{
	public class TrapBaseLogic
	{
		private readonly XElement trapBasesXml;
		private IEnumerable<TrapBases> trapBases;
		private readonly RangeDictionary<int, TrapBases> trapBasesTable;
		private readonly DiceDefinition diceDefinition;
		private string tableDieRoll;
		private int minimumBounds;
		private int maximumBounds;
		private readonly string xmlTrapComponentsFilePath = DataConstants.DataFilesPath + "TrapComponents.xml";

		public TrapBaseLogic()
		{
			trapBasesXml = XElement.Load(xmlTrapComponentsFilePath);
			trapBasesTable = new RangeDictionary<int, TrapBases>();
			LoadTrappedObjecs();
			diceDefinition = DiceDefinition.Parse(tableDieRoll);
		}

		private void LoadTrappedObjecs()
		{
			try
			{
				tableDieRoll = trapBasesXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single();

				trapBases = trapBasesXml.Descendants("TrapBase").Select(tB => new TrapBases()
																			{
																				RollUpperBound = int.Parse(tB.Element("RollUpperBound").Value),
																				TrappedObjectOrArea = tB.Element("TrappedObjectOrArea").Value,
																				MechanismTypeSpecified = bool.Parse(tB.Element("MechanismTypeSpecified").Value)
																			}
																		)
																.OrderBy(r => r.RollUpperBound);

				foreach (var trapBase in trapBases)
				{
					trapBasesTable.Add(trapBase.RollUpperBound, trapBase);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("An error occurred when trying to read in '{0}'\r\n{1}", xmlTrapComponentsFilePath, ex.ToString()), "A XML Read Error Occurred");
			}
		}

		private bool WithinBounds(int specificResult)
		{
			minimumBounds = diceDefinition.NumberOfDice;
			maximumBounds = (diceDefinition.NumberOfDice * diceDefinition.NumberOfSides);

			if (specificResult >= minimumBounds && specificResult <= maximumBounds)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public TrapBases GetRandomTrapBase()
		{
			var trapBase = trapBasesTable[DiceCup.Roll(tableDieRoll)];
			trapBase.MechanismType = DetermineMechanismType(trapBase);
			return trapBase;
		}

		public TrapBases GetSpecificTrapBase(int specificResult)
		{
			if (WithinBounds(specificResult))
			{
				var trapBase = trapBasesTable[specificResult];
				trapBase.MechanismType = DetermineMechanismType(trapBase);
				return trapBase;
			}
			else
			{
				return new NullTrapBase(specificResult, minimumBounds, maximumBounds);
			}

		}

		public string DetermineMechanismType(TrapBases trapBase)
		{
			if (trapBase.MechanismTypeSpecified)
			{
				return DiceCup.Roll(tableDieRoll) > 50 ? " (magical)" : " (mechanical)";
			}
			else
			{
				return string.Empty;
			}
		}

	}
}
