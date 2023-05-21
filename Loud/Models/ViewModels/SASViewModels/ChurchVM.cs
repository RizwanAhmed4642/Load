using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models.ViewModels.SASViewModels
{
    public class ChurchVM
    {
        public int ID { get; set; }
        [Display(Name ="YP Number")]
        public int? YPNum { get; set; }
        [StringLength(255)]
        [Display(Name = "Church Name")]
        public string Nm { get; set; }
        [StringLength(255)]
        [Display(Name = "Postal Address")]
        public string PostalAddress { get; set; }
        [Display(Name = "PA Suburb ID")]
        public int? PASuburbID { get; set; }
        [Display(Name = "PA Same as SA")]
        public bool PASameAsSA { get; set; }
        [StringLength(255)]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "SUBURB")]
        public int? SASuburbID { get; set; }
        [StringLength(255)]
        [Display(Name = "Landline")]
        public string Phone1 { get; set; }
        [StringLength(255)]
        [Display(Name = "Mobile")]
        public string Phone2 { get; set; }
        [StringLength(255)]
        public string Fax { get; set; }
        [StringLength(255)]
        [Display(Name = "E-mail #1")]
        public string email { get; set; }
        [StringLength(255)]
        [Display(Name = "E-mail #2")]
        public string email2 { get; set; }
        [StringLength(255)]
        [Display(Name = "Pastor  Name")]
        public string Pastor { get; set; }
        [Display(Name = "Pastor  Phone")]
        public string PastorPhone { get; set; }
        [Display(Name = "Pastor  Email")]
        public string PastorEmail { get; set; }
        [Display(Name = "High School Group")]
        public int? HighSchoolID { get; set; }
        public int Participate { get; set; }
		[Display(Name = "Area")]
		public int? AreaID { get; set; }
		[Display(Name = "Area")]
		public string AreaName { get; set; }
		[Column(TypeName = "ntext")]
        [Display(Name = "Notes")]
        public string Note { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Map Link")]
        public string MapLink { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Web Site")]
        public string WebSite { get; set; }
        [Display(Name = "Geo Status ID")]
        public int? GeoStatusID { get; set; }
        [Display(Name = "Geo Accuracy ID")]
        public double? GeoAccuracyID { get; set; }
        [Display(Name = "Latitude")]
        public double? Lat { get; set; }
        [Display(Name = "Longitude")]
        public double? Lng { get; set; }
        [Display(Name = "Lat Long Set by User")]
        public bool LatLongSetByUser { get; set; }
        [Display(Name = "Wants News Letter")]
        public bool WantsNewsletter { get; set; }
        [Display(Name = "Minister Fraternal Name")]
        public int? MinisterFraternalID { get; set; }
        [Display(Name = "Lock Area ID")]
        public bool LockAreaID { get; set; }
        [Display(Name = "SRE Board Name")]
        public int? SREBoardID { get; set; }
        [Display(Name = "SRE Co-ordinator Name")]
        public int? SRECoordinatorID { get; set; }
        [Display(Name = "Weekly Church Attendance")]
        public int? Attendance { get; set; }
        [StringLength(255)]
        [Display(Name = "Supporter Number")]
        public string SupporterNumber { get; set; }
        [Display(Name = "Suburb")]
        public int SuburbID { get; set; }
        [Display(Name = "Suburb")]
        public string SuburbName { get; set; }
        [StringLength(255)]
        [Display(Name = "Postal Code")]
        public string Postalcode { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "SAS per month")]
        public decimal? Donation { get; set; }
        [Display(Name = "Google Plus Code")]
        public string GooglePlusCode { get; set; }
        [Display(Name = "External Contact Updated #1")]
        public bool externalContactUpdated { get; set; }
        [Display(Name = "External Contact Updated #2")]
        public bool externalContactUpdated2 { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime? lastUpdated { get; set; }
		public int? eid { get; set; }
		public int? Type { get; set; }
        public string NextTaskDoBy { get; set; }
        public string TaskSubject { get; set; }
        public string Days { get; set; }
        public string LastInfoSent { get; set; }
        public string EmailFlag { get; set; }
        public string AssociatedHighSchool { get; set; }
        public string Created_By { get; set; }
        public string Updated_By { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
        public bool isActive { get; set; }
    }
}
