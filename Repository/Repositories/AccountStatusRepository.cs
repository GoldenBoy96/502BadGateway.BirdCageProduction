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
    public class AccountStatusRepository : BaseRepository<AccountStatus>, IAccountStatusRepository
    {

        public AccountStatusRepository(BirdCageProductionContext context) : base(context)
        {
            //_context = context;
        }

        public  IEnumerable<AccountStatus> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
