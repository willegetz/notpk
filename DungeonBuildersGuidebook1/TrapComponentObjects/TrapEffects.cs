using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TrapEffects
	{
		public int RollUpperBound { get; set; }
		public string EffectDescription { get; set; }
		public bool EffectRollRequired { get; set; }
		public List<string> EffectDiceToRoll { get; set; }
		public bool AdditionalTablesToConsult { get; set; }
		public string AdditionalTableName { get; set; }
		public bool AddAdditionalEffects { get; set; }
		public int NumberOfAdditonalEffects { get; set; }
	}
}
