using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TheTrap
	{
		private TrapBases TrapBase { get; set; }
		private List<TrapEffects> TrapEffects { get; set; }
		private TrapDamages TrapDamage { get; set; }

		private string effects { get; set; }

		public TheTrap()
		{
			TrapEffects = new List<TrapEffects>();
		}

		private string FormatEffects()
		{
			var sb = new StringBuilder();
			if (TrapEffects.Count <= 1)
			{
				return "\r\n\t" + TrapEffects[0].EffectDescription.ToLower() + ValidSubtableDescription();
			}
			else
			{
				int lastTrapEffectIndex = TrapEffects.Count - 1;
				for (int i = 0; i < lastTrapEffectIndex; i++)
				{
					if (string.IsNullOrEmpty(TrapEffects[i].EffectDescription))
					{
						continue;
					}
					sb.Append("\r\n\t" + TrapEffects[i].EffectDescription.ToLower() + ",");
				}
				sb.Append("\r\n\t" + TrapEffects[lastTrapEffectIndex].EffectDescription.ToLower());
			}
			return sb.ToString();
		}

		private string ValidSubtableDescription()
		{
			return string.IsNullOrEmpty(TrapEffects[0].SubtableEffectDescription) ? string.Empty : TrapEffects[0].SubtableEffectDescription.ToLower();
		}

		private bool IsValidIndex(int indexOfEffectToChange)
		{
			int firstIndex = 0;
			int lastIindex = TrapEffects.Count - 1;
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
			TrapEffects.AddRange(trapEffects);
		}

		public void SetTrapEffect(string effect)
		{
			effects = effect;
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
				TrapEffects.RemoveAt(indexOfEffectToChange);
				TrapEffects.InsertRange(indexOfEffectToChange, newEffect);
				return true;
			}
			return false;
		}

		public override string ToString()
		{
			//return string.Format("{0}{1}{2}\r\n\tAnd {3}", TrapBase.TrappedObjectOrArea, TrapBase.MechanismType.ToLower(), FormatEffects(), TrapDamage.DamageDescription.ToLower());
			return string.Format("{0}{1}{2}\r\n\tAnd {3}", TrapBase.TrappedObjectOrArea, TrapBase.MechanismType.ToLower(), effects.ToLower(), TrapDamage.DamageDescription.ToLower());
		}

		public string GetSubtableType(int effectIndex)
		{
			return TrapEffects[effectIndex].SubtableName;
		}

		public bool ChangeAnEffectSubtableDescription(int effectIndex, string newSubtableDescription)
		{
			if (IsValidIndex(effectIndex))
			{
				TrapEffects[effectIndex].SubtableEffectDescription = newSubtableDescription;
				return true;
			}
			return false;
		}
	}
}
