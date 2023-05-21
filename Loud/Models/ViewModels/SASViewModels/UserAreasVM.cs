using System;
using System.ComponentModel.DataAnnotations;

namespace SAS.Models.ViewModels.SASViewModels
{
    public partial class UserAreasVM
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Nm { get; set; }
        [Required]
        [Display(Name = "Start Lat")]
        public float? StartLat { get; set; }
        [Required]
        [Display(Name = "Start Lng")]
        public float? StartLng { get; set; }
        [Required]
        [Display(Name = "End Lat")]
        public float? EndLat { get; set; }
        [Required]
        [Display(Name = "End Lng")]
        public float? EndLng { get; set; }
        [Display(Name = "SAS Church Partner ID")]
        public int? SASChurchPartnerID { get; set; }
        [StringLength(255)]
        public string Colour { get; set; }
        //this is the ID of UserAreas table which is now called UserAreaID
        public int UserAreaID { get; set; }
        public int AreaID { get; set; }
        public string UserID { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
