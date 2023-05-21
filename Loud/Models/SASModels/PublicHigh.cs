#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models
{
    public partial class PublicHigh
    {
        [Key]
        public int id { get; set; }
        [StringLength(255)]
        public string Nm { get; set; }
        [StringLength(255)]
        public string streetaddress { get; set; }
        public int? SASuburbID { get; set; }
        [StringLength(255)]
        public string PostalAddress { get; set; }
        public int? PASuburbID { get; set; }
        [StringLength(255)]
        public string phone1 { get; set; }
        [StringLength(255)]
        public string phone2 { get; set; }
        [StringLength(255)]
        public string Fax { get; set; }
        [StringLength(255)]
        public string email { get; set; }
        [StringLength(255)]
        public string email2 { get; set; }
        [StringLength(255)]
        public string Principal { get; set; }
        [StringLength(255)]
        public string Note { get; set; }
        public bool PASameAsSA { get; set; }
        [StringLength(255)]
        public string website { get; set; }
        public int? GeoStatusID { get; set; }
        public int? GeoAccuracyID { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public bool LatLongSetByUser { get; set; }
        public int? SREStatusID { get; set; }
        public int? CurrentStatusID { get; set; }
        public int? OverideID { get; set; }
        public bool WantsNewsletter { get; set; }
        public int? AreaID { get; set; }
        public bool LockAreaID { get; set; }
        public int? SREBoardID { get; set; }
        public int? ChaplainID { get; set; }
        [StringLength(255)]
        public string suburb { get; set; }
        [StringLength(255)]
        public string studentnumber { get; set; }
        [StringLength(255)]
        public string SchoolType { get; set; }
        [StringLength(255)]
        public string postcode { get; set; }
        [StringLength(255)]
        public string campus { get; set; }
        [StringLength(255)]
        public string combtext { get; set; }
        [StringLength(255)]
        public string type { get; set; }
        [StringLength(255)]
        public string domain { get; set; }
        public bool externalContactUpdated { get; set; }
        public bool externalContactUpdated2 { get; set; }
        public DateTime? lastUpdated { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}