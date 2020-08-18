using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class DrinkMenuController : BaseController
    {
        // GET: Admin/DrinkMenu
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new DrinkDAO();
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
        public ActionResult Create(Drink drink)
        {
            if (ModelState.IsValid)
            {
                var dao = new DrinkDAO();
                long id = dao.AddDrink(drink);
                if (id > 0)
                {
                    return RedirectToAction("Index", "DrinkMenu");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new DrinkDAO();
            var drink = dao.GetById(id);
            SetViewBag(drink.menu_id);
            return View(drink);
        }

        [HttpPost]
        public ActionResult Update(Drink drink)
        {
            if (ModelState.IsValid)
            {
                var dao = new DrinkDAO();
                bool result = dao.Update(drink);
                if (result)
                {
                    return RedirectToAction("Index", "DrinkMenu");
                }

            }
            SetViewBag(drink.menu_id);
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new DrinkDAO().Delete(id);
            return Redirect("Index");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new MenuDAO();
            ViewBag.menu_id = new SelectList(dao.ListAll(), "id", "kind", selectedId);
        }
    }
}