#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class QuickFilters
    {
        [Key]
        public int ID { get; set; }
        public int? FormNm { get; set; }
        public int? Sort1 { get; set; }
        [StringLength(50)]
        public string FilterNm { get; set; }
        [StringLength(255)]
        public string FilterDesc { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}