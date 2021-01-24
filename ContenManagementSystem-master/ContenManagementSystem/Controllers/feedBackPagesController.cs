using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ContenManagementSystem.DAL;
using ContenManagementSystem.Models;

namespace ContenManagementSystem
{
    public class feedBackPagesController : Controller
    {
        private LeftFooterContext db = new LeftFooterContext();

        // GET: feedBackPages
        public ActionResult Index()
        {
            return View(db.feedBackPages.ToList().FirstOrDefault());
        }

        // GET: feedBackPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedBackPage feedBackPage = db.feedBackPages.Find(id);
            if (feedBackPage == null)
            {
                return HttpNotFound();
            }
            return View(feedBackPage);
        }

        // GET: feedBackPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: feedBackPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,senderEmailAddress,feedBack,rating,subject")] feedBackPage feedBackPage)
        {
            if (ModelState.IsValid)
            {
                db.feedBackPages.Add(feedBackPage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedBackPage);
        }

        // GET: feedBackPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedBackPage feedBackPage = db.feedBackPages.Find(id);
            if (feedBackPage == null)
            {
                return HttpNotFound();
            }
            return View(feedBackPage);
        }

        // POST: feedBackPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,senderEmailAddress,feedBack,rating,subject")] feedBackPage feedBackPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedBackPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedBackPage);
        }

        // GET: feedBackPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            feedBackPage feedBackPage = db.feedBackPages.Find(id);
            if (feedBackPage == null)
            {
                return HttpNotFound();
            }
            return View(feedBackPage);
        }

        // POST: feedBackPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            feedBackPage feedBackPage = db.feedBackPages.Find(id);
            db.feedBackPages.Remove(feedBackPage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(string receiver, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("testeraspt@gmail.com", "testeraspt");
                    var receiverEmail = new MailAddress("suvaansh1996@gmail.com", "suvaansh");
                    var password = "test@1234";
                    var sub = subject;
                    var body = message+" sender mail address= "+ receiver;
                    var smtp = new SmtpClient
                    {   
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
