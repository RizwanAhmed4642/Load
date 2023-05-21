using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Setting
{
    public int Id { get; set; }

    public string Nm { get; set; }

    public double? Num { get; set; }

    public string Txt { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
