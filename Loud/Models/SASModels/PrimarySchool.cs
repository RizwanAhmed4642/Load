#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class PrimarySchool
    {
        [Key]
        public int ID { get; set; }
        [StringLength(80)]
        public string Nm { get; set; }
        [StringLength(50)]
        public string StreetAddress { get; set; }
        public int? SASuburbID { get; set; }
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
        [StringLength(100)]
        public string email2 { get; set; }
        [StringLength(50)]
        public string SchoolCode { get; set; } //number value
        public int? HighSchoolID { get; set; }
        [StringLength(50)]
        public string Principal { get; set; }
        [Column(TypeName = "ntext")]
        public string Note { get; set; }
        public bool PASameAsSA { get; set; }
        public bool IsCombinedWithSelectedHS { get; set; }
        [StringLength(80)]
        public string WebSite { get; set; }
        public int? GeoStatusID { get; set; }
        public int? GeoAccuracyID { get; set; }
        public string type { get; set; }
        public float? Lat { get; set; }
        public float? Lng { get; set; }
        public bool LatLongSetByUser { get; set; }
        public int? SREStatusID { get; set; }
        public int? OverideID { get; set; }
        public bool WantsNewsletter { get; set; }
        public bool LockAreaID { get; set; }
        public int? ChaplainID { get; set; }
        public string PrincipalPhone { get; set; }
        public string PrincipalEmail { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string GooglePlusCode { get; set; }
        public string MapLink { get; set; }
        public int? AreaID { get; set; }
        public int? SREBoardID { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}