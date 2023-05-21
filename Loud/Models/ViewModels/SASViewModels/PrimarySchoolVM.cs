using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAS.Models.ViewModels.SASViewModels
{
	public class PrimarySchoolVM
	{
		public int ID { get; set; }
		[StringLength(80)]
		[Display(Name = "Name")]
		public string Nm { get; set; }
		[StringLength(50)]
		[Display(Name = "Address")]
		public string StreetAddress { get; set; }
		[Display(Name = "Suburb")]
		public int? SASuburbID { get; set; }
		[Display(Name = "Suburb")]
		public string SASuburbName { get; set; }
		[StringLength(50)]
		[Display(Name = "Postal Address")]
		public string PostalAddress { get; set; }
		[Display(Name = "PA SUBURB")]
		public int? PASuburbID { get; set; }
		[Display(Name = "PA SUBURB")]
		public string PASuburbName { get; set; }
		[Display(Name = "STATE")]
		public int? StateID { get; set; }
		[Display(Name = "STATE")]
		public string StateName { get; set; }
		public string PostalCode { get; set; }
		[StringLength(20)]
		[Display(Name = "Landline")]
		public string Phone1 { get; set; }
		[StringLength(20)]
		[Display(Name = "Mobile")]
		public string Phone2 { get; set; }
		[StringLength(20)]
		public string Fax { get; set; }
		[StringLength(100)]
		[Display(Name = "E-mail 1")]
		public string email { get; set; }
		[StringLength(100)]
		[Display(Name = "E-mail 2")]
		public string email2 { get; set; }
		[StringLength(50)]
		[Display(Name = "School Code")]
		public string SchoolCode { get; set; }
		[Display(Name = "High School")]
		public int? HighSchoolID { get; set; }
		[StringLength(50)]
		[Display(Name = "Principal Name")]
		public string Principal { get; set; }
		[Column(TypeName = "ntext")]
		[Display(Name = "Notes")]
		public string Note { get; set; }
		[Display(Name = "PA Same as SA")]
		public bool PASameAsSA { get; set; }
		[Display(Name = "Is Combined With Selected HS")]
		public bool IsCombinedWithSelectedHS { get; set; }
		[StringLength(80)]
		[Display(Name = "Website")]
		public string WebSite { get; set; }
		[Display(Name = "Geo Status ID")]
		public int? GeoStatusID { get; set; }
		[Display(Name = "Geo Accuracy ID")]
		public int? GeoAccuracyID { get; set; }
        public string GeoAccuracyName { get; set; }
        [Display(Name = "Type")]
		public string type { get; set; }
		[Display(Name = "Latitude")]
		public float? Lat { get; set; }
		[Display(Name = "Longitude")]
		public float? Lng { get; set; }
		[Display(Name = "Lat/Long Set by User")]
		public bool LatLongSetByUser { get; set; }
		[Display(Name = "SRE Status")]
		public int? SREStatusID { get; set; }
		public string SREStatusName { get; set; }
		[Display(Name = "Overide")]
		public int? OverideID { get; set; }
		[Display(Name = "Wants News Letter")]
		public bool WantsNewsletter { get; set; }
		[Display(Name = "Lock Area ID")]
		public bool LockAreaID { get; set; }
		[Display(Name = "Chaplain ID")]
		public int? ChaplainID { get; set; }
		[Display(Name = "Principal Phone")]
		public string PrincipalPhone { get; set; }
		[Display(Name = "Principal E-mail")]
		public string PrincipalEmail { get; set; }
		[Display(Name = "Country")]
		public string Country { get; set; }
		[Display(Name = "Post Code")]
		public string PostCode { get; set; }
		[Display(Name = "Plus Code")]
		public string GooglePlusCode { get; set; }
		[Display(Name = "Map Link")]
		public string MapLink { get; set; }
		[Display(Name = "Area")]
		public int? AreaID { get; set; }
		[Display(Name = "Area")]
		public string AreaName { get; set; }
		[Display(Name = "SRE Board")]
		public int SREBoardID { get; set; }
		[Display(Name = "SRE Board")]
		public string SREBoardName { get; set; }
		public string ChaplainName { get; set; }
		public string NextTaskDoBy { get; set; }
		public string TaskSubject { get; set; }
		public string Days { get; set; }
		public string LastInfoSent { get; set; }
		public string EmailFlag { get; set; }
		public string AssociatedHighSchool { get; set; }
		public string AssociatedChurch { get; set; }
		public string Created_By { get; set; }
		public string Updated_By { get; set; }
		public DateTime? Created_At { get; set; }
		public DateTime? Updated_At { get; set; }
		public bool isActive { get; set; }
	}
}
