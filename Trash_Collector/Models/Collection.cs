
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Regular Collection Day")]
        public DayOfWeek? RegularCollectionDay { get; set; }

        [DisplayName("Collection Confirmed")]
        public bool CollectionConfirmed { get; set; }

        [DisplayName("Extra Collection Day")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ExtraCollectionDay { get; set; }

        [DisplayName("Extra Collection Confirmed")]
        public bool ExtraCollectionConfirmed { get; set; }

        public double Bill { get; set; }

        [DisplayName("Temporary Suspension Start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TemporarySuspensionStart { get; set; }

        [DisplayName("Temporary Suspension End")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TemporarySuspensionEnd { get; set; }
    }
}