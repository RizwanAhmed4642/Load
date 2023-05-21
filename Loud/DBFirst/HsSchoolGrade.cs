using System;
using System.Collections.Generic;

namespace SAS.DBFirst;

public partial class HsSchoolGrade
{
    public int Id { get; set; }

    public int? Hsid { get; set; }

    public int? SchoolGradeId { get; set; }

    public int? Sastt { get; set; }

    public int? Srett { get; set; }

    public int? Seminar { get; set; }

    public int? None { get; set; }

    public int? Deleted { get; set; }

    public string CreatedBy { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsActive { get; set; }
}
