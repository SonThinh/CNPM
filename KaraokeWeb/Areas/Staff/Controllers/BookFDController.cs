using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class BookFDController : BaseController
    {
        // GET: Staff/BookFD
        public ActionResult ViewFD(int id)
        {
            ViewBag.fDetail = new Food_DetailDAO().ListFoodDetailFromBill(id);
            ViewBag.dDetail = new Drink_DetailDAO().ListDrinkDetailFromBill(id);
            return View();
        }
        [HttpGet]
        public ActionResult AddFood(int id)
        {
            var bill = new BillDAO().GetById(id);
            SetViewBag1(id);
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult AddFood(Food_Detail fd)
        {
            if (ModelState.IsValid)
            {
                var dao = new Food_DetailDAO();
                var fdao = new FoodDAO().GetById(fd.food_id);
                fd.price = fdao.price;
                fd.total = fd.price * fd.amount;
                dao.AddFoodDetail(fd);
                return RedirectToAction("Index", "Book");
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new Food_DetailDAO();
            dao.Delete(id);
            return RedirectToAction("Index", "Book");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new FoodDAO();
            ViewBag.food_id = new SelectList(dao.ListAll(), "food_id", "food_name", selectedId);
        }
        public void SetViewBag1(int bill_id, int? selectedId = null)
        {
            var dao = new BillDAO();
            ViewBag.bill_id = new SelectList(dao.ListBill(bill_id), "bill_id", "bill_id", selectedId);
        }
        public void SetViewBag2(int? selectedId = null)
        {
            var dao = new DrinkDAO();
            ViewBag.drink_id = new SelectList(dao.ListAll(), "drink_id", "drink_name", selectedId);
        }
        [HttpGet]
        public ActionResult AddDrink(int id)
        {
            var bill = new BillDAO().GetById(id);
            SetViewBag1(id);
            SetViewBag2();
            return View();
        }
        [HttpPost]
        public ActionResult AddDrink(Drink_Detail dd)
        {
            if (ModelState.IsValid)
            {
                var dao = new Drink_DetailDAO();
                var ddao = new DrinkDAO().GetById(dd.drink_id);
                dd.price = ddao.price;
                dd.total = dd.price * dd.amount;
                dao.AddDrinkDetail(dd);
                return RedirectToAction("Index", "Book");

            }
            return View();
        }
        [HttpDelete]
        public ActionResult DeleteD(int id)
        {
            var dao = new Drink_DetailDAO();
            dao.Delete(id);
            return RedirectToAction("Index", "Book");
        }
    }
}