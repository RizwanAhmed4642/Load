using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class CurrentStatusVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name ="Name")]
        public string Nm { get; set; }
        public bool Opportunity { get; set; }
        [StringLength(255)]
        [Display(Name = "High School Icon")]
        public string HighSchoolIcon { get; set; }
        [StringLength(255)]
        [Display(Name = "Primary School Icon")]
        public string PrimSchoolIcon { get; set; }
        [StringLength(255)]
        [Display(Name = "P.High School Icon")]
        public string PrivateHighIcon { get; set; }
        [StringLength(255)]
        [Display(Name = "P.Primary School Icon")]
        public string PrivatePrimaryIcon { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
