using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class FoodMenuController : BaseController
    {
        // GET: Admin/FoodMenu
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new FoodDAO();
            var model = dao.ListAllPage(search, page, pageSize);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                var dao = new FoodDAO();
                long id = dao.AddFood(food);
                if (id > 0)
                {
                    return RedirectToAction("Index", "FoodMenu");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new FoodDAO();
            var food = dao.GetById(id);
            SetViewBag(food.menu_id);
            return View(food);
        }

        [HttpPost]
        public ActionResult Update(Food food)
        {
            if (ModelState.IsValid)
            {
                var dao = new FoodDAO();
                bool result = dao.Update(food);
                if (result)
                {
                    return RedirectToAction("Index", "FoodMenu");
                }

            }
            SetViewBag(food.menu_id);
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new FoodDAO().Delete(id);
            return Redirect("Index");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new MenuDAO();
            ViewBag.menu_id = new SelectList(dao.ListAll(), "id", "kind", selectedId);
        }
    }
}