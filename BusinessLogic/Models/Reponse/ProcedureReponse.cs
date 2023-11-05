using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Reponse
{
    public class ProcedureReponse
    {
        public int ProcedureId { get; set; }

        public int? BirdCageId { get; set; }

        public virtual BirdCage? BirdCage { get; set; }

        public  List<ProcedureStep> ProcedureSteps { get; set; } = new List<ProcedureStep>();
    }
}
