using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Area
{
    public int Id { get; set; }

    public string Nm { get; set; }

    public float? StartLat { get; set; }

    public float? StartLng { get; set; }

    public float? EndLat { get; set; }

    public float? EndLng { get; set; }

    public int? SaschurchPartnerId { get; set; }

    public string Colour { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
