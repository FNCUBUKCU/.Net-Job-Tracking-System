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
    public class WorksController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: Works
        public ActionResult Index()
        {
            return View(db.Works.ToList());

        }
        // GET: Works/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // GET: Works/Create
        public ActionResult Create()
        {

            ViewBag.UsersId = new SelectList(db.Users, "Id", "Name");
            ViewBag.WorksId = new SelectList(db.Works, "Id", "Number");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Name,StartDate,EndDate,CreatedTime,LastUpdateTime,Status")] Works works)
        {
            if (ModelState.IsValid)
            {
                works.CreatedTime = DateTime.Now;
                works.LastUpdateTime = DateTime.Now;
                db.Works.Add(works);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Name,StartDate,EndDate,CreatedTime,LastUpdateTime,UpdateExplanation,Status")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.Entry(works).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(works);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Works works = db.Works.Find(id);
            db.Works.Remove(works);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
