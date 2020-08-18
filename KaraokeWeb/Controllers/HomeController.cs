using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.room = new RoomDAO().ListAll();
            ViewBag.kara = new KaraokeDAO().ListAll();
            return View();
        }

        
    }
}