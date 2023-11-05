using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class BirdCage
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BirdCageId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PartItem> PartItems { get; set; } = new List<PartItem>();

    public virtual ICollection<Procedure> Procedures { get; set; } = new List<Procedure>();
}
