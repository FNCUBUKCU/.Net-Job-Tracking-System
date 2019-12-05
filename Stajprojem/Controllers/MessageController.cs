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
    public class MessagesController : Controller
    {
        private otomasyonEntities db = new otomasyonEntities();

        // GET: Messages/Create
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }
        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        [HttpPost]
        public ActionResult Details(int id)
        {
            //gelen id yi Veritabanımızda kontrol ediyoruz ve gelen employee partialviewimize gönderiyoruz
            return PartialView(db.Messages.FirstOrDefault(x => x.Id == id));
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            Users userC = (Users)Session["CurrentUser"];
          
            ViewBag.ReceiverId = new SelectList((from s in db.Users.ToList()
                                              select new
                                              {
                                                  Id = s.Id,
                                                  Name = s.Name + " " + s.Lastname
                                              }),
                                              "Id",
            "Name",
            null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SenderId,ReceiverId,Message")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                Users user = Session["CurrentUser"] as Users;
                if (user != null)
                    messages.SenderId = user.Id;
                
                messages.SendTime = DateTime.Now;
                db.Messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("OMessages");
            }

            return View(messages);
        }
        
        // GET: Messages/Create
        public ActionResult Imessages()
        {
            Users user = Session["CurrentUser"] as Users;
           
            if (user != null)
            {
                List<Messages> inComingMessages = db.Messages
                    .Where(x => x.ReceiverId == user.Id).ToList();     
                return View(inComingMessages);
            }
            else
                return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Imessages([Bind(Include = "SenderId,ReceiverId,Message")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messages);
        }

        // GET: Messages/Create
        public ActionResult Omessages()
        {
            Users user = Session["CurrentUser"] as Users;

            if (user != null)
            {
                List<Messages> OutgoingMessages = db.Messages
                    .Where(x => x.SenderId == user.Id).ToList();
                return View(OutgoingMessages);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Omessages([Bind(Include = "SenderId,ReceiverId,Message")] Messages messages)
        {
            if (ModelState.IsValid)
            {
                db.Messages.Add(messages);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messages);
        }


        
        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messages messages = db.Messages.Find(id);
            if (messages == null)
            {
                return HttpNotFound();
            }
            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messages messages = db.Messages.Find(id);
            db.Messages.Remove(messages);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

       
    }
}
