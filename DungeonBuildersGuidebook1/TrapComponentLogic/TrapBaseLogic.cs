using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using RJK.CSharp.CustomLists.RangeDictionary;
using System.Windows.Forms;
using DungeonBuildersGuidebook1;
using DungeonBuildersGuidebook1.TrapComponentObjects;

namespace DungeonBuildersGuidebook1.TrapComponentLogic
{
	public class TrapBaseLogic
	{
		private XElement trapBasesXml;
		private IEnumerable<TrapBases> trapBases;
		private RangeDictionary<int, TrapBases> trapBasesTable;
		private string xmlTrapComponentsFilePath = @"..\..\..\..\DungeonBuildersGuidebook1\DataFiles\TrapComponents.xml";

		public TrapBaseLogic()
		{
			trapBasesXml = XElement.Load(xmlTrapComponentsFilePath);
			trapBasesTable = new RangeDictionary<int, TrapBases>();
			LoadTrappedObjecs();
		}

		private void LoadTrappedObjecs()
		{
			try
			{
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

		public TrapBases GetRandomTrapBase(int resultNumber)
		{
			return trapBasesTable[resultNumber];
		}
	}
}
