using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class TripVM
    {
        public int ID { get; set; }
        [Display(Name= "Start Date")]
        public DateTime? StartDate { get; set; }
        [StringLength(35)]
        public string Subject { get; set; }
        [Display(Name = "SRERep")]
        public int? SRERepID { get; set; }
        [Display(Name = "SRERep")]
        public string SRERepName { get; set; }
        [Display(Name = "Completed Date")]
        public DateTime? CompletedDate { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Notes")]
        public string Note { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
