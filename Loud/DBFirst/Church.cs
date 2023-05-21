using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Church
{
    public int Id { get; set; }

    public int? Ypnum { get; set; }

    public string Nm { get; set; }

    public string PostalAddress { get; set; }

    public int? PasuburbId { get; set; }

    public bool? PasameAsSa { get; set; }

    public string StreetAddress { get; set; }

    public int? SasuburbId { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string Email2 { get; set; }

    public string Pastor { get; set; }

    public int? HighSchoolId { get; set; }

    public int Participate { get; set; }

    public string Note { get; set; }

    public string MapLink { get; set; }

    public string WebSite { get; set; }

    public int? GeoStatusId { get; set; }

    public double? GeoAccuracyId { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public bool? LatLongSetByUser { get; set; }

    public bool? WantsNewsletter { get; set; }

    public int? MinisterFraternalId { get; set; }

    public bool? LockAreaId { get; set; }

    public int? SreboardId { get; set; }

    public int? SrecoordinatorId { get; set; }

    public int? Attendance { get; set; }

    public string SupporterNumber { get; set; }

    public int SuburbId { get; set; }

    public string Postalcode { get; set; }

    public decimal? Donation { get; set; }

    public bool? ExternalContactUpdated { get; set; }

    public bool? ExternalContactUpdated2 { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public string Country { get; set; }

    public string PastorEmail { get; set; }

    public string PastorPhone { get; set; }

    public string PostCode { get; set; }

    public string GooglePlusCode { get; set; }

    public int? AreaId { get; set; }

    public int? Type { get; set; }

    public int? Eid { get; set; }
}
