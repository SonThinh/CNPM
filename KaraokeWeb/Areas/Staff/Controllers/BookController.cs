using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class BookController : BaseController
    {
        // GET: Staff/Book
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new BillDAO();
            var model = dao.ListAllPage(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult AddBill(int id)
        {
            var dao = new RoomDAO();
            var room = dao.GetById(id);
            SetViewBag(room.kara_id,id);
            return View();
        }
        [HttpPost]
        public ActionResult AddBill(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDAO();
                var roomDao = new RoomDAO();
                var roomid = roomDao.GetById(bill.room_id);
                bill.price = roomid.price;
                bill.total_room = bill.used_time * bill.price;
                bill.total = bill.total_room;
                long id = dao.AddBill(bill);
                var room = roomDao.ChangeRoomStatus(bill.room_id, 1);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult AddReserve(int id)
        {
            var dao = new RoomDAO();
            var room = dao.GetById(id);
            SetViewBag(room.kara_id,id);
            return View();
        }
        [HttpPost]
        public ActionResult AddReserve(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDAO();
                long id = dao.AddBill(bill);
                var roomDao = new RoomDAO().ChangeRoomStatus(bill.room_id, 2);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var bill = new BillDAO().GetById(id);
            var room = new RoomDAO().GetById(bill.room_id);
            SetViewBag1(room.kara_id, bill.room_id);
            return View(bill);
        }

        [HttpPost]
        public ActionResult Update(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDAO();
                var roomDao = new RoomDAO();
                var roomid = roomDao.GetById(bill.room_id);
                bill.price = roomid.price;
                bill.total_room = bill.used_time * bill.price;
                bill.total = bill.total_room;
                var room = roomDao.ChangeRoomStatus(bill.room_id, 1);
                bool result = dao.Update(bill);
                if (result)
                {
                    return RedirectToAction("Index", "Book");
                }

            }
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new BillDAO();
            var bill = dao.GetById(id);

            var fooddao = new Food_DetailDAO();
            var food = fooddao.GetByBillId(id);
            fooddao.Delete(food.bill_id);

            var drinkdao = new Drink_DetailDAO();
            var drink = drinkdao.GetByBillId(id);
            drinkdao.Delete(drink.bill_id);

            dao.Delete(id);
            var room = new RoomDAO().ChangeRoomStatus(bill.room_id, 0);
            return Redirect("Index");
        }
        public void SetViewBag(int kara_id, int? selectedId = null)
        {
            var dao = new RoomDAO();
            ViewBag.room_id = new SelectList(dao.ListAllEmpty(kara_id), "room_id", "room_name", selectedId);
        }
        public void SetViewBag1(int kara_id, int? selectedId = null)
        {
            var dao = new RoomDAO();
            ViewBag.room_id = new SelectList(dao.ListRoomFromKara(kara_id), "room_id", "room_name", selectedId);
        }
    }
}