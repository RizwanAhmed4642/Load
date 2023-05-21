using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class GeoAccuracyVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Google Meaning")]
        public string GoogleMeaning { get; set; }
        [StringLength(10)]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
