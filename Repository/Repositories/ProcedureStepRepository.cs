using BusinessObject.Models;
using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProcedureStepRepository : BaseRepository<ProcedureStep>, IProcedureStepRepository
    {
        public ProcedureStepRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public async Task<List<ProcedureStep>> GetByProcedureId(int procedureId)
        {
            return _context.ProcedureSteps.Where(c => c.ProcedureId == procedureId).ToList();
        }
    }
}
