#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class NewChurch
    {
        [Key]
        public int id { get; set; }
        public int? YPNum { get; set; }
        [StringLength(255)]
        public string Nm { get; set; }
        [StringLength(255)]
        public string postaladdress { get; set; }
        public int? PASuburbID { get; set; }
        public bool PASameAsSA { get; set; }
        [StringLength(255)]
        public string streetaddress { get; set; }
        public int? SASuburbID { get; set; }
        [StringLength(255)]
        public string Phone1 { get; set; }
        [StringLength(255)]
        public string Phone2 { get; set; }
        [StringLength(255)]
        public string Fax { get; set; }
        [StringLength(255)]
        public string email { get; set; }
        [StringLength(255)]
        public string Pastor { get; set; }
        public int? HighSchoolID { get; set; }
        [StringLength(255)]
        public string Participate { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        [StringLength(255)]
        public string MapLink { get; set; }
        [StringLength(255)]
        public string website { get; set; }
        public int? GeoStatusID { get; set; }
        public int? GeoAccuracyID { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public bool LatLongSetByUser { get; set; }
        public bool WantsNewsletter { get; set; }
        [StringLength(255)]
        public string MinisterFraternalID { get; set; }
        public bool LockAreaID { get; set; }
        public int? SREBoardID { get; set; }
        [StringLength(255)]
        public string SRECoordinatorID { get; set; }
        [StringLength(255)]
        public string Attendance { get; set; }
        [StringLength(255)]
        public string SupporterNumber { get; set; }
        [StringLength(255)]
        public string Donation { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}