using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Staff/Home
        public ActionResult Index()
        {
            ViewBag.kara = new KaraokeDAO().ListAll();
            return View();
        }
    }
}