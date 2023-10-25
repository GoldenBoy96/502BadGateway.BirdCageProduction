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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly BirdCageProductionContext _context;
        public CustomerRepository(BirdCageProductionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CustomerExists(int id) => await _context.Customers.AnyAsync(e => e.CustomerId == id);      
    }
}
