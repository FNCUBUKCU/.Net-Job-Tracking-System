using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stajprojem.Models;

namespace Stajprojem.Controllers
{
    public class HomeController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        public ActionResult Bos()
        {
            return View();
        }
        public ActionResult Announcements()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null)
            {
                return View("Bos");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Index(Users Cuser)
        {
            if (ModelState.IsValid)
            {
                var login = db.Users.Where(u => u.Email == Cuser.Email && u.Password == Cuser.Password).SingleOrDefault();
                if (login != null)
                {
                    Session["CurrentUser"] = login;

                    return View("Bos");
                }

                ModelState.AddModelError("", "username or password incorrect");


            }
            return View(Cuser);

        }



        [HttpPost]
        public void Logout()
        {
            Session["CurrentUser"] = null;
            Response.Redirect("~/");
        }
    }

}