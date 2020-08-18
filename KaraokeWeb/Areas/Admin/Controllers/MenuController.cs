using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new MenuDAO();
            var model = dao.ListAllPage(search, page, pageSize);
            ViewBag.search = search;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();
                long id = dao.AddMenu(menu);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Menu");
                }
            }
            return Redirect("Create");
        }
        public ActionResult Update(int id)
        {
            var menu = new MenuDAO().GetById(id);
            return View(menu);
        }

        [HttpPost]
        public ActionResult Update(Menu menu)
        {
            if (ModelState.IsValid)
            {
                var dao = new MenuDAO();
                bool result = dao.Update(menu);
                if (result)
                {
                    return RedirectToAction("Index", "Menu");
                }

            }
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new MenuDAO().Delete(id);
            return Redirect("Index");
        }
    }
}