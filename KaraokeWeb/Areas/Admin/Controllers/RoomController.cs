using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Admin/Room
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new RoomDAO();
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
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDAO();
                long id = dao.AddRoom(room);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Room");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new RoomDAO();
            var room = dao.GetById(id);
            SetViewBag(room.kara_id);
            return View(room);
        }

        [HttpPost]
        public ActionResult Update(Room room)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDAO();
                bool result = dao.Update(room);
                if (result)
                {
                    return RedirectToAction("Index", "room");
                }

            }
            SetViewBag(room.kara_id);
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new RoomDAO().Delete(id);
            return Redirect("Index");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao = new KaraokeDAO();
            ViewBag.kara_id = new SelectList(dao.ListAll(), "kara_id", "kara_name", selectedId);
        }
    }
}