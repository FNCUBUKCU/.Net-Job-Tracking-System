using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stajprojem.Models;
using System.Data.Entity.Migrations;

namespace Stajprojem.Controllers
{
    public class UsersController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Departments).Include(u => u.Activities).Include(u=>u.Missions);
            return View(users.ToList());
        }
        // GET: Users/Profile
        public new ActionResult Profile()
        {
            Users user = Session["CurrentUser"] as Users;
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult Profile([Bind(Include = "Id,Name,Lastname,Email,Password,PhoneNumber")] Users users)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(x => x.Id == users.Id);
                user.Name = users.Name;
                user.Lastname = users.Lastname;
                user.Email = users.Email;
                user.Password = users.Password;
                user.PhoneNumber = users.PhoneNumber;

                db.SaveChanges();
                Session["CurrentUser"] = user;
                return RedirectToAction("Profile");
            }
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.ActivitieId = new SelectList(db.Activities, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.MissionId = new SelectList(db.Missions, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Lastname,Email,Password,PhoneNumber,DepartmentId,MissionId,ActivitieId,Status")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivitieId = new SelectList(db.Activities, "Id", "Name", users.ActivitieId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", users.DepartmentId);
            ViewBag.MissionId = new SelectList(db.Missions, "Id", "Name", users.MissionId);
            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivitieId = new SelectList(db.Activities, "Id", "Name", users.ActivitieId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", users.DepartmentId);
            ViewBag.MissionId = new SelectList(db.Missions, "Id", "Name", users.MissionId);
            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Lastname,Email,Password,PhoneNumber,DepartmentId,MissionId,ActivitieId,Status")] Users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivitieId = new SelectList(db.Activities, "Id", "Name", users.ActivitieId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", users.DepartmentId);
            ViewBag.MissionId = new SelectList(db.Missions, "Id", "Name", users.MissionId);
            return View(users);
        }
    }
}
