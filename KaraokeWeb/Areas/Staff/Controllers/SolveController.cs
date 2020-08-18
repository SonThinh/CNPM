using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class SolveController : BaseController
    {
        // GET: Staff/Solve
        public ActionResult ShowBill(int id)
        {
            var billDAO = new BillDAO();
            var bill = billDAO.GetById(id);

            var foodDAO = new Food_DetailDAO();
            var food = foodDAO.GetByBillId(id);

            var drinkDAO = new Drink_DetailDAO();
            var drink = drinkDAO.GetByBillId(id);

            var roomDAO = new RoomDAO();
            var room = roomDAO.GetById(bill.room_id) ;
            room.r_status = 0;
            roomDAO.Update(room);
            if(food == null && drink == null)
            {
                bill.total = bill.total_room;
            }
            else if (food == null)
            {
                bill.total = bill.total_room + drink.total;
            }
            else if (drink == null )
            {
                bill.total = bill.total_room + food.total;
            }
            else {
                bill.total = bill.total_room + food.total + drink.total;
            }
            
            bill.status = 0;
            billDAO.Update(bill);

            ViewBag.fDetail = foodDAO.ListFoodDetailFromBill(id);
            ViewBag.dDetail = drinkDAO.ListDrinkDetailFromBill(id);
            return View();
        }
    }
}