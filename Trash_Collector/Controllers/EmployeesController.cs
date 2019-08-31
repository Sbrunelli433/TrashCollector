
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;


namespace Trash_Collector.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(e => e.ApplicationId == currentUserId).Single();
            DateTime todaysDate = new DateTime();
            todaysDate = DateTime.Today;
            int today = (int)System.DateTime.Now.DayOfWeek;
            var customerCollections = db.Customers.Where(c => c.Zipcode == employee.Zipcode
            && ((int)c.Collection.RegularCollectionDay == today
            || c.Collection.ExtraCollectionDay == todaysDate))
                .Include(c => c.Collection)
                .ToList();

            for (int i = 0; i < customerCollections.Count; i++)
            {
                if (customerCollections[i].Collection.TemporarySuspensionStart != null
                    && customerCollections[i].Collection.TemporarySuspensionEnd != null)
                {
                    if (todaysDate.Ticks > ((DateTime)customerCollections[i].Collection.TemporarySuspensionStart)
                        .Ticks && todaysDate.Ticks < ((DateTime)customerCollections[i].Collection.TemporarySuspensionEnd).Ticks)
                    {
                        customerCollections.RemoveAt(i);
                    }
                }
            }
            return View(customerCollections);

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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,zipcode")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", "Employees", new { zipcode = employee.Zipcode });
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
            Employee employee = db.Employees.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Zipcode")] Employee employee)
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

        // Get Collections by dat
        public ActionResult CollectionsByDay(int dayOfWeek)
        {
            string currentUserId = User.Identity.GetUserId();
            Employee employee = db.Employees.Where(e => e.ApplicationId == currentUserId).Single();
            DateTime todaysDate = new DateTime();


            var customerCollections = db.Customers.Where(c => c.Zipcode == employee.Zipcode
            && ((int)c.Collection.RegularCollectionDay == dayOfWeek))
                .Include(c => c.Collection)
                .ToList();
            for (int i = 0; i < customerCollections.Count; i++)
            {
                if (customerCollections[i].Collection.TemporarySuspensionStart != null && customerCollections[i].Collection.TemporarySuspensionEnd != null)
                {
                    if (todaysDate.Ticks > ((DateTime)customerCollections[i].Collection.TemporarySuspensionStart)
                        .Ticks && todaysDate.Ticks < ((DateTime)customerCollections[i].Collection.TemporarySuspensionEnd).Ticks)
                    {
                        customerCollections.RemoveAt(i);
                    }
                }
            }
            return View(customerCollections);
        }

        //get collection details
        public ActionResult ShowCustomerAddress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //get confirm collection
        public ActionResult ConfirmCollection(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Where(c => c.Id == id)
                .Include(c => c.Collection).
                FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer.Collection);
        }

        //post confirm collection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmCollection([Bind(Include = "Id,RegularPickupDay,PickupConfirmed,ExtraPickupDay,ExtraPickupConfirmed,TemporarySuspensionStart,TemporarySuspensionEnd")] Collection collection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collection).State = EntityState.Modified;
                if (collection.CollectionConfirmed == true)
                {
                    collection.Bill += 25;
                }
                if(collection.ExtraCollectionConfirmed == true)
                {
                    collection.Bill += 25;
                }
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(collection);
        }
    }
}
