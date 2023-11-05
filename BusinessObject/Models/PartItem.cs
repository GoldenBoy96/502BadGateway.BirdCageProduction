using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class PartItem
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PartItemId { get; set; }

    public int? Quantity { get; set; }

    public int? PartId { get; set; }

    public int? BirdCageId { get; set; }

    public virtual BirdCage? BirdCage { get; set; }

    public virtual Part? Part { get; set; }
}
