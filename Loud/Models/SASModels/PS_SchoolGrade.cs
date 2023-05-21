#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class PS_SchoolGrade
    {
        [Key]
        public int ID { get; set; }
        public int? PSID { get; set; }
        public int? SchoolGradeID { get; set; }
        public byte? SASTT { get; set; }
        public byte? SRETT { get; set; }
        public byte? Seminar { get; set; }
        public byte? None { get; set; }
        public byte? Deleted { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}