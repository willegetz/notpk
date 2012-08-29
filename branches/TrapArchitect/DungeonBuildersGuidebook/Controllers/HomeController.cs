﻿using System;
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
		public ActionResult UpdateBase()
		{
			var newBase = new TrapArchitectModel();
			return new JsonResult() { Data = newBase.GetTrapBase(), JsonRequestBehavior = JsonRequestBehavior.AllowGet};
			
		}
	}
}
