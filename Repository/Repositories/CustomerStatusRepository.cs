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
    public class CustomerStatusRepository : BaseRepository<CustomerStatus>, ICustomerStatusRepository
    {
        private readonly BirdCageProductionContext _context;

        public CustomerStatusRepository(BirdCageProductionContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
