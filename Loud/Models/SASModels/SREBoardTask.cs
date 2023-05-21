#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class SREBoardTask
    {
        [Key]
        public int ID { get; set; }
        public int? SREBoardID { get; set; }
        public int? SREBoardTaskTypeID { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public string AssignToID { get; set; } // This means = USERID
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}