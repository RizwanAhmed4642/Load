using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Task
{
    public int Id { get; set; }

    public int? TaskTypeId { get; set; }

    public string Subject { get; set; }

    public int? TripId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DoByDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public int? VenueTypeId { get; set; }

    public int? VenueId { get; set; }

    public string AssignToId { get; set; }

    public string Note { get; set; }

    public bool? Complete { get; set; }

    public int? ItemListPos { get; set; }

    public bool? ResponseRecieved { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
