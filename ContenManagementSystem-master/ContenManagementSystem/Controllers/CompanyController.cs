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
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.CompanyDescClasses.ToList());
        }

        [AllowAnonymous]
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // GET: Company/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        { 
            return View("");
        }

   

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyDescClassID,ShortDesc,Address,Website,Telephone")] CompanyDescClass companyDescClass)
        {
            if (ModelState.IsValid)
            {
                CompanyOpenHours OpenHours = new CompanyOpenHours()
                {
                    mondayOpen = "0000",
                    mondayClose = "0000",
                    tuesdayOpen = "0000",
                    tuesdayClose = "0000",
                    wednesdayOpen = "0000",
                    wednesdayClose = "0000",
                    thursdayOpen = "0000",
                    thursdayClose = "0000",
                    fridayOpen = "0000",
                    fridayClose = "0000",
                    saturdayOpen = "0000",
                    saturdayClose = "0000",
                    sundayOpen = "0000",
                    sundayClose = "0000"
                };
                List<CompanyEmployee> Employees = new List<CompanyEmployee>()
                    {
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID  } ,
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID }
                    };
                companyDescClass.Employees = Employees;
                companyDescClass.OpenHours = OpenHours;

                db.CompanyDescClasses.Add(companyDescClass);
                db.OpenHours.Add(companyDescClass.OpenHours);
                foreach (CompanyEmployee employee in companyDescClass.Employees)
                {
                    db.Employees.Add(employee);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyDescClass);
        }


        [Authorize(Roles = "Admin")]
        
        public ActionResult CreateNew()
        {
            CompanyDescClass companyDescClass = new CompanyDescClass
            {
                ShortDesc = "Edit Short Description",
                Address = "0 street name, City, Province",
                Website = "example@wordpress.com",
                Telephone = "(416) 000-0000"
            };
                    CompanyOpenHours OpenHours = new CompanyOpenHours()
                {
                    mondayOpen = "0000",
                    mondayClose = "0000",
                    tuesdayOpen = "0000",
                    tuesdayClose = "0000",
                    wednesdayOpen = "0000",
                    wednesdayClose = "0000",
                    thursdayOpen = "0000",
                    thursdayClose = "0000",
                    fridayOpen = "0000",
                    fridayClose = "0000",
                    saturdayOpen = "0000",
                    saturdayClose = "0000",
                    sundayOpen = "0000",
                    sundayClose = "0000"
                };
                List<CompanyEmployee> Employees = new List<CompanyEmployee>()
                    {
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID  } ,
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID },
                        new CompanyEmployee() { pictureID = "~/images/0.jpg", empName = "Edit Name", position = "Edit Title",CompanyEmployeeID = companyDescClass.CompanyDescClassID }
                    };
                companyDescClass.Employees = Employees;
                companyDescClass.OpenHours = OpenHours;

                db.CompanyDescClasses.Add(companyDescClass);
                db.OpenHours.Add(companyDescClass.OpenHours);
                foreach (CompanyEmployee employee in companyDescClass.Employees)
                {
                    db.Employees.Add(employee);
                }
                db.SaveChanges();
            

            return View("View", companyDescClass);
        }


        // GET: Company/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyDescClassID,ShortDesc,Address,Website,Telephone")] CompanyDescClass companyDescClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyDescClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyDescClass);
        }

        // GET: CompanyEmployees/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditEmployees(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmployee companyEmployee = db.Employees.Find(id);
            if (companyEmployee == null)
            {
                return HttpNotFound();
            }
            return View(companyEmployee);
        }

        // POST: CompanyEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployees([Bind(Include = "CompanyEmployeeID,empName,position,pictureID")] CompanyEmployee companyEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Company");         
            }
            return View(companyEmployee);
        }


        // GET: CompanyOpenHours/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditOpenHours(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            if (companyOpenHours == null)
            {
                return HttpNotFound();
            }
            return View(companyOpenHours);
        }

        // POST: CompanyOpenHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditOpenHours([Bind(Include = "CompanyOpenHoursID,mondayOpen,mondayClose,tuesdayOpen,tuesdayClose,wednesdayOpen,wednesdayClose,thursdayOpen,thursdayClose,fridayOpen,fridayClose,saturdayOpen,saturdayClose,sundayOpen,sundayClose")] CompanyOpenHours companyOpenHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyOpenHours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return View(companyOpenHours);
        }

        // GET: CompanyOpenHours/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult CreateOpenHours(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            if (companyOpenHours == null)
            {
                return HttpNotFound();
            }
            return View(companyOpenHours);
        }

        // POST: CompanyOpenHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOpenHours([Bind(Include = "CompanyOpenHoursID,mondayOpen,mondayClose,tuesdayOpen,tuesdayClose,wednesdayOpen,wednesdayClose,thursdayOpen,thursdayClose,fridayOpen,fridayClose,saturdayOpen,saturdayClose,sundayOpen,sundayClose")] CompanyOpenHours companyOpenHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyOpenHours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Company");
            }
            return View(companyOpenHours);
        }



        // GET: Company/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
            
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            //CompanyOpenHours openHours = db.OpenHours.Find(companyDescClass.OpenHours.CompanyOpenHoursID);
            db.OpenHours.Remove(companyDescClass.OpenHours);
            if (companyDescClass.Employees != null)
            {
                List<CompanyEmployee> emps = companyDescClass.Employees.ToList();
                foreach (CompanyEmployee emp in emps)
                {
                    db.Employees.Remove(emp);
                }
            }

            db.CompanyDescClasses.Remove(companyDescClass);
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
