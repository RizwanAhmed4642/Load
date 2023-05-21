#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class tblUser
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(255)]
        public string FName { get; set; }
        [StringLength(255)]
        public string LName { get; set; }
        [StringLength(255)]
        public string UserName { get; set; }
        [StringLength(255)]
        public string Password { get; set; }
        public bool PWReset { get; set; }
        public int? AccessLevelID { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}