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
    public class UserWorksController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: UserWorks
        public ActionResult Index()
        {
            Users user = Session["CurrentUser"] as Users;
            if (user != null)
            {
                var allWorks = db.UserWorks.Include(u => u.Users).Include(u => u.Works).ToList();
                List<Users> departmentUsers = db.Users
                    .Where(x => x.DepartmentId == user.DepartmentId).ToList();
                Users departmentDirector = departmentUsers
                    .FirstOrDefault(y => y.Missions.IsDirector ?? false);
                IEnumerable<UserWorks> userWorks = new List<UserWorks>();
                if (departmentDirector.Id == user.Id)
                    userWorks = allWorks
                        .Where(work => departmentUsers.Any(departmentUser => departmentUser.Id == work.UsersId));
                else
                    return RedirectToAction("Index", "Home");
                //userWorks = allWorks.Where(x => x.Id == user.Id);

                return View(userWorks.ToList());
            }
            else
                return RedirectToAction("Index", "Home");


        }

        // GET: UserWorks/Details/5
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


        // GET: UserWorks/Create
        public ActionResult Create()
        {
            Users userC = (Users)Session["CurrentUser"];
            ViewBag.UsersId = new SelectList((from s in db.Users.ToList().Where(g => g.DepartmentId == userC.DepartmentId)
                                              select new
                                              {
                                                  Id = s.Id,
                                                  Name = s.Name + " " + s.Lastname
                                              }),
            "Id",
            "Name",
            null);
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Name");
            return View();
        }
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
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Name", userWorks.WorksId);
            return View(userWorks);
        }
        // GET: UserWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users userC = (Users)(Session["CurrentUser"]);
            ViewBag.UsersId = new SelectList((from s in db.Users.ToList().Where(g => g.DepartmentId == userC.DepartmentId)
                                              select new
                                              {
                                                  Id = s.Id,
                                                  Name = s.Name + " " + s.Lastname
                                              }),
            "Id",
            "Name",
            null);
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsersId,WorksId,StartDate,EndDate,ActualEffort,AssignedEffort,RemainingEfort,CreatedTime,LastUpdateTime,UpdateExplanation,Status")] UserWorks userWorks)
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

        // GET: UserWorks/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: UserWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorks userWorks = db.UserWorks.Find(id);
            db.UserWorks.Remove(userWorks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tasks()
        {
            Users user = Session["CurrentUser"] as Users;

            List<UserWorks> TaskList = db.UserWorks.Where(x => x.UsersId == user.Id).ToList();
            return PartialView("Tasks", TaskList);
        }
    }
}
