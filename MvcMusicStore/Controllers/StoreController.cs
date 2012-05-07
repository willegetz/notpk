using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
	public class StoreController : Controller
	{
		MusicStoreEntities storeDb = new MusicStoreEntities();
		//
		// GET: /Store/

		public ActionResult Index()
		{
			var genres = storeDb.Genres.ToList();
			return View(genres);
		}

		//
		// Get: /Store/Browse

		public ActionResult Browse(string genre)
		{
			var genreModel = storeDb.Genres.Include("Albums")
				.Single(g => g.Name == genre);
			return View(genreModel);
		}

		//
		// Get: /Store/Details/

		public ActionResult Details(int id)
		{
			var album = storeDb.Albums.Find(id);
			//var album = new Album { Title = "Album " + id };
			return View(album);
		}

	}
}
