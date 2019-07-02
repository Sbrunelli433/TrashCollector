using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;
using Microsoft.AspNet.Identity;


namespace Trash_Collector.Controllers
{
    public class EmployeesController : Controller
    {

        ApplicationDbContext db;
        public EmployeesController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Employees
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(e => e.ApplicationId == currentUserId).SingleOrDefault();
            DateTime currentDate = new DateTime();
            currentDate = DateTime.Today;
            int thisDay = (int)DateTime.Now.DayOfWeek;

            var pickUp = db.Customers.Where(p => p.Zipcode == employee.Zipcode && (p.collection.CompareTo(employee.ConfirmPickup) == thisDay) || (p.extraCollection.CompareTo(employee.ConfirmExtraPickup) == thisDay)).ToList();
            for (int i = 0; i < pickUp.Count; i++)
            {
                if (pickUp[i].collection.Equals(employee.ConfirmPickup));
                {
                    pickUp[i].extraCollection.Equals(employee.ConfirmExtraPickup);
                }
            }
            return View(pickUp);

            //var customers = db.Customers.ToList();

            //return View(customers);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Address, ApplicationId, ApplicationUser, City, EmailAddress, FirstName, Id, LastName, State, Username, Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();

                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = employee.Id });
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Where(c => c.Id == id).Include(c => c.ApplicationUser).FirstOrDefault();

            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Address, ApplicationId, ApplicationUser, City, EmailAddress, FirstName, Id, LastName, State, Username, Zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
