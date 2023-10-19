using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Procedure
{
    public int ProcedureId { get; set; }

    public int? BirdCageId { get; set; }

    public virtual BirdCage? BirdCage { get; set; }

    public virtual ICollection<ProcedureStep> ProcedureSteps { get; set; } = new List<ProcedureStep>();
}
