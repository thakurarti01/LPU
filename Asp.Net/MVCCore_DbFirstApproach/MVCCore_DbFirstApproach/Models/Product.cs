using System;
using System.Collections.Generic;

namespace MVCCore_DbFirstApproach.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Category { get; set; }

    public double? Price { get; set; }

    public string? Desc { get; set; }
}
