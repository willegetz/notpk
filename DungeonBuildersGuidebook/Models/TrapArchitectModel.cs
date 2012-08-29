using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DungeonBuildersGuidebook1;
using System.Web.Mvc;

namespace DungeonBuildersGuidebook.Models
{
	public class TrapArchitectModel
	{
		public TrapArchitect trapArchitect;
		
		public TrapArchitectModel()
		{
			trapArchitect = new TrapArchitect();
		}

		public string GetTrapBase()
		{
			return trapArchitect.GetTrapBaseFactory();
		}

		public string GetTrapEffects()
		{
			return trapArchitect.GetTrapEffectFactory();;
		}

		public string GetTrapDamage()
		{
			return trapArchitect.GetTrapDamageFactory();
		}
	}
}