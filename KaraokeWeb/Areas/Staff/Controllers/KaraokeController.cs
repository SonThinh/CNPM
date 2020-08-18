using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class KaraokeController : BaseController
    {
        // GET: Staff/Karaoke
        public ActionResult ShowRoom(int id)
        {
            ViewBag.room = new RoomDAO().ListRoomFromKara(id);
            return View();
        }
        public ActionResult Cancel(int id)
        {
            var dao = new RoomDAO();
            var room = dao.GetById(id);
            return View(room);
        }
        [HttpPost]
        public ActionResult Cancel(Room room)
        {
            var result = new RoomDAO().Cancel(room);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}