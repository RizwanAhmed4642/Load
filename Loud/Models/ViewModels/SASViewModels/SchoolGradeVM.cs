using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class SchoolGradeVM
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        [StringLength(255)]
        public string Nm { get; set; }
        [Display(Name = "Min Year")]
        public int? MinYear { get; set; }
        [Display(Name = "Max Year")]
        public int? MaxYear { get; set; }
        public bool Default { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
