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
            var trapArchitect = new TrapArchitectModel();
			var newTrap = trapArchitect.GetEmptyTrap();

			newTrap.AddTrapBase(trapArchitect.GetTrapBase());
			newTrap.AddTrapEffects(trapArchitect.GetTrapEffects());
			newTrap.AddTrapDamage(trapArchitect.GetTrapDamage());
			return new JsonResult() { Data = newTrap, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpPost]
		public ActionResult DisplayPreservedTraps(string[] keptTraps)
		{
			foreach (var item in keptTraps)
			{
				var blah = item;
			}

			return null;
		}
	}
}
