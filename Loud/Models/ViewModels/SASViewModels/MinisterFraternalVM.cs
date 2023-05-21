using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class MinisterFraternalVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name ="Name")]
        public string Nm { get; set; }
        [Display(Name = "Church")]
        public int? ChurchID { get; set; }
        [Display(Name = "Church")]
        public string ChurchName { get; set; }
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
