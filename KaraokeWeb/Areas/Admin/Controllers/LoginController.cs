using KaraokeWeb.Areas.Admin.Models;
using KaraokeWeb.Common;
using KaraokeWeb.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KaraokeWeb.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var result = dao.LoginAdmin(model.UserName, Encryptor.MD5Hash(model.PassWord),true);
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var empSession = new EmpLogin();
                    empSession.UserName = user.username;
                    empSession.EmpId = user.id;
                    Session.Add(CommonConstants.EMP_SESSION, empSession);
                    return RedirectToAction("Index", "Home");
                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Invalid account");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Wrong password");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Login failed");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.EMP_SESSION] = null;
            return Redirect("/Admin/Login/");
        }
    }
}