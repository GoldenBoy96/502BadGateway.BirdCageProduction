using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class ProcedureStep
{
    public int ProcedureStepId { get; set; }

    public int? ProcedureId { get; set; }

    public int? PartItemId { get; set; }

    public string? Description { get; set; }

    public DateTime? TimeNeeded { get; set; }

    public int? Cost { get; set; }

    public virtual PartItem? PartItem { get; set; }

    public virtual Procedure? Procedure { get; set; }

    public virtual ICollection<ProductionPlanStep> ProductionPlanSteps { get; set; } = new List<ProductionPlanStep>();
}
