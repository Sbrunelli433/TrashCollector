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
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

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

        [Display(Name = "Collection")]
        [ForeignKey("Collection")]
        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }
        public IEnumerable<Collection> Collections { get; set; }
    }
}