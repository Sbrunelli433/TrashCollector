using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

  
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            //if (this.User.IsInRole("Customer"))
            //{
            //    return RedirectToAction("Index", "Customers");
            //}
            //else if (this.User.IsInRole("Employee"))
            //{
            //    return RedirectToAction("Index", "Employees");
            //}
            
            
                return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}