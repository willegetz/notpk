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
		private readonly string xmlTrapComponentsFilePath = DataConstants.DataFilesPath + "TrapComponents.xml";
		private readonly string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private readonly string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";
		private readonly string xmlTrapDamagesFilePath = DataConstants.DataFilesPath + "TrapDamages.xml";

		private static XElement trapBasesXml;
		private static XElement trapEffectsXml;
		private static XElement trapSubtablesXml;
		private static XElement trapDamageXml;

		public TableLoader()
		{
			trapBasesXml = XElement.Load(xmlTrapComponentsFilePath);
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
			trapDamageXml = XElement.Load(xmlTrapDamagesFilePath);
		}

		public static DiceCup GetTrapBaseTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapBasesXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
		}

		public static IEnumerable<TrapBases> GetTrapBaseContents()
		{
			return trapBasesXml.Descendants("TrapBase").Select(tB => new TrapBases()
																{
																	RollUpperBound = int.Parse(tB.Element("RollUpperBound").Value),
																	TrappedObjectOrArea = tB.Element("TrappedObjectOrArea").Value,
																	MechanismTypeSpecified = bool.Parse(tB.Element("MechanismTypeSpecified").Value)
																}
															).OrderBy(r => r.RollUpperBound);
		}

		public static DiceCup GetTrapMechanismTableDie()
		{
		   return new DiceCup(DiceDefinition.Parse(trapBasesXml.Descendants("MechanismDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
		}

		public static List<KeyValuePair<int, string>> GetTrapMechanismContents()
		{
		  return trapBasesXml.Descendants("Mechanism").ToDictionary(m => int.Parse(m.Element("RollUpperBound").Value), m => m.Element("MechanismType").Value).ToList();
		}

		public static DiceCup GetTrapEffectsTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapEffectsXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
		}

		public static IEnumerable<TrapEffects> GetTrapEffectsContents()
		{
			return trapEffectsXml.Descendants("Effect").Select(tE => new TrapEffects()
																{
																	RollUpperBound = int.Parse(tE.Element("RollUpperBound").Value),
																	EffectDescription = tE.Element("EffectDescription").Value,
																	AdditionalInformation = ValidateElement(tE.Element("AdditionalInformation").Value),
																	RollAgain = bool.Parse(tE.Element("RollAgain").Value),
																	NumberOfReRolls = ValidateIntElement(tE.Element("NumberOfReRolls").Value),
																	HasSubtable = bool.Parse(tE.Element("HasSubtable").Value),
																	SubtableName = tE.Element("SubtableName").Value,
																}
															).OrderBy(r => r.RollUpperBound);
		}

		public static DiceCup GetPitTrapTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("PitContents").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));
		}

		public static IEnumerable<PitContents> GetPitTrapContents()
		{
			return trapSubtablesXml.Descendants("ContentType").Select(pC => new PitContents()
																		{
																			RollUpperBound = int.Parse(pC.Element("RollUpperBound").Value),
																			PitContent = pC.Element("ContentName").Value,
																		}
																	).OrderBy(r => r.RollUpperBound);
		}


		public static DiceCup GetGasTrapTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("GasTrap").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));
		}

		public static IEnumerable<GasTypes> GetGasTrpContents()
		{
			return trapSubtablesXml.Descendants("GasType").Select(gT => new GasTypes()
																	{
																		RollUpperBound = int.Parse(gT.Element("RollUpperBound").Value),
																		GasName = gT.Element("GasName").Value,
																	}
																).OrderBy(r => r.RollUpperBound);
		}

		public static DiceCup GetTrapDamageTableDie()
		{
			return new DiceCup(DiceDefinition.Parse(trapDamageXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
		}

		public static IEnumerable<TrapDamages> GetTrapDamages()
		{
			return trapDamageXml.Descendants("Damage").Select(tD => new TrapDamages()
																	{
																		RollUpperBound = int.Parse(tD.Element("RollUpperBound").Value),
																		DamageDescription = tD.Element("DamageDescription").Value,
																	}
																).OrderBy(r => r.RollUpperBound);
		}


		private static int ValidateIntElement(string intElementValue)
		{
			if (string.IsNullOrEmpty(intElementValue))
			{
				return 0;
			}
			else
			{
				return int.Parse(intElementValue);
			}
		}

		private static string ValidateElement(string elementValue)
		{
			if (string.IsNullOrEmpty(elementValue))
			{
				return string.Empty;
			}
			else
			{
				return elementValue;
			}
		}
	}

}

