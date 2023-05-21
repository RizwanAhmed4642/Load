using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class MinisterFraternalTaskVM
    {
        public int ID { get; set; }
        [Display(Name = "Minister Fraternal")]
        public int? MinisterFraternalID { get; set; }
        [Display(Name = "Minister Fraternal")]
        public string MinisterFraternalName { get; set; }
        [Display(Name = "M.Fraternal Task Type")]
        public int? MinisterFraternalTaskTypeID { get; set; }
        [Display(Name = "M.Fraternal Task Type")]
        public string MinisterFraternalTaskTypeName { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Assign To")]
        public string AssignToID { get; set; } // This means = USERID
        [Display(Name = "Assign To")]
        public string AssignToName { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
