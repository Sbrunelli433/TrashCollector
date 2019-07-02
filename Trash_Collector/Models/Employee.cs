using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("ApplicationUser")]
        [Display(Name = "Application Id")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        [Display(Name = "Current Date")]
        public DateTime? CurrentDate { get; }

        [Display(Name = "Confirm Pickup")]
        public bool ConfirmPickup { get; set; }
        [Display(Name = "Confirm Extra Pickup")]
        public bool ConfirmExtraPickup { get; set; }

        [Display(Name = "Charge to Bill")]
        public double ChargeToBill { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        [Display(Name ="Today's Pickups")]
        public List<object> PickUpThisDay { get; set; }

    }
}