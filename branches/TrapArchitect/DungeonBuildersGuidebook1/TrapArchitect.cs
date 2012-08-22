using System;
using DungeonBuildersGuidebook1.TrapComponentLogic;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RpgTools.Dice;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RJK.CSharp.CustomLists.RangeDictionary;
using DungeonBuildersGuidebook1.Factories;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		protected TrapBaseLogic trapBaseLogic;
		protected TrapEffectLogic trapEffectLogic;
		protected TrapDamageLogic trapDamageLogic;

		private XElement trapEffectsXml;
		private IEnumerable<TrapEffects> trapEffects;
		private string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private RangeDictionary<int, TrapEffects> trapEffectsTable;
		private RangeDictionary<int, SpecificTrapFactory> trapEffectsTable1;
		private SimpleTrapEffectFactory simpleEffectFactory;

		public TrapArchitect()
		{
			//SetRandomNumber();
			//DiceCup.SetRandom(randomNumber);

			LoadTable();

			simpleEffectFactory = new SimpleTrapEffectFactory(trapEffectsTable1);

			trapBaseLogic = new TrapBaseLogic();
			trapEffectLogic = new TrapEffectLogic();
			trapDamageLogic = new TrapDamageLogic();
		}

		public void SetRandomNumber()
		{
			randomNumber = new Random((int)DateTime.UtcNow.Ticks);
		}

		public TrapBases GetRandomTrapBase()
		{
			return trapBaseLogic.GetRandomTrapBase();
		}

		public IEnumerable<TrapEffects> GetRandomTrapEffect()
		{
			return trapEffectLogic.GetRandomTrapEffect();
		}

		public TrapDamages GetRandomTrapDamage()
		{
			return trapDamageLogic.GetRandomTrapDamage();
		}

		public TrapBases GetSpecificTrapBase(int specificResult)
		{
			return trapBaseLogic.GetSpecificTrapBase(specificResult);
		}

		public IEnumerable<TrapEffects> GetSpecificTrapEffect(int specificResult)
		{
			return trapEffectLogic.GetSpecificTrapEffect(specificResult);
		}

		public TrapDamages GetSpecificTrapDamage(int specificResult)
		{
			return trapDamageLogic.GetSpecificTrapDamage(specificResult);
		}

		public string GetSpecificSubtableEffect(string subtable, int subtableRoll)
		{
			return trapEffectLogic.GetSpecificSubtableEffect(subtable, subtableRoll);
		}

		public string GetSpecificTrapEffect1(int specificResult)
		{
				return simpleEffectFactory.GetFactory(specificResult).Get();
		}

		private void LoadTable()
		{
			trapEffectsTable = new RangeDictionary<int, TrapEffects>();
			trapEffectsTable1 = new RangeDictionary<int, SpecificTrapFactory>();
			// TODO add another dictionary

			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			try
			{
				trapEffects = new List<TrapEffects>();
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
					trapEffectsTable1.Add(trapEffect.RollUpperBound, new SpecificTrapFactory(trapEffect.EffectDescription));
				}
			}
			catch (Exception ex)
			{

				throw;
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
	}
}
