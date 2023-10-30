using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class ProcedureStep
{
    public int ProcedureStepId { get; set; }

    public int StepNum { get; set; }

    public string? Description { get; set; }

    public double? TimeNeeded { get; set; }

    public double? Cost { get; set; }

    public int? NumOfWorker { get; set; }

    public int? ProcedureId { get; set; }

    public virtual Procedure? Procedure { get; set; }
}
