namespace DungeonBuildersGuidebook1.TrapComponentObjects
{
	public class TrapEffects
	{
		public bool RollAgain { get; set; } 
		public bool HasSubtable { get; set; } // Subtable
		public int RollUpperBound { get; set; }  // Setting the top of the range in the dictionary
		public int NumberOfReRolls { get; set; }
		public string EffectDescription { get; set; }
		public string AdditionalInformation { get; set; }
		public string SubtableName { get; set; } // Subtable
		public string SubtableEffectDescription { get; set; } // Subtable
	}
}
