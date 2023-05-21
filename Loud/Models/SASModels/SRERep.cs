#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class SRERep
    {
        [Key]
        public int ID { get; set; }
        [StringLength(35)]
        public string FirstName { get; set; }
        [StringLength(35)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        public int? SASuburbID { get; set; }
        public bool PASameAsSA { get; set; }
        [StringLength(50)]
        public string PostalAddress { get; set; }
        public int? PASuburbID { get; set; }
        [StringLength(20)]
        public string Phone1 { get; set; }
        [StringLength(20)]
        public string Phone2 { get; set; }
        [StringLength(20)]
        public string Fax { get; set; }
        [StringLength(100)]
        public string email { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public bool Current { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}