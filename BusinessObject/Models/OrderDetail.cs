using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class OrderDetail
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OrderDetailId { get; set; }

    public int? Quantity { get; set; }

    public int? BirdCageId { get; set; }

    public int? OrderId { get; set; }

    public int? CurrentStep { get; set; }

    public virtual BirdCage? BirdCage { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
