using System;
using DungeonBuildersGuidebook1.TrapLoaders;
using RpgTools.Dice;
using System.Collections.Generic;
using System.Linq;
using DungeonBuildersGuidebook1.Factories;

namespace DungeonBuildersGuidebook1
{
	public class TrapArchitect
	{
		private static TableLoader tableLoader;
		private static TrapEffectFactory trapBaseFactory;
		private static TrapEffectFactory effectFactory;
		private static TrapEffectFactory pitContentEffectFactory;
		private static TrapEffectFactory gasTrapContentFactory;
		private static TrapEffectFactory trapDamagesFactory;
		private static TrapEffectFactory mechanismFactory;
		
		private DiceCup basePrimaryTableDie;
		private Random randomNumber;
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
			try
			{
				basePrimaryTableDie = TableLoader.GetTrapBaseTableDie();
				var trapBases = TableLoader.GetTrapBaseContents();

				mechanismTableDie = TableLoader.GetTrapMechanismTableDie();
				var mechanismTypes = TableLoader.GetTrapMechanismContents();

				
				effectPrimaryTableDie = TableLoader.GetTrapEffectsTableDie();
				var trapEffects = TableLoader.GetTrapEffectsContents();

				pitTrapTableDie = TableLoader.GetPitTrapTableDie();
				var pitContents = TableLoader.GetPitTrapContents();

				gasTrapTableDie = TableLoader.GetGasTrapTableDie();
				var gasTypes = TableLoader.GetGasTrpContents();

				trapDamageTableDie = TableLoader.GetTrapDamageTableDie();
				var trapDamages = TableLoader.GetTrapDamages();

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


	}
}
