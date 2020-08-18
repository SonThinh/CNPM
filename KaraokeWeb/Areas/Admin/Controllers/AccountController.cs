using KaraokeWeb.Common;
using KaraokeWeb.Models.DAO;
using KaraokeWeb.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        public ActionResult Index(string search, int page = 1, int pageSize = 5)
        {
            var dao = new AccountDAO();
            var model = dao.ListAllPage(search,page,pageSize);
            ViewBag.search = search;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Account acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var encryptedMd5Pass = Encryptor.MD5Hash(acc.password);
                acc.password = encryptedMd5Pass;
                long id = dao.AddAccount(acc);
                if (id > 0)
                {
                    SetAlert("Add success", "success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    SetAlert("Add error", "error");
                }

            }
            return Redirect("Create");
        }

        public ActionResult Update(int id)
        {
            var account = new AccountDAO().GetById(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Update(Account acc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                if (!string.IsNullOrEmpty(acc.password))
                {
                    var encryptedMd5Pass = Encryptor.MD5Hash(acc.password);
                    acc.password = encryptedMd5Pass;
                }
                bool result = dao.Update(acc);
                if (result)
                {
                    SetAlert("Update success", "success");
                    return RedirectToAction("Index", "Account");
                }
                else
                {
                    SetAlert("Update error", "error");
                }

            }
            return Redirect("Update");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AccountDAO().Delete(id);
            return Redirect("Index");
        }
    }
}