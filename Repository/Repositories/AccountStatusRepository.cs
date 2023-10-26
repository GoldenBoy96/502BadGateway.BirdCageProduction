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
    public class AccountStatusRepository : BaseRepository<AccountStatus>, IAccountStatusRepository
    {
        private readonly BirdCageProductionContext _context;
        public AccountStatusRepository(BirdCageProductionContext context) : base(context)
        {
            _context = context;
        }
    }
}
