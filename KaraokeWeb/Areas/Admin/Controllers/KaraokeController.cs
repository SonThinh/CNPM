using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class KaraokeController : BaseController
    {
        // GET: Admin/Karaoke
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new KaraokeDAO();
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
        public ActionResult Create(Karaoke kara)
        {
            if (ModelState.IsValid)
            {
                var dao = new KaraokeDAO();
                long id = dao.AddKaraoke(kara);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Karaoke");
                }
            }
            return Redirect("Create");
        }
        public ActionResult Update(int id)
        {
            var kara = new KaraokeDAO().GetById(id);
            return View(kara);
        }

        [HttpPost]
        public ActionResult Update(Karaoke kara)
        {
            if (ModelState.IsValid)
            {
                var dao = new KaraokeDAO();
                bool result = dao.Update(kara);
                if (result)
                {
                    return RedirectToAction("Index", "Karaoke");
                }

            }
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new KaraokeDAO().Delete(id);
            return Redirect("Index");
        }
    }
}