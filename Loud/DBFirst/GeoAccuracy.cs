using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class GeoAccuracy
{
    public int Id { get; set; }

    public string GoogleMeaning { get; set; }

    public string Description { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
