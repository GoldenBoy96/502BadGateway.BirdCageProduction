using System;
using System.Collections.Generic;

namespace DataAccess;

public partial class PartItem
{
    public int PartItemId { get; set; }

    public int? Quantity { get; set; }

    public int? PartId { get; set; }

    public int? BirdCageCategoryId { get; set; }

    public virtual BirdCageCategory? BirdCageCategory { get; set; }

    public virtual Part? Part { get; set; }

    public virtual ICollection<ProcedureStep> ProcedureSteps { get; set; } = new List<ProcedureStep>();
}
