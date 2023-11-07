using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class Part
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PartId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Shape { get; set; }

    public string? Material { get; set; }

    public string? Size { get; set; }

    public int ColorId { get; set; } = 0;

    public double? Cost { get; set; }

    public virtual ICollection<PartItem> PartItems { get; set; } = new List<PartItem>();
}
