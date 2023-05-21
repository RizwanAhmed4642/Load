#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class Trip
    {
        [Key]
        public int ID { get; set; }
        public DateTime? StartDate { get; set; }
        [StringLength(35)]
        public string Subject { get; set; }
        public int? SRERepID { get; set; }
        public DateTime? CompletedDate { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}