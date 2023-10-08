using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Part
{
    public int PartId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Type { get; set; }

    public string? Shape { get; set; }

    public string? Material { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public int? Cost { get; set; }

    public virtual ICollection<PartItem> PartItems { get; set; } = new List<PartItem>();
}
