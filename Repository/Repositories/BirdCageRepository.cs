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
    public class BirdCageRepository : BaseRepository<BirdCage>, IBirdCageRepository
    {
        public BirdCageRepository(BirdCageProductionContext context) : base(context)
        {
        }
    }
}
