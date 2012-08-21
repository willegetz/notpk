using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RJK.CSharp.CustomLists.RangeDictionary;
using System.Windows.Forms;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.TrapComponentLogic
{
	public class TrapEffectLogic
	{
		private XElement trapEffectsXml;
		private XElement trapSubtablesXml;
		private IEnumerable<TrapEffects> trapEffects;
		private IEnumerable<GasTypes> gasTypes;
		private IEnumerable<PitContents> pitContents;
		private RangeDictionary<int, TrapEffects> trapEffectsTable;
		private RangeDictionary<int, string> gasTrapTable;
		private RangeDictionary<int, string> pitContentsTable;
		private DiceDefinition effectsTableDefinition;
		private DiceDefinition gasTableDefinition;
		private DiceDefinition pitContentDefinition;
		private string effectsTableDieRoll;
		private string gasTableDieRoll;
		private string pitContentTableDieRoll;
		private int minimumBounds;
		private int maximumBounds;
		private string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";

		public TrapEffectLogic()
		{
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
			trapEffectsTable = new RangeDictionary<int, TrapEffects>();
			gasTrapTable = new RangeDictionary<int, string>();
			pitContentsTable = new RangeDictionary<int, string>();
			LoadTrapTables();
			effectsTableDefinition = DiceDefinition.Parse(effectsTableDieRoll);
			gasTableDefinition = DiceDefinition.Parse(gasTableDieRoll);
			pitContentDefinition = DiceDefinition.Parse(pitContentTableDieRoll);
		}

		private void LoadTrapTables()
		{
			try
			{
				effectsTableDieRoll = trapEffectsXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single();

				gasTableDieRoll = trapSubtablesXml.Descendants("GasTrap").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single();

				gasTypes = trapSubtablesXml.Descendants("GasType").Select(gT => new GasTypes()
																				{
																					RollUpperBound = int.Parse(gT.Element("RollUpperBound").Value),
																					GasName = gT.Element("GasName").Value,
																				}
																		  ).OrderBy(r => r.RollUpperBound);

				foreach (var gas in gasTypes)
				{
					gasTrapTable.Add(gas.RollUpperBound, gas.GasName);
				}

				pitContentTableDieRoll = trapSubtablesXml.Descendants("PitContents").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single();

				pitContents = trapSubtablesXml.Descendants("ContentType").Select(pC => new PitContents()
																						{
																							RollUpperBound = int.Parse(pC.Element("RollUpperBound").Value),
																							PitContent = pC.Element("ContentName").Value,
																						}
																		).OrderBy(r => r.RollUpperBound);

				foreach (var content in pitContents)
				{
					pitContentsTable.Add(content.RollUpperBound, content.PitContent);
				}

				trapEffects = trapEffectsXml.Descendants("Effect").Select(tE => new TrapEffects()
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

				foreach (var trapEffect in trapEffects)
				{
					trapEffectsTable.Add(trapEffect.RollUpperBound, trapEffect);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("An error occurred when trying to read in '{0}'\r\n{1}", xmlTrapEffectsFilePath, ex.ToString()), "A XML Read Error Occurred");
			}
		}

		private int ValidateIntElement(string intElementValue)
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

		private string ValidateElement(string elementValue)
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

		private IEnumerable<TrapEffects> CheckForMultipleRolls(IEnumerable<TrapEffects> effects)
		{
			var multipleEffects = new List<TrapEffects>();
			foreach (var effect in effects.Where(e => e.RollAgain))
			{
				for (int i = 0; i < effect.NumberOfReRolls; i++)
				{
					multipleEffects.AddRange(GetRandomTrapEffect());
				}
			}
			return multipleEffects;
		}

		private bool WithinBounds(int specificResult)
		{
			minimumBounds = effectsTableDefinition.NumberOfDice;
			maximumBounds = (effectsTableDefinition.NumberOfDice * effectsTableDefinition.NumberOfSides);

			if (specificResult >= minimumBounds && specificResult <= maximumBounds)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public IEnumerable<TrapEffects> GetRandomTrapEffect()
		{
			var effects = new List<TrapEffects>();
			effects.Add(trapEffectsTable[DiceCup.Roll(effectsTableDieRoll)]);
			effects.AddRange(CheckForMultipleRolls(effects));
			CheckForSubtables(effects);

			return effects;
		}

		public IEnumerable<TrapEffects> GetSpecificTrapEffect(int specificResult)
		{
			var effects = new List<TrapEffects>();
			if (WithinBounds(specificResult))
			{
				effects.Add(trapEffectsTable[specificResult]);
				effects.AddRange(CheckForMultipleRolls(effects));
				CheckForSubtables(effects);
				return effects;
			}
			else
			{
				return new List<TrapEffects> {new NullTrapEffect(specificResult, minimumBounds, maximumBounds)};
			}
		}

		public void CheckForSubtables(IEnumerable<TrapEffects> effects)
		{
			foreach (var effect in effects.Where(e => e.HasSubtable && e.SubtableName.Contains("GasType")))
			{
				effect.SubtableEffectDescription = " " + gasTrapTable[DiceCup.Roll(gasTableDieRoll)];
			}
			foreach (var effect in effects.Where(e => e.HasSubtable && e.SubtableName.Contains("PitContents")))
			{
				effect.SubtableEffectDescription = " full of " + pitContentsTable[DiceCup.Roll(pitContentTableDieRoll)];
			}
		}

		public string GetSpecificSubtableEffect(string subtable, int subtableRoll)
		{
			switch (subtable)
			{
				case "GasType":
					minimumBounds = gasTableDefinition.NumberOfDice;
					maximumBounds = (gasTableDefinition.NumberOfDice * gasTableDefinition.NumberOfSides);
					if (subtableRoll >= minimumBounds && subtableRoll <= maximumBounds)
					{
						return " " + gasTrapTable[subtableRoll];
					}
					else
					{
						return string.Format("{0} is out of bounds of {1} for {2}", subtableRoll, gasTableDieRoll, subtable);
					}
				case "PitContents":
					minimumBounds = pitContentDefinition.NumberOfDice;
					maximumBounds = (pitContentDefinition.NumberOfDice * pitContentDefinition.NumberOfSides);
					if (subtableRoll >= minimumBounds && subtableRoll <= maximumBounds)
					{
						return " full of " + pitContentsTable[subtableRoll];
					}
					else
					{
						return string.Format("{0} is out of bounds of {1} for {2}", subtableRoll, gasTableDieRoll, subtable);
					}
				default:
					return string.Format("{0} is an invalid subtable.", subtable);
			}
		}
	}

	internal class GasTypes
	{
		public int RollUpperBound;
		public string GasName;
	}

	internal class PitContents
	{
		public int RollUpperBound;
		public string PitContent;
	}
}
