using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Trip
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public string Subject { get; set; }

    public int? SrerepId { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string Note { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
