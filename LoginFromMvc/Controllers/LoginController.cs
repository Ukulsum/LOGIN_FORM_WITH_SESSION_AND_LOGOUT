using LoginFromMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginFromMvc.Controllers
{
    public class LoginController : Controller
    {
        LoginDbEntities db = new LoginDbEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(User u)
        {
            if(ModelState.IsValid == true)
            {
                var credentials = db.Users.Where(model => model.userName == u.userName && model.Password == u.Password).FirstOrDefault();
                if(credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed.";
                    return View();
                }
                else
                {
                    Session["userName"] = u.userName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Login"); 
        }


        public ActionResult Reset()
        {
            //ModelState.Clear();
            return RedirectToAction("Index","Login");
        }
    }
}