using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class Progress
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgressId { get; set; }

    public int ProgressNum { get; set; }

    public DateTime? StartDay { get; set; }

    public DateTime? EndDay { get; set; }

    public int? StatusId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }

    public override string ToString()
    {
        return $"{{{nameof(ProgressId)}={ProgressId.ToString()}, {nameof(ProgressNum)}={ProgressNum.ToString()}, {nameof(StartDay)}={StartDay.ToString()}, {nameof(EndDay)}={EndDay.ToString()}, {nameof(StatusId)}={StatusId.ToString()}, {nameof(OrderDetailId)}={OrderDetailId.ToString()}, {nameof(AccountId)}={AccountId.ToString()}}}";
    }
}
