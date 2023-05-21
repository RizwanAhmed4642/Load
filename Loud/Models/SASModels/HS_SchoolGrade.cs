﻿#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class HS_SchoolGrade
    {
        [Key]
        public int ID { get; set; }
        public int? HSID { get; set; }
        public int? SchoolGradeID { get; set; }
        public int? SASTT { get; set; }
        public int? SRETT { get; set; }
        public int? Seminar { get; set; }
        public int? None { get; set; }
        public int? Deleted { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}