using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stajprojem.Models;

namespace Stajprojem.Controllers
{
    public class MissionsController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: Missions
        public ActionResult Index()
        {
            return View(db.Missions.ToList());
        }
        
    
    }
}
