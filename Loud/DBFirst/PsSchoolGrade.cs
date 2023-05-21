using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class PsSchoolGrade
{
    public int Id { get; set; }

    public int? Psid { get; set; }

    public int? SchoolGradeId { get; set; }

    public byte? Sastt { get; set; }

    public byte? Srett { get; set; }

    public byte? Seminar { get; set; }

    public byte? None { get; set; }

    public byte? Deleted { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
