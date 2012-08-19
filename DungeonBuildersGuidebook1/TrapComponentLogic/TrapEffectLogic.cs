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
		private const string tableDieRoll = "1d100";
		private XElement trapEffectsXml;
		private IEnumerable<TrapEffects> trapEffects;
		private RangeDictionary<int, TrapEffects> trapEffectsTable;
		private string xmlTrapEffectsFilePath = @"..\..\..\..\DungeonBuildersGuidebook1\DataFiles\TrapEffectsAndTraits.xml";

		public TrapEffectLogic()
		{
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapEffectsTable = new RangeDictionary<int, TrapEffects>();
			LoadTrapEffects();
		}

		private void LoadTrapEffects()
		{
			try
			{
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

		public TrapEffects GetRandomTrapEffect()
		{
			return trapEffectsTable[DiceCup.Roll(tableDieRoll)];
		}

		public TrapEffects GetSpecificTrapEffect(int specificResult)
		{
			return trapEffectsTable[specificResult];
		}
	}
}
