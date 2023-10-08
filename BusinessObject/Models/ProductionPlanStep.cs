using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class ProductionPlanStep
{
    public int ProductionPlanStepId { get; set; }

    public int? ProductionPlanId { get; set; }

    public int? ProcedureStepId { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? RealCost { get; set; }

    public virtual ProcedureStep? ProcedureStep { get; set; }

    public virtual ProductionPlan? ProductionPlan { get; set; }
}
