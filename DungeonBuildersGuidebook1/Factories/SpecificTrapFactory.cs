using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonBuildersGuidebook1.Factories
{
	public class SpecificTrapFactory : ISpecificTrapFactory
	{
		private string effectDescription;

		public SpecificTrapFactory(string effectDescription)
		{
			// TODO: Complete member initialization
			this.effectDescription = effectDescription;
		}

		public string Get()
		{
			return effectDescription.ToLower();
		}
	}
}
