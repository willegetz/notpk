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
		private IEnumerable<TrapEffects> trapEffects;
		private RangeDictionary<int, TrapEffects> trapEffectsTable;
		private DiceDefinition diceDefinition;
		private string tableDieRoll;
		private int minimumBounds;
		private int maximumBounds;
		private string xmlTrapEffectsFilePath = @"..\..\..\..\DungeonBuildersGuidebook1\DataFiles\TrapEffectsAndTraits.xml";

		public TrapEffectLogic()
		{
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapEffectsTable = new RangeDictionary<int, TrapEffects>();
			LoadTrapEffects();
			diceDefinition = DiceDefinition.Parse(tableDieRoll);
		}

		private void LoadTrapEffects()
		{
			try
			{
				tableDieRoll = trapEffectsXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single();

				trapEffects = trapEffectsXml.Descendants("Effect").Select(tE => new TrapEffects()
																				{
																					RollUpperBound = int.Parse(tE.Element("RollUpperBound").Value),
																					EffectDescription = tE.Element("EffectDescription").Value,
																					AdditionalInformation = ValidateElement(tE.Element("AdditionalInformation").Value),
																					RollAgain = bool.Parse(tE.Element("RollAgain").Value),
																					NumberOfReRolls = ValidateIntElement(tE.Element("NumberOfReRolls").Value),
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
		
		public IEnumerable<TrapEffects> GetRandomTrapEffect()
		{
			var effects = new List<TrapEffects>();
			effects.Add(trapEffectsTable[DiceCup.Roll(tableDieRoll)]);
			effects.AddRange(CheckForMultipleRolls(effects));
			return effects;
		}

		public IEnumerable<TrapEffects> GetSpecificTrapEffect(int specificResult)
		{
			var effects = new List<TrapEffects>();
			if (WithinBounds(specificResult))
			{
				effects.Add(trapEffectsTable[specificResult]);
				effects.AddRange(CheckForMultipleRolls(effects));
				return effects;
			}
			else
			{
				return new List<TrapEffects> {new NullTrapEffect(specificResult, minimumBounds, maximumBounds)};
			}
		}
	}
}
