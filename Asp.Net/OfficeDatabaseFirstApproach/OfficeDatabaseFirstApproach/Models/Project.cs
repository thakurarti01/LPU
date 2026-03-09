using System;
using System.Collections.Generic;

namespace OfficeDatabaseFirstApproach.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? ProjectName { get; set; }

    public int? DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
}
