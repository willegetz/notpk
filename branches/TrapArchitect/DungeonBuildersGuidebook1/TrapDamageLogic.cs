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
		private const string tableDieRoll = "3d6";
		private XElement trapDamagesXml;
		private IEnumerable<TrapDamages> trapDamages;
		private RangeDictionary<int, TrapDamages> trapDamagesTable;
		private string xmlTrapDamagesFilePath = @"..\..\..\..\DungeonBuildersGuidebook1\DataFiles\TrapDamages.xml";

		public TrapDamageLogic()
		{
			trapDamagesXml = XElement.Load(xmlTrapDamagesFilePath);
			trapDamagesTable = new RangeDictionary<int, TrapDamages>();
			LoadTrapDamages();
		}

		private void LoadTrapDamages()
		{
			try
			{
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

		public TrapDamages GetRandomTrapDamage()
		{
			return trapDamagesTable[DiceCup.Roll(tableDieRoll)];
		}

		public TrapDamages GetSpecificTrapDamage(int specificResult)
		{
			return trapDamagesTable[specificResult];
		}
	}
}
