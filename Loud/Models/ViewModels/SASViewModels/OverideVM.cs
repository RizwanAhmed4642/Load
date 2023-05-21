using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class OverideVM
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        [StringLength(50)]
        public string Nm { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
