using DotNetMVC.Data.BAL;
using DotNetMVC.Data.DAL;
using DotNetMVC.Data.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DotNetMVC.Controllers
{
    public class AccountController : Controller
    {
        UserMasterBAL userMasterBAL = new UserMasterBAL();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                if (userMasterBAL.IsValidUser(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Id or Password");
                    return View();
                }
            }
            else
            {
                return View(user);
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserMaster model)
        {
            if (ModelState.IsValid)
            {
                userMasterBAL.RegisterUser(model);
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}