using System;
using System.Collections.Generic;

namespace MVCCore_DbFirstApproach.Models;

public partial class Person
{
    public int? Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public string? Address { get; set; }

    public string? PhoneNo { get; set; }

    public string? SocialStatus { get; set; }
}
