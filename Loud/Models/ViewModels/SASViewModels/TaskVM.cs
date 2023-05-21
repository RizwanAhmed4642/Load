using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class TaskVM
    {
        public int ID { get; set; }
        [Display(Name = "Activity Type")]
        public int? TaskTypeID { get; set; }
        [Display(Name = "Activity Type")]
        public string TaskTypeName { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [Display(Name = "Trip")]
        public int? TripID { get; set; }
        [Display(Name = "Trip")]
        public string TripName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Do By Date")]
        public DateTime? DoByDate { get; set; }
        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }
        [Display(Name = "Venue Type")]
        public int? VenueTypeID { get; set; } // School type, Church type, or something like that
        [Display(Name = "Venue Type")]
        public string VenueTypeName { get; set; } // School type, Church type, or something like that
        [Display(Name = "Venue")]
        public int? VenueID { get; set; } // This ID of School, Church, or something like that
        [Display(Name = "Venue")]
        public string VenueName { get; set; } // This ID of School, Church, or something like that
        [Display(Name = "Assign To")]
        public string AssignToID { get; set; } // This means = USERID
        [Display(Name = "Assign To")]
        public string AssignToName { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public bool Complete { get; set; }
        public int? ItemListPos { get; set; } //default value=2147483646, no need to take input from user
        [Display(Name = "Response Recieved")]
        public bool ResponseRecieved { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
