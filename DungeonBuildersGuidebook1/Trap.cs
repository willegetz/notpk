using System.Text;

namespace DungeonBuildersGuidebook1
{
	public class Trap
	{
		private readonly string trapBase;
		public string trapEffect { get; private set; }
		private readonly string trapDamage;
		private string notes;

		public Trap(string trapBase, string trapEffect, string trapDamage)
		{
			this.trapBase = trapBase;
			this.trapEffect = trapEffect;
			this.trapDamage = trapDamage;
		}

		public void AddNotes(string notes)
		{
			this.notes = notes;
		}
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine(trapBase);
			sb.AppendLine(trapEffect);
			sb.AppendLine(trapDamage);
			if (!string.IsNullOrEmpty(notes))
			{
				sb.AppendLine(notes);
			}
			return sb.ToString();
		}
	}
}
