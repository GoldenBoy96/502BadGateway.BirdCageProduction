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
        
        public ProgressStatusRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public IEnumerable<ProgressStatus> GetAll()
        {
            return _dbSet.ToList();
        }
    }
    
    
}
