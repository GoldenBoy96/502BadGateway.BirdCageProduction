using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string? StatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
