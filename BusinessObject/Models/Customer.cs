using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
