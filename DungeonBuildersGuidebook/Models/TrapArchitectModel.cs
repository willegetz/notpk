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
			trapArchitect = new DungeonBuildersGuidebook1.TrapArchitect();
		}

		public string GetTrapBase()
		{
			return trapArchitect.GetTrapBaseFactory();
		}

		public MvcHtmlString GetTrapEffects()
		{
			var effects = trapArchitect.GetSpecificTrapEffect(100);
			var effectString = string.Empty;
			var splitEffects = effects.Split('\r');
			for (int i = 0; i < splitEffects.Length; i++)
			{
				effectString += splitEffects[i] + "<br />";
			}

			var converted = MvcHtmlString.Create(effectString);

			return converted;
		}

		public string GetTrapDamage()
		{
			return trapArchitect.GetTrapDamageFactory();
		}
	}
}