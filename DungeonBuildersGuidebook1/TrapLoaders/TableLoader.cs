﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RpgTools.Dice;
using System.Xml.Linq;

namespace DungeonBuildersGuidebook1.TrapLoaders
{
	public class TableLoader
	{
		private string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";
		private XElement trapSubtablesXml;

		public TableLoader()
		{
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
		}
		public DiceCup GetPitTrapTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("PitContents").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));
		}

	}

}

