#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class Task
    {
        [Key]
        public int ID { get; set; }
        public int? TaskTypeID { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        public int? TripID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DoByDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? VenueTypeID { get; set; } // School type, Church type, or something like that
        public int? VenueID { get; set; } // This ID of School, Church, or something like that
        public string AssignToID { get; set; } // This means = USERID
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public bool Complete { get; set; }
        public int? ItemListPos { get; set; } //default value=2147483646, no need to take input from user
        public bool ResponseRecieved { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}