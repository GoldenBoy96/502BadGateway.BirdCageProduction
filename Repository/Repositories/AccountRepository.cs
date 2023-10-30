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
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        private readonly BirdCageProductionContext _context;

        public AccountRepository(BirdCageProductionContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account?> GetByEmail(string email) => await _context.Accounts.FirstOrDefaultAsync(acc => acc.Email.Equals(email.Trim()));


        // Check login by email & password
        public Task<Account?> LoginAsync(string email, string password)
        {
            var x = _context.Accounts.FirstOrDefaultAsync(acc => (acc.Email.Equals(email) && acc.Password.Equals(password)));
            return x;
        }
    }
}
