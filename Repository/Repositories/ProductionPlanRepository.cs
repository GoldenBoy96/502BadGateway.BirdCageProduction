using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductionPlanRepository : BaseRepository<ProductionPlan>, IProductionPlanRepository
    {
        public ProductionPlanRepository(BirdCageProductionContext context) : base(context)
        {
        }
    }
}
