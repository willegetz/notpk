using System;
using DungeonBuildersGuidebook1.TrapLoaders;
using DungeonBuildersGuidebook1.TrapComponentObjects;
using RpgTools.Dice;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DungeonBuildersGuidebook1.Factories;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private Random randomNumber;
		private TableLoader tableLoader;
		private XElement trapBasesXml;
		private XElement trapEffectsXml;
		private XElement trapSubtablesXml;
		private XElement trapDamageXml;
		private IEnumerable<TrapBases> trapBases;
		private IEnumerable<TrapEffects> trapEffects;
		private IEnumerable<TrapDamages> trapDamages;
		private List<KeyValuePair<int, string>> mechanismTypes;
		private string xmlTrapComponentsFilePath = DataConstants.DataFilesPath + "TrapComponents.xml";
		private string xmlTrapEffectsFilePath = DataConstants.DataFilesPath + "TrapEffectsAndTraits.xml";
		private string xmlTrapDamagesFilePath = DataConstants.DataFilesPath + "TrapDamages.xml";
		private TrapEffectFactory trapBaseFactory;
		private TrapEffectFactory effectFactory;
		private TrapEffectFactory pitContentEffectFactory;
		private TrapEffectFactory gasTrapContentFactory;
		private TrapEffectFactory trapDamagesFactory;
		private TrapEffectFactory mechanismFactory;
		private DiceCup basePrimaryTableDie;
		private DiceCup effectPrimaryTableDie;
		private DiceCup pitTrapTableDie;
		private DiceCup gasTrapTableDie;
		private DiceCup trapDamageTableDie;
		private DiceCup mechanismTableDie;

		public TrapArchitect()
		{
			tableLoader = new TableLoader();
			
			trapBaseFactory = new TrapEffectFactory();
			effectFactory = new TrapEffectFactory();
			pitContentEffectFactory = new TrapEffectFactory();
			gasTrapContentFactory = new TrapEffectFactory();
			trapDamagesFactory = new TrapEffectFactory();
			mechanismFactory = new TrapEffectFactory();

			LoadTables();
		}

		public void SetRandomNumber()
		{
			randomNumber = new Random((int)DateTime.UtcNow.Ticks);
		}

		public string GetSpecificTrapBase(int specificResult)
		{
			return trapBaseFactory.GetFactory(specificResult).Get();
		}

		public string GetSpecificTrapEffect(int specificResult)
		{
			return effectFactory.GetFactory(specificResult).Get();
		}

		public string GetSpecificTrapDamage(int specificResult)
		{
			return trapDamagesFactory.GetFactory(specificResult).Get();
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

		public Trap GetTrap()
		{
			var trapBase = trapBaseFactory.GetFactory(basePrimaryTableDie.Roll()).Get();
			var trapEffect = effectFactory.GetFactory(effectPrimaryTableDie.Roll()).Get();
			var trapDamage = trapDamagesFactory.GetFactory(trapDamageTableDie.Roll()).Get();
			return new Trap(trapBase, trapEffect, trapDamage);
		}

		private void LoadTables()
		{
			trapBasesXml = XElement.Load(xmlTrapComponentsFilePath);
			trapEffectsXml = XElement.Load(xmlTrapEffectsFilePath);
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

				mechanismTableDie = new DiceCup(DiceDefinition.Parse(trapBasesXml.Descendants("MechanismDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));

				mechanismTypes = new List<KeyValuePair<int, string>>();
				mechanismTypes = trapBasesXml.Descendants("Mechanism").ToDictionary(m => int.Parse(m.Element("RollUpperBound").Value), m => m.Element("MechanismType").Value).ToList();

				
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

				pitTrapTableDie = tableLoader.GetPitTrapTableDie();
				var pitContents = tableLoader.GetPitTrapContents();

				gasTrapTableDie = tableLoader.GetGasTrapTableDie();
				var gasTypes = tableLoader.GetGasTrpContents();

				//trapDamageTableDie = new DiceCup(DiceDefinition.Parse(trapDamageXml.Descendants("TableDieRoll").Select(d => d.Element("DiceDefinition").Value).Single()));
				trapDamageTableDie = tableLoader.GetTrapDamageTableDie();
				trapDamages = trapDamageXml.Descendants("Damage").Select(tD => new TrapDamages()
																				{
																					RollUpperBound = int.Parse(tD.Element("RollUpperBound").Value),
																					DamageDescription = tD.Element("DamageDescription").Value,
																				}
																		)
																.OrderBy(r => r.RollUpperBound);

				foreach (var damage in trapDamages)
				{
					trapDamagesFactory.Add(damage.RollUpperBound, new SimpleFactory(damage.DamageDescription));
				}

				foreach (var mechanism in mechanismTypes)
				{
					mechanismFactory.Add(mechanism.Key, new SimpleFactory(mechanism.Value));
				}

				foreach (var trapBase in trapBases)
				{
					if (trapBase.MechanismTypeSpecified)
					{
						trapBaseFactory.Add(trapBase.RollUpperBound, new MechanizedBaseFactory(mechanismFactory, mechanismTableDie, trapBase.TrappedObjectOrArea));
					}
					else
					{
						trapBaseFactory.Add(trapBase.RollUpperBound, new SimpleFactory(trapBase.TrappedObjectOrArea));
					}
				}

				foreach (var content in pitContents)
				{
					pitContentEffectFactory.Add(content.RollUpperBound, new SimpleFactory(content.PitContent));
				}

				foreach (var gas in gasTypes)
				{
					gasTrapContentFactory.Add(gas.RollUpperBound, new SimpleFactory(gas.GasName));
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
						effectFactory.Add(trapEffect.RollUpperBound, new SimpleFactory(trapEffect.EffectDescription));
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
