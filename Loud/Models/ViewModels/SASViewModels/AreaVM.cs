using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public partial class AreaVM
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "The Nm field is  required.")]
        [Display(Name = "Name")]
        public string Nm { get; set; }
        [Display(Name = "Start Lat")]
        [Required(ErrorMessage = "The Start Lat field is required.")]
        public float StartLat { get; set; }
        [Display(Name = "Start Lng")]
        [Required(ErrorMessage = "The Start Lng field is required.")]
        public float StartLng { get; set; }
        [Display(Name = "End Lat")]
        [Required(ErrorMessage = "The End Lat field is required.")]
        public float EndLat { get; set; }
        [Display(Name = "End Lng")]
        [Required(ErrorMessage = "The End Lng field is required.")]
        public float EndLng { get; set; }
        [Display(Name = "SAS Church Partner ID")]
        public int SASChurchPartnerID { get; set; }
        [StringLength(255)]
        public string Colour { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
