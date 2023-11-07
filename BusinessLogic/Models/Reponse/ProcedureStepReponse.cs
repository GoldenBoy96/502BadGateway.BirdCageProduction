using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class ProcedureStepReponse
    {
        public int ProcedureStepId { get; set; }

        public int StepNum { get; set; }

        public string? Description { get; set; }

        public double? TimeNeeded { get; set; }

        public double? Cost { get; set; }

        public int? NumOfWorker { get; set; }

        public int? ProcedureId { get; set; }
    }
}
