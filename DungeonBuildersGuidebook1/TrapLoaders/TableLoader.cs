using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgTools.Dice;
using System.Xml.Linq;
using DungeonBuildersGuidebook1.TrapComponentObjects;

namespace DungeonBuildersGuidebook1.TrapLoaders
{
	public class TableLoader
	{
		private string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";
		private string xmlTrapDamagesFilePath = DataConstants.DataFilesPath + "TrapDamages.xml";

		private XElement trapSubtablesXml;
		private XElement trapDamageXml;

		public TableLoader()
		{
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
			trapDamageXml = XElement.Load(xmlTrapDamagesFilePath);
		}

		public DiceCup GetPitTrapTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("PitContents").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));
		}

		public IEnumerable<PitContents> GetPitTrapContents()
		{
			return trapSubtablesXml.Descendants("ContentType").Select(pC => new PitContents()
																		{
																			RollUpperBound = int.Parse(pC.Element("RollUpperBound").Value),
																			PitContent = pC.Element("ContentName").Value,
																		}
																	).OrderBy(r => r.RollUpperBound);
		}


		public DiceCup GetGasTrapTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("GasTrap").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));
		}

		public IEnumerable<GasTypes> GetGasTrpContents()
		{
			return trapSubtablesXml.Descendants("GasType").Select(gT => new GasTypes()
																	{
																		RollUpperBound = int.Parse(gT.Element("RollUpperBound").Value),
																		GasName = gT.Element("GasName").Value,
																	}
																).OrderBy(r => r.RollUpperBound);
		}

		public DiceCup GetTrapDamageTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapDamageXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
		}
	}

}

