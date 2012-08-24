namespace DungeonBuildersGuidebook1.Factories
{
	public class SimpleFactory : ISpecificTrapFactory
	{
		private readonly string effectDescription;

		public SimpleFactory(string effectDescription)
		{
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			return effectDescription;
		}
	}
}
