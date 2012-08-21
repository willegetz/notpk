using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RJK.CSharp.CustomLists.RangeDictionary;
using System.Windows.Forms;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.TrapComponentLogic
{
	public class TrapDamageLogic
	{
		private XElement trapDamagesXml;
		private IEnumerable<TrapDamages> trapDamages;
		private RangeDictionary<int, TrapDamages> trapDamagesTable;
		private DiceDefinition diceDefinition;
		private string tableDieRoll;
		private int minimumBounds;
		private int maximumBounds;
		private string xmlTrapDamagesFilePath = DataConstants.DataFilesPath + "TrapDamages.xml";

		public TrapDamageLogic()
		{
			trapDamagesXml = XElement.Load(xmlTrapDamagesFilePath);
			trapDamagesTable = new RangeDictionary<int, TrapDamages>();
			LoadTrapDamages();
			diceDefinition = DiceDefinition.Parse(tableDieRoll);
		}

		private void LoadTrapDamages()
		{
			try
			{
				tableDieRoll = trapDamagesXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single();

				trapDamages = trapDamagesXml.Descendants("Damage").Select(tD => new TrapDamages()
																			{
																				RollUpperBound = int.Parse(tD.Element("RollUpperBound").Value),
																				DamageDescription = tD.Element("DamageDescription").Value,
																			}
																		)
																.OrderBy(r => r.RollUpperBound);

				foreach (var trapDamage in trapDamages)
				{
					trapDamagesTable.Add(trapDamage.RollUpperBound, trapDamage);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("An error occurred when trying to read in '{0}'\r\n{1}", xmlTrapDamagesFilePath, ex.ToString()), "A XML Read Error Occurred");
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

		public TrapDamages GetRandomTrapDamage()
		{
			return trapDamagesTable[DiceCup.Roll(tableDieRoll)];
		}

		public TrapDamages GetSpecificTrapDamage(int specificResult)
		{
			if (WithinBounds(specificResult))
			{
				return trapDamagesTable[specificResult];
			}
			else
			{
				return new NullTrapDamage(specificResult, minimumBounds, maximumBounds);
			}
		}
	}
}
