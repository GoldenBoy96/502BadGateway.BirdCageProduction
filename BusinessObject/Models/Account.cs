using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Account
{
    public int AccountId { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Status { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductionPlan> ProductionPlans { get; set; } = new List<ProductionPlan>();
}
