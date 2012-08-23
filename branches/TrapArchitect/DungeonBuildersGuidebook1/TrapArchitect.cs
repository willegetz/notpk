using System;
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

		private XElement trapBasesXml;
		private XElement trapEffectsXml;
		private XElement trapSubtablesXml;
		private XElement trapDamageXml;
		private IEnumerable<TrapBases> trapBases;
		private IEnumerable<PitContents> pitContents;
		private IEnumerable<TrapEffects> trapEffects;
		private IEnumerable<GasTypes> gasTypes;
		private IEnumerable<TrapDamages> trapDamages;
		private string xmlTrapComponentsFilePath = DataConstants.DataFilesPath + "TrapComponents.xml";
		private string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private string xmlTrapSubtablesFilePath = DataConstants.DataFilesPath + "TrapEffectsSubtables.xml";
		private string xmlTrapDamagesFilePath = DataConstants.DataFilesPath + "TrapDamages.xml";
		private TrapEffectFactory trapBaseFactory;
		private TrapEffectFactory effectFactory;
		private TrapEffectFactory pitContentEffectFactory;
		private TrapEffectFactory gasTrapContentFactory;
		private TrapEffectFactory trapDamagesFactory;
		private DiceCup basePrimaryTableDie;
		private DiceCup effectPrimaryTableDie;
		private DiceCup pitTrapTableDie;
		private DiceCup gasTrapTableDie;
		private DiceCup trapDamageTableDie;

		public TrapArchitect()
		{
			trapBaseFactory = new TrapEffectFactory();
			effectFactory = new TrapEffectFactory();
			pitContentEffectFactory = new TrapEffectFactory();
			gasTrapContentFactory = new TrapEffectFactory();
			trapDamagesFactory = new TrapEffectFactory();

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

		public string GetTrapBaseFactory()
		{
			return trapBaseFactory.GetFactory(basePrimaryTableDie.Roll()).Get();
		}
		
		public string GetTrapEffectFactory()
		{
			return effectFactory.GetFactory(effectPrimaryTableDie.Roll()).Get();
		}

		public string GetTrapDamageFactory()
		{
			return trapDamagesFactory.GetFactory(trapDamageTableDie.Roll()).Get();
		}

		private void LoadTables()
		{
			trapBasesXml = XElement.Load(xmlTrapComponentsFilePath);
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
			trapSubtablesXml = XElement.Load(xmlTrapSubtablesFilePath);
			trapDamageXml = XElement.Load(xmlTrapDamagesFilePath);

			try
			{
				basePrimaryTableDie = new DiceCup(DiceDefinition.Parse(trapBasesXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));

				trapBases = new List<TrapBases>();
				trapBases = trapBasesXml.Descendants("TrapBase").Select(tB => new TrapBases()
				{
					RollUpperBound = int.Parse(tB.Element("RollUpperBound").Value),
					TrappedObjectOrArea = tB.Element("TrappedObjectOrArea").Value,
					MechanismTypeSpecified = bool.Parse(tB.Element("MechanismTypeSpecified").Value)
				}
																		)
																.OrderBy(r => r.RollUpperBound);

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

				

				// Gas trap info here
				gasTrapTableDie = new DiceCup(DiceDefinition.Parse(trapSubtablesXml.Descendants("GasTrap").Select(d => d.Element("TableDieRoll").Element("DiceDefinition").Value).Single()));

				gasTypes = new List<GasTypes>();
				gasTypes = trapSubtablesXml.Descendants("GasType").Select(gT => new GasTypes()
																{
																	RollUpperBound = int.Parse(gT.Element("RollUpperBound").Value),
																	GasName = gT.Element("GasName").Value,
																}
																		  ).OrderBy(r => r.RollUpperBound);

				trapDamageTableDie = new DiceCup(DiceDefinition.Parse(trapDamageXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));

				trapDamages = trapDamageXml.Descendants("Damage").Select(tD => new TrapDamages()
																				{
																					RollUpperBound = int.Parse(tD.Element("RollUpperBound").Value),
																					DamageDescription = tD.Element("DamageDescription").Value,
																				}
																		)
																.OrderBy(r => r.RollUpperBound);

				foreach (var damage in trapDamages)
				{
					trapDamagesFactory.Add(damage.RollUpperBound, new SpecificTrapFactory(damage.DamageDescription));
				}

				foreach (var trapBase in trapBases)
				{
					trapBaseFactory.Add(trapBase.RollUpperBound, new SpecificTrapFactory(trapBase.TrappedObjectOrArea));
				}

				foreach (var content in pitContents)
				{
					pitContentEffectFactory.Add(content.RollUpperBound, new SpecificTrapFactory(content.PitContent));
				}

				foreach (var gas in gasTypes)
				{
					gasTrapContentFactory.Add(gas.RollUpperBound, new SpecificTrapFactory(gas.GasName));
				}

				foreach (var trapEffect in trapEffects)
				{
					if (trapEffect.RollAgain && trapEffect.NumberOfReRolls == 1)
					{
						effectFactory.Add(trapEffect.RollUpperBound, new ComplexTrapEffectFactory(effectFactory, effectPrimaryTableDie, trapEffect.EffectDescription));
					}
					else if (trapEffect.RollAgain && trapEffect.NumberOfReRolls > 1)
					{
						effectFactory.Add(trapEffect.RollUpperBound, new MultiRollEffectFactory(effectFactory, effectPrimaryTableDie, trapEffect.NumberOfReRolls, trapEffect.EffectDescription));
					}
					else if (trapEffect.HasSubtable && trapEffect.SubtableName == "PitContents")
					{
						effectFactory.Add(trapEffect.RollUpperBound, new PitTrapEffectFactory(pitContentEffectFactory, pitTrapTableDie, trapEffect.EffectDescription));
					}
					else if (trapEffect.HasSubtable && trapEffect.SubtableName == "GasType")
					{
						effectFactory.Add(trapEffect.RollUpperBound, new GasTrapEffectFactory(gasTrapContentFactory, gasTrapTableDie, trapEffect.EffectDescription));
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
