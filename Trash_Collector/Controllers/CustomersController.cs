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
    public class CustomersController : Controller
    {
        ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Customers
        public ActionResult Index()
        {
            return View("Index");

            //var customers = db.Customers.Include(m => m.ApplicationId).ToList();
            //var customers = db.Customers.Select(i => i.ApplicationId).SingleOrDefault();
            //return View(customers);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            var userId = User.Identity.GetUserId();
            Customer customer = db.Customers.Where(c => c.ApplicationId == userId).Include(c => c.ApplicationUser).FirstOrDefault();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);


            //var userId = User.Identity.GetUserId();
            //Customer customer = db.Customers.Where(c => c.ApplicationId == userId).Include(c => c.ApplicationUser).FirstOrDefault();

            //if (userId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //// Customer customer = db.Customers.Find(id);

            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Address, UserName, ApplicationId, ApplicationUser, City, EmailAddress, FirstName, Id, LastName, State, Zipcode, PickUpDay, ExraPickUpDay, ServiceStartDate, ServiceEndDate, SuspendServiceStartDate, SuspendServiceEndDate ")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.ApplicationId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id});
            }
            //ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", customer.ApplicationId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Where(c => c.Id == id).Include(c => c.ApplicationUser).FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Address, UserName, ApplicationId, ApplicationUser, City, EmailAddress, FirstName, Id, LastName, State, Zipcode, PickUpDay, ExraPickUpDay, ServiceStartDate, ServiceEndDate, SuspendServiceStartDate, SuspendServiceEndDate ")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer.Id });
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        // POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    db.Customers.Remove(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
