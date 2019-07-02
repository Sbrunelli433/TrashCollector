using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "Application Id")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }


        [Display(Name = "Email Address")]
        public string EmailAddress { get;  }

        [Display(Name = "Username")]
        public string Username { get;  }

        [Display(Name = "Address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }

        [Display(Name = "State")]
        [StringLength(50)]

        public string State { get; set; }

        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        [Display(Name = "Pick Up Day")]
        public DateTime? PickUpDay { get; set; }

        [Display(Name = "Collection")]
        public int collection { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}", NullDisplayText = "Billing")]
        public double Billing { get; set; }


        [Display(Name = "Extra Pick Up Day")]
        public DateTime? ExtraPickUpDay { get; set; }
        [Display(Name = "Extra Collection")]
        public int extraCollection { get; set; }

        [Display(Name = "Service Start Date")]
        public DateTime? ServiceStartDate { get; set; }

        [Display(Name = "Service End Date")]
        public DateTime? ServiceEndDate { get; set; }

        [Display(Name = "Suspend Service Start Date")]
        public DateTime? SuspendServiceStartDate { get; set; }


        [Display(Name = "Suspend Service End Date")]
        public DateTime? SuspendServiceEndDate { get; set; }

        public IEnumerable<int> Collection { get; set; }
        public IEnumerable<int> ExtraCollection { get; set; }




        //public virtual IEnumerable<ApplicationId> ApplicationIds { get; set; }


        //Choose Pick Up Day
        //Extra Pick Up Day
        //See Bill
        //Trash Collection Start Date & End Date
        //Suspend Service
        //Suspend Service Start Date & End Date
        //Resume Service Start Date
    }
}