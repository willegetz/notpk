using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DungeonBuildersGuidebook.Models;

namespace DungeonBuildersGuidebook.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult TrapArchitect()
		{
			return View(new TrapArchitectModel());
		}

		[HttpGet]
		public ActionResult GenerateNewTrap()
		{
			var newTrap = new List<string>();
            var trapArchitect = new TrapArchitectModel();
			newTrap.Add(trapArchitect.GetTrapBase());
			newTrap.Add(trapArchitect.GetTrapEffects());
			newTrap.Add(trapArchitect.GetTrapDamage());
			return new JsonResult() { Data = newTrap, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}
	}
}
