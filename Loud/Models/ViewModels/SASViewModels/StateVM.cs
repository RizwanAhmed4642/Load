using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class StateVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name ="Name")]
        public string Nm { get; set; }
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
