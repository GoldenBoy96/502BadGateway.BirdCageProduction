using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime? DayCreated { get; set; }

    public decimal? TotalPrice { get; set; }

    public int? StatusId { get; set; }

    public string? Address { get; set; }

    public int? AccountId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
