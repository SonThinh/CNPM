using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.menu = new MenuDAO().ListAllMenu(10);
            return View();
        }
    }
}