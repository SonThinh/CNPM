using KaraokeWeb.Areas.Admin.Models;
using KaraokeWeb.Common;
using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Staff.Controllers
{
    public class LoginController : Controller
    {
        // GET: Staff/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var result = dao.LoginEmp(model.UserName, Encryptor.MD5Hash(model.PassWord));
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var empSession = new EmpLogin();
                    empSession.UserName = user.username;
                    empSession.EmpId = user.id;
                    Session.Add(CommonConstants.EMP_SESSION, empSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Invalid account");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Wrong password");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.EMP_SESSION] = null;
            return Redirect("/Staff/Login/");
        }
    }
}