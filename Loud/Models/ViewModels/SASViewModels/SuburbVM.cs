using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class SuburbVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name ="Name")]
        public string Nm { get; set; }
        [Display(Name = "State")]
        public int? StateID { get; set; }
        public string StateName { get; set; }
        [StringLength(255)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
