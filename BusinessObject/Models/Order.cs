using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Order
{
    public int OrderId { get; set; }

    public int? AccountId { get; set; }

    public int? CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Code { get; set; }

    public DateTime? DayCreated { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
