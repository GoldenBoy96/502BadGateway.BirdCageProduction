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
    public class BirdCageRepository : BaseRepository<BirdCage>, IBirdCageRepository
    {
        public BirdCageRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public Task<BirdCage> FindByIdAsync(int id)
        {
            return _context.BirdCages
                .Include(bc => bc.PartItems).ThenInclude(pit => pit.Part)                 
                .FirstAsync(bc => bc.BirdCageId ==  id);
        }
    }
}
