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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(BirdCageProductionContext context) : base(context)
        {
        }
        public IEnumerable<Role> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
