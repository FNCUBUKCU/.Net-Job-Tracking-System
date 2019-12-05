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
    public class TasksController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: Tasks
        public ActionResult Index()
        {
            //var userWorks = db.UserWorks.Include(u => u.Users).Include(u => u.Works);
            Users user = Session["CurrentUser"] as Users;
            if (user != null)
            {
                var allWorks = db.UserWorks.Include(u => u.Users).Include(u => u.Works).ToList();
                List<Users> departmentUsers = db.Users
                    .Where(x => x.DepartmentId == user.DepartmentId).ToList();
                Users departmentDirector = departmentUsers
                    .FirstOrDefault(y => y.Missions.IsDirector ?? false);
                IEnumerable<UserWorks> userWorks = new List<UserWorks>();
                if (departmentDirector.Id != user.Id)
                    
                    userWorks = allWorks.Where(x => x.UsersId == user.Id);
                //userWorks = allWorks.Where(x => x.Id == user.Id);

                return View(userWorks.ToList());
            }
            else
                return RedirectToAction("Index", "Home");
            //return View(userWorks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorks userWorks = db.UserWorks.Find(id);
            if (userWorks == null)
            {
                return HttpNotFound();
            }
            return View(userWorks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.UsersId = new SelectList(db.Users, "Id", "Name");
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Number");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsersId,WorksId,StartDate,EndDate,ActualEffort,AssignedEffort,RemainingEfort,CreatedTime,LastUpdateTime,UpdateExplanation,Status")] UserWorks userWorks)
        {
            if (ModelState.IsValid)
            {
                db.UserWorks.Add(userWorks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsersId = new SelectList(db.Users, "Id", "Name", userWorks.UsersId);
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Number", userWorks.WorksId);
            return View(userWorks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorks userWorks = db.UserWorks.Find(id);
            if (userWorks == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsersId = new SelectList(db.Users, "Id", "Name", userWorks.UsersId);
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Name", userWorks.WorksId);
            return View(userWorks);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsersId,WorksId,StartDate,EndDate,ActualEffort,CreatedTime,LastUpdateTime,AssignedEffort,RemainingEfort,UpdateExplanation,Status")] UserWorks userWorks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWorks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsersId = new SelectList(db.Users, "Id", "Name", userWorks.UsersId);
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Name", userWorks.WorksId);
            return View(userWorks);
        }

    }
}
