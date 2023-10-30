using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Progress
{
    public int ProgressId { get; set; }

    public int ProgressNum { get; set; }

    public DateTime? StartDay { get; set; }

    public DateTime? EndDay { get; set; }

    public int? StatusId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
}
