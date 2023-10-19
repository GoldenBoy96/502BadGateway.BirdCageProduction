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
        public CustomerRepository(BirdCageProductionContext context) : base(context)
        {
        }

        public async Task<bool> CustomerExists(int id) => await Context.Customers.AnyAsync(e => e.CustomerId == id);      
    }
}
