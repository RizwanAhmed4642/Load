using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Email
{
    public int Id { get; set; }

    public string FromEmail { get; set; }

    public string ToEmail { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
