using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class SREBoardTaskVM
    {
        public int ID { get; set; }
        [Display(Name = "SRE Board")]
        public int? SREBoardID { get; set; }
        [Display(Name = "SRE Board")]
        public string SREBoardName { get; set; }
        [Display(Name = "Board Task Type")]
        public int? SREBoardTaskTypeID { get; set; }
        [Display(Name = "Board Task Type")]
        public string SREBoardTaskTypeName { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
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
