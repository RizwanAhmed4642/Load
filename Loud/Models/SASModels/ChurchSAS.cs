#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class ChurchSAS
    {
        [Key]
        public int ID { get; set; }
        public int? YPNum { get; set; }
        [StringLength(80)]
        public string Nm { get; set; }
        [StringLength(50)]
        public string PostalAddress { get; set; }
        public int? PASuburbID { get; set; }
        public bool PASameAsSA { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        public int? SASuburbID { get; set; }
        [StringLength(20)]
        public string Phone1 { get; set; }
        [StringLength(20)]
        public string Phone2 { get; set; }
        [StringLength(20)]
        public string Fax { get; set; }
        [StringLength(100)]
        public string email { get; set; }
        [StringLength(255)]
        public string email2 { get; set; }
        [StringLength(50)]
        public string Pastor { get; set; }
        public int? HighSchoolID { get; set; }
        public int? Participate { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        [Column(TypeName = "ntext")]
        public string MapLink { get; set; }
        [StringLength(80)]
        public string WebSite { get; set; }
        public int? GeoStatusID { get; set; }
        public int? GeoAccuracyID { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public bool LatLongSetByUser { get; set; }
        public bool WantsNewsletter { get; set; }
        public int? MinisterFraternalID { get; set; }
        public bool LockAreaID { get; set; }
        public int? SREBoardID { get; set; }
        public int? SRECoordinatorID { get; set; }
        public int? Attendance { get; set; }
        [StringLength(8)]
        public string SupporterNumber { get; set; }
        [Column(TypeName = "money")]
        public decimal? Donation { get; set; }
        public int? eid { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}