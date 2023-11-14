using BusinessObject.Models;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProcedureRepository : BaseRepository<Procedure>, IProcedureRepository
    {
        public ProcedureRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public Procedure GetByBirdCageId(int birdCageId)
        {
            return _context.Procedures.FirstOrDefault(c => c.BirdCageId == birdCageId);
        }

        public async Task<Procedure?> GetById(int id) 
        {
            return _context.Procedures
                    .Include(p => p.ProcedureSteps)
                    .FirstOrDefault(p => p.ProcedureId == id);
        }
      

        //public ProcedureRepository GetByBirdCageIdAndQuantity(int birdCageId, int quantity)
        //{
        //    Procedure? procedure = _context.Procedures.FirstOrDefault(c => c.BirdCageId.Equals(birdCageId) && c.Quantity == quantity);
        //    if (procedure != null)
        //    {
        //        return _context.ProcedureSteps.
        //    }
        //}
    }
}
