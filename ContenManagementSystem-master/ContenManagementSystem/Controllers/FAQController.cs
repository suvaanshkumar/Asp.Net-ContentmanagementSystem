using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ContenManagementSystem.DAL;
using ContenManagementSystem.Models;

namespace ContenManagementSystem.Controllers
{
    public class FAQController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: FAQ
        [AllowAnonymous]
        public ActionResult Index(string Category, string searchString, int? page)
        {
            
            var faqs = from q in db.faqs select q;
             faqs = faqs.OrderBy(q => q.FrequentQuestionID);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                ViewBag.CurrentFilter = searchString;
            }

            ViewBag.CurrentFilter = searchString;


            //Categories
            List<string> list = new List<string>();
            list = faqs.Select(q => q.Category).Distinct().ToList();
            ViewBag.Categories = list;
            ViewBag.CategorySelected = false;
            if (!String.IsNullOrEmpty(Category))
            {
                ViewBag.CategorySelected = true;
                faqs = faqs.Where(q => q.Category.Equals(Category));
            }

            //Search Functionality
            if (!String.IsNullOrEmpty(searchString))
            {
                faqs = faqs.Where(s => s.Answer.Contains(searchString)
                                    || s.Question.Contains(searchString));
            }
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(faqs.ToPagedList(pageNumber, pageSize));
        }


        // GET: FAQ/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrequentQuestionID,Question,Answer,Category")] FrequentQuestion frequentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.faqs.Add(frequentQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frequentQuestion);
        }

        // GET: FAQ/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            if (frequentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(frequentQuestion);
        }

        // POST: FAQ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrequentQuestionID,Question,Answer,Category")] FrequentQuestion frequentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frequentQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frequentQuestion);
        }

        // GET: FAQ/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            if (frequentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(frequentQuestion);
        }

        // POST: FAQ/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            db.faqs.Remove(frequentQuestion);
            db.SaveChanges();
            return RedirectToAction("Index");
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
