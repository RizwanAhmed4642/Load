using System.ComponentModel.DataAnnotations;
using System;

namespace SAS.Models.SASModels
{
    public partial class Email
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string FromEmail { get; set; }
        [StringLength(255)]
        public string ToEmail { get; set; }
        [StringLength(512)]
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
