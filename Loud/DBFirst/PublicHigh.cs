using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class PublicHigh
{
    public int Id { get; set; }

    public string Nm { get; set; }

    public string Streetaddress { get; set; }

    public int? SasuburbId { get; set; }

    public string PostalAddress { get; set; }

    public int? PasuburbId { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string Email2 { get; set; }

    public string Principal { get; set; }

    public string Note { get; set; }

    public bool? PasameAsSa { get; set; }

    public string Website { get; set; }

    public int? GeoStatusId { get; set; }

    public int? GeoAccuracyId { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public bool? LatLongSetByUser { get; set; }

    public int? SrestatusId { get; set; }

    public int? CurrentStatusId { get; set; }

    public int? OverideId { get; set; }

    public bool? WantsNewsletter { get; set; }

    public int? AreaId { get; set; }

    public bool? LockAreaId { get; set; }

    public int? SreboardId { get; set; }

    public int? ChaplainId { get; set; }

    public string Suburb { get; set; }

    public string Studentnumber { get; set; }

    public string SchoolType { get; set; }

    public string Postcode { get; set; }

    public string Campus { get; set; }

    public string Combtext { get; set; }

    public string Type { get; set; }

    public string Domain { get; set; }

    public bool? ExternalContactUpdated { get; set; }

    public bool? ExternalContactUpdated2 { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
