using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class UserArea
{
    public int Id { get; set; }

    public int AreaId { get; set; }

    public string UserId { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
