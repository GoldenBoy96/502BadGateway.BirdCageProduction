using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Abstraction
{
    public interface IProcedureService
    {
        public Task<IEnumerable<ProcedureStep>> GetAllProcedureStepAsync();
        public Task<ProcedureStep?> GetProcedureStepByIdAsync(int procedureStepId);
        public Task<bool> AddProcedureStepAsync(ProcedureStep procedureStep);
        public Task<bool> DeleteProcedureStepAsync(ProcedureStep procedureStep);
        public Task<bool> UpdateProcedureStepAsync(ProcedureStep procedureStep);

        public Task<IEnumerable<Procedure>> GetAllProcedureAsync();
        public Task<Procedure?> GetProcedureByIdAsync(int procedureId);
        public Task<bool> AddProcedureAsync(Procedure procedure);
        public Task<bool> DeleteProcedureAsync(Procedure procedure);
        public Task<bool> DeleteProcedureAsync(int procedureId);
        public Task<bool> UpdateProcedureAsync(Procedure procedure);
        public Task<bool> UpdateProcedureAsync(Procedure procedure, List<ProcedureStep> procedureSteps);
    }
}
