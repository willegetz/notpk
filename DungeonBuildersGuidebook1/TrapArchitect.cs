﻿using System;
using DungeonBuildersGuidebook1.TrapComponentLogic;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RpgTools.Dice;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RJK.CSharp.CustomLists.RangeDictionary;
using DungeonBuildersGuidebook1.Factories;
using RpgTools.Dice.Extensions;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		protected TrapBaseLogic trapBaseLogic;
		protected TrapEffectLogic trapEffectLogic;
		protected TrapDamageLogic trapDamageLogic;

		private XElement trapEffectsXml;
		private XElement trapSubtablesXml;
		private IEnumerable<PitContents> pitContents;
		private IEnumerable<TrapEffects> trapEffects;
		private string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";
		private TrapEffectFactory effectFactory;
		private TrapEffectFactory pitContentEffectFactory;
		private DiceCup effectPrimaryTableDie;
		private DiceCup pitTrapTableDie;

		public TrapArchitect()
		{
			effectFactory = new TrapEffectFactory();
			pitContentEffectFactory = new TrapEffectFactory();

			LoadTables();
			

			
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
				return effectFactory.GetFactory(specificResult).Get();
		}

		public string GetTrapEffectFactory()
		{
			return effectFactory.GetFactory(effectPrimaryTableDie.Roll()).Get();
		}

		private void LoadTables()
		{
			// TODO add another dictionary

			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
			try
			{
				effectPrimaryTableDie = new DiceCup(DiceDefinition.Parse(trapEffectsXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));

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

				pitTrapTableDie = new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("PitContents").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));

				pitContents = new List<PitContents>();
				pitContents = trapSubtablesXml.Descendants("ContentType").Select(pC => new PitContents()
																							{
																								RollUpperBound = int.Parse(pC.Element("RollUpperBound").Value),
																								PitContent = pC.Element("ContentName").Value,
																							}
																		).OrderBy(r => r.RollUpperBound);

				foreach (var content in pitContents)
				{
					pitContentEffectFactory.Add(content.RollUpperBound, new SpecificTrapFactory(content.PitContent));
				}


				foreach (var trapEffect in trapEffects)
				{
					if (trapEffect.RollAgain)
					{
						effectFactory.Add(trapEffect.RollUpperBound, new ComplexTrapEffectFactory(effectFactory, effectPrimaryTableDie, trapEffect.EffectDescription));
					}
					else if (trapEffect.HasSubtable && trapEffect.SubtableName == "PitContents")
					{
						effectFactory.Add(trapEffect.RollUpperBound, new PitTrapEffectFactory(pitContentEffectFactory, pitTrapTableDie, trapEffect.EffectDescription));
					}
					else
					{
						effectFactory.Add(trapEffect.RollUpperBound, new SpecificTrapFactory(trapEffect.EffectDescription));
					}
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
