using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Web.Security;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserLog objuser)
        {
            if((objuser.UserName=="Admin" && objuser.Password=="Admin") ||
                (objuser.UserName == "Buyer" && objuser.Password == "Buyer"))
            {
                FormsAuthentication.SetAuthCookie(objuser.UserName, false);
                return RedirectToAction("Index", "Orders");
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
    }
}