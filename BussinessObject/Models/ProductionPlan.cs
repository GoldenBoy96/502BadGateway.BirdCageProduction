using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class ProductionPlan
{
    public int ProductionPlanId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual ICollection<ProductionPlanStep> ProductionPlanSteps { get; set; } = new List<ProductionPlanStep>();
}
