#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class Area
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Nm { get; set; }
        public float? StartLat { get; set; }
        public float? StartLng { get; set; }
        public float? EndLat { get; set; }
        public float? EndLng { get; set; }
        public int? SASChurchPartnerID { get; set; }
        [StringLength(255)]
        public string Colour { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}