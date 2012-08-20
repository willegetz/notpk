using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private TrapBases TrapBase { get; set; }
		private List<TrapEffects> TrapEffect { get; set; }
		private TrapDamages TrapDamage { get; set; }

		public TheTrap()
		{
			TrapEffect = new List<TrapEffects>();
		}

		private object FormatEffects()
		{


			var sb = new StringBuilder();
			if (TrapEffect.Count <= 1)
			{
				return "\r\n\t" + TrapEffect[0].EffectDescription.ToLower();
			}
			else
			{
				int lastTrapEffectIndex = TrapEffect.Count - 1;
				for (int i = 0; i < lastTrapEffectIndex; i++)
				{
					if (string.IsNullOrEmpty(TrapEffect[i].EffectDescription))
					{
						continue;
					}
					sb.Append("\r\n\t" + TrapEffect[i].EffectDescription.ToLower() + ",");
				}
				sb.Append("\r\n\t" + TrapEffect[lastTrapEffectIndex].EffectDescription.ToLower());
			}
			return sb.ToString();
		}

		private bool IsValidIndex(int indexOfEffectToChange)
		{
			int firstIndex = 0;
			int lastIindex = TrapEffect.Count - 1;
			if (indexOfEffectToChange < firstIndex || indexOfEffectToChange > lastIindex)
			{
				return false;
			}
			return true;
		}

		public void SetTrapBase(TrapBases trapBase)
		{
				TrapBase = trapBase;
		}

		public void SetTrapEffect(IEnumerable<TrapEffects> trapEffects)
		{
			TrapEffect.AddRange(trapEffects);
		}

		public void SetTrapDamage(TrapDamages trapDamages)
		{
			TrapDamage = trapDamages;
		}

		public void ChangeMechanismType(string newMechanismType)
		{
			if (!string.IsNullOrEmpty(TrapBase.MechanismType))
			{
				TrapBase.MechanismType = string.Format(" ({0})", newMechanismType);
			}
		}

		public bool ChangeAnEffect(int indexOfEffectToChange, IEnumerable<TrapEffects> newEffect)
		{
			if (IsValidIndex(indexOfEffectToChange))
			{
				TrapEffect.RemoveAt(indexOfEffectToChange);
				TrapEffect.InsertRange(indexOfEffectToChange, newEffect);
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("{0}{1}{2}\r\n\tAnd {3}", TrapBase.TrappedObjectOrArea, TrapBase.MechanismType.ToLower(), FormatEffects(), TrapDamage.DamageDescription.ToLower());
		}
	}
}
