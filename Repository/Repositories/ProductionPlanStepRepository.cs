using DataAccess;
using Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductionPlanStepRepository : BaseRepository<ProductionPlanStep>, IProductionPlanStepRepository
    {
        public ProductionPlanStepRepository(BirdCageProductionContext context) : base(context)
        {
        }
    }
}
