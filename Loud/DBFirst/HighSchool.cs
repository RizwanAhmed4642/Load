using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class HighSchool
{
    public int Id { get; set; }

    public string Nm { get; set; }

    public string StreetAddress { get; set; }

    public int? SasuburbId { get; set; }

    public string PostalAddress { get; set; }

    public int? PasuburbId { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string Principal { get; set; }

    public string Note { get; set; }

    public bool? PasameAsSa { get; set; }

    public string WebSite { get; set; }

    public int? GeoStatusId { get; set; }

    public int? GeoAccuracyId { get; set; }

    public float? Lat { get; set; }

    public float? Lng { get; set; }

    public bool? LatLongSetByUser { get; set; }

    public int? SrestatusId { get; set; }

    public int? OverideId { get; set; }

    public bool? WantsNewsletter { get; set; }

    public int? AreaId { get; set; }

    public bool? LockAreaId { get; set; }

    public int? SreboardId { get; set; }

    public int? ChaplainId { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }

    public string Email2 { get; set; }

    public string Type { get; set; }

    public string Country { get; set; }

    public string GooglePlusCode { get; set; }

    public string MapLink { get; set; }

    public string PostCode { get; set; }

    public string PrincipalEmail { get; set; }

    public string PrincipalPhone { get; set; }
}
