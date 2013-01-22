using RJK.CSharp.CustomLists.RangeDictionary;

namespace DungeonBuildersGuidebook1.Factories
{
	public class TrapEffectFactory
	{
		private RangeDictionary<int, ISpecificTrapFactory> trapEffectTable;

		public TrapEffectFactory()
		{
			trapEffectTable = new RangeDictionary<int, ISpecificTrapFactory>();
		}

		public ISpecificTrapFactory GetFactory(int specificResult)
		{
			return trapEffectTable[specificResult];
		}

		public void Add(int upperBound, ISpecificTrapFactory specificTrapFactory)
		{
			trapEffectTable.Add(upperBound, specificTrapFactory);
		}
	}
}
