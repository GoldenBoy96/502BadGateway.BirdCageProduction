using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class Account
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public int? StatusId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
