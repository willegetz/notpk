using System.Text;

namespace DungeonBuildersGuidebook1
{
	public class Trap
	{
		public string TrapBase { get; private set; }
		public string TrapEffects { get; private set; }
		public string TrapDamage { get; private set; }
		public string Notes { get; private set; }

		public Trap()
		{

		}

		public Trap(string trapBase, string trapEffect, string trapDamage)
		{
			TrapBase = trapBase;
			TrapEffects = trapEffect;
			TrapDamage = trapDamage;
		}

		public void AddTrapBase(string trapBase)
		{
			TrapBase = trapBase;
		}

		public void AddTrapEffects(string trapEffects)
		{
			TrapEffects = trapEffects;
		}
       
		public void AddTrapDamage(string trapDamage)
		{
			TrapDamage = trapDamage;
		}

		public void AddNotes(string notes)
		{
			Notes = notes;
		}
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(TrapBase);
			sb.AppendLine(TrapEffects);
			sb.AppendLine(TrapDamage);
			if (!string.IsNullOrEmpty(Notes))
			{
				sb.AppendLine(Notes);
			}
			return sb.ToString();
		}
	}
}
