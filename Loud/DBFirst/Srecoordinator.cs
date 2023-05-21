using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class Srecoordinator
{
    public int Id { get; set; }

    public string Nm { get; set; }

    public string Note { get; set; }

    public int? SrecoordinatorRepId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PostalAddress { get; set; }

    public int? PasuburbId { get; set; }

    public string Phone1 { get; set; }

    public string Phone2 { get; set; }

    public string Email { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
