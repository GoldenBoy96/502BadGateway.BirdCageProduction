using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;


public partial class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

    public override string ToString()
    {
        return $"{{{nameof(OrderId)}={OrderId.ToString()}, {nameof(DayCreated)}={DayCreated.ToString()}, {nameof(TotalPrice)}={TotalPrice.ToString()}, {nameof(StatusId)}={StatusId.ToString()}, {nameof(Address)}={Address}, {nameof(AccountId)}={AccountId.ToString()}, {nameof(CustomerId)}={CustomerId.ToString()}}}";
    }
}
