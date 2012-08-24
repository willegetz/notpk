using System.Text;
using RpgTools.Dice;

namespace DungeonBuildersGuidebook1.Factories
{
	public class MultiRollEffectFactory : ISpecificTrapFactory
	{
		private readonly TrapEffectFactory effectFactory;
		private readonly DiceCup tableDiceRoll;
		private readonly int numberOfReRolls;
		private readonly string effectDescription;

		public MultiRollEffectFactory(TrapEffectFactory effectFactory, DiceCup tableDiceRoll, int numberOfReRolls, string effectDescription)
		{
			this.effectFactory = effectFactory;
			this.tableDiceRoll = tableDiceRoll;
			this.numberOfReRolls = numberOfReRolls;
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			var sb = new StringBuilder();
			if (!string.IsNullOrEmpty(effectDescription))
			{
				sb.Append(effectDescription + "\r\n");
			}

			int i = 0;
			while (i < (numberOfReRolls -1))
			{
				sb.Append(effectFactory.GetFactory(tableDiceRoll.Roll()).Get() + "\r\n");
				i++;
			}
			sb.Append(effectFactory.GetFactory(tableDiceRoll.Roll()).Get());
			return sb.ToString();
		}
	}
}
