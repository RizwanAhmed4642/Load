using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class UserAuditEvent
{
    public int UserAuditId { get; set; }

    public string UserId { get; set; }

    public DateTimeOffset Timestamp { get; set; }

    public int AuditEvent { get; set; }

    public string IpAddress { get; set; }
}
