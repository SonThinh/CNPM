using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin/Bill
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new BillDAO();
            var model = dao.ListAllPage (page, pageSize);
            return View(model);
        }
    }
}