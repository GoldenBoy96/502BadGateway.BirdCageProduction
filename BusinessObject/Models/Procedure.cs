using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class Procedure
{
    public int ProcedureId { get; set; }

    public int? BirdCageCategoryId { get; set; }

    public string? Code { get; set; }

    public virtual BirdCageCategory? BirdCageCategory { get; set; }

    public virtual ICollection<ProcedureStep> ProcedureSteps { get; set; } = new List<ProcedureStep>();
}
