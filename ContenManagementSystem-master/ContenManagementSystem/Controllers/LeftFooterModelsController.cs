using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContenManagementSystem.DAL;
using ContenManagementSystem.Models;

namespace ContenManagementSystem.Controllers
{
    public class LeftFooterModelsController : Controller
    {
        private LeftFooterContext db = new LeftFooterContext();

        // GET: LeftFooterModels
        public ActionResult Index()
        {
            return View("LeftFooterView",db.leftFooterModel.ToList().Single());
        }

        // GET: LeftFooterModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeftFooterModel leftFooterModel = db.leftFooterModel.Find(id);
            if (leftFooterModel == null)
            {
                return HttpNotFound();
            }
            return View(leftFooterModel);
        }

        // GET: LeftFooterModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeftFooterModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LeftFooterModelID,para1,para2,videourl,noofLikes,videoDescription")] LeftFooterModel leftFooterModel)
        {
            if (ModelState.IsValid)
            {
                db.leftFooterModel.Add(leftFooterModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leftFooterModel);
        }

        // GET: LeftFooterModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeftFooterModel leftFooterModel = db.leftFooterModel.Find(id);
            if (leftFooterModel == null)
            {
                return HttpNotFound();
            }
            return View(leftFooterModel);
        }

        // POST: LeftFooterModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LeftFooterModelID,para1,para2,videourl,noofLikes,videoDescription")] LeftFooterModel leftFooterModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leftFooterModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leftFooterModel);
        }

        // GET: LeftFooterModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeftFooterModel leftFooterModel = db.leftFooterModel.Find(id);
            if (leftFooterModel == null)
            {
                return HttpNotFound();
            }
            return View(leftFooterModel);
        }

        // POST: LeftFooterModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeftFooterModel leftFooterModel = db.leftFooterModel.Find(id);
            db.leftFooterModel.Remove(leftFooterModel);
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
