using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class ProcedureStep
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProcedureStepId { get; set; }

    public int StepNum { get; set; }

    public string? Description { get; set; }

    public int? TimeNeeded { get; set; }

    public double? Cost { get; set; }

    public int? NumOfWorker { get; set; }

    public int? ProcedureId { get; set; }

    public virtual Procedure? Procedure { get; set; }
}
