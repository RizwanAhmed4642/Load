using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class HS_SchoolGradeVM
    {
        public int ID { get; set; }
        [Display(Name ="High School")]
        public int? HSID { get; set; }
        [Display(Name = "High School")]
        public string HSName { get; set; }
        [Display(Name = "School Grade")]
        public int? SchoolGradeID { get; set; }
        [Display(Name = "School Grade")]
        public string SchoolGradeName { get; set; }
        [Display(Name = "SAS TT")]
        public int? SASTT { get; set; }
        [Display(Name = "SRE TT")]
        public int? SRETT { get; set; }
        public int? Seminar { get; set; }
        public int? None { get; set; }
		[Display(Name = "Declined")]
		public int? Deleted { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
