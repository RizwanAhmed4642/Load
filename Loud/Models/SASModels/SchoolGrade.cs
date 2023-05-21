#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class SchoolGrade
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Nm { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public bool Default { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}