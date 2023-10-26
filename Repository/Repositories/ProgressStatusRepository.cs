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
    public class ProgressStatusRepository : BaseRepository<ProgressStatus>, IProgressStatusRepository
    {
        private readonly BirdCageProductionContext _context;
        public ProgressStatusRepository(BirdCageProductionContext context) : base(context)
        {
            _context = context;
        }
    }
    
    
}
