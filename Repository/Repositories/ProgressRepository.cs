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
    public class ProgressRepository : BaseRepository<Progress>, IProgressRepository
    {
        public ProgressRepository(BirdCageProductionContext context) : base(context)
        {
        }
    }
}
