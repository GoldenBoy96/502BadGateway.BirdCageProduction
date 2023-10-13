using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class BirdCageCategoryRepository : BaseRepository<BirdCageCategory>, IBirdCageCategoryRepository
    {
        public BirdCageCategoryRepository(BirdCageProductionContext context) : base(context)
        {
        }
    }
}
