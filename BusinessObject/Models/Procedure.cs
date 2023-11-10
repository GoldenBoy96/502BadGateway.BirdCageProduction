using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObject.Models;

public partial class Procedure
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProcedureId { get; set; }

    public int? BirdCageId { get; set; }

    public int? Quantity { get; set; }

    public virtual BirdCage? BirdCage { get; set; }

    public virtual ICollection<ProcedureStep> ProcedureSteps { get; set; } = new List<ProcedureStep>();
}
